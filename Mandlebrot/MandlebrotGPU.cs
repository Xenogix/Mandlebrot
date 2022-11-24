﻿using ILGPU;
using ILGPU.Algorithms;
using ILGPU.Runtime;
using ILGPU.Runtime.Cuda;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static MandlebrotView.ColorHelper;

namespace Mandlebrot
{
    public class MandlebrotGPU
    {
        private const double MIN_X0 = -2.00;
        private const double MAX_X0 = 0.47;

        private const double MIN_Y0 = -1.12;
        private const double MAX_Y0 = 1.12;

        private const double DEFAULT_SCREEN_WIDTH = 500d;
        private const double DEFAULT_SCREEN_HEIGHT = 300d;

        public const double MAX_ZOOM = 8e13;
        public const int MAX_ITERATION = 2000;

        public event EventHandler ValueChanged;

        private int width;
        public int Width { get => width; set { width = value; NotifyValueChanged(); } }

        private int height;
        public int Height { get => height; set { height = value; NotifyValueChanged(); } }

        private double targetX;
        public double TargetX { get => targetX; set { targetX = value; NotifyValueChanged(); } }

        private double targetY;
        public double TargetY { get => targetY; set { targetY = value; NotifyValueChanged(); } }

        private double posX;
        public double PosX { get => posX; set { posX = value; NotifyValueChanged(); } }

        private double posY;
        public double PosY { get => posY; set { posY = value; NotifyValueChanged(); } }

        private int iterations;
        public int Iterations { get => iterations; set { iterations = Math.Min(value, MAX_ITERATION); NotifyValueChanged(); } }

        private double zoom;
        public double Zoom { get => zoom; set { zoom = Math.Min(value, MAX_ZOOM); NotifyValueChanged(); } }

        private Context context;
        private Accelerator accelerator;

        private Action<Index1D, ArrayView<double>, ArrayView<double>, ArrayView<double>, int, int> loadedMandlebrotKernel;
        private Action<Index1D, ArrayView<double>, ArrayView<byte>> loadedColouringKernel;

        private MemoryBuffer1D<byte, Stride1D.Dense> kernelImageBits;

        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooXBuffer;
        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooYBuffer;
        private MemoryBuffer1D<double, Stride1D.Dense> kernelImageIterations;

        private GCHandle bitsHandle;
        private GCHandle BitsHandle 
        { 
            get => bitsHandle; 

            set 
            { 
                if(bitsHandle.IsAllocated) 
                    bitsHandle.Free(); 
                bitsHandle = value; 
            } 
        }

        internal MandlebrotGPU(int iterations, int width, int height, double targetX = 0, double targetY = 0, double posX = 0, double posY = 0, double zoom = 1)
        {
            this.Iterations = iterations;
            this.Width = width;
            this.Height = height;
            this.TargetX = targetX;
            this.TargetY = targetY;
            this.PosX = posX;
            this.PosY = posY;
            this.Zoom = zoom;

            Initialize();
        }

        private void Initialize()
        {
            context = Context.CreateDefault();

            accelerator = context.CreateCudaAccelerator(0);

            loadedMandlebrotKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<double>, ArrayView<double>, ArrayView<double>, int, int>(CalculateMandlebrotKernel);
            loadedColouringKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<double>, ArrayView<byte>>(CalculateColorsKernel);
        }

        private void NotifyValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public Bitmap GetMandlebrotImage()
        {
            if (Width <= 0 || Height <= 0 || zoom <= 0)
                return new Bitmap(0, 0);

            StartMandlebrotKernel();

            StartColouringKernel();

            Bitmap bitmap = GenerateBitmap();

            DisposeBuffers();

            return bitmap;
        }

        private void StartMandlebrotKernel()
        {
            double[] cooX = GetCoordinatesX(Width, TargetX, PosX, zoom);
            double[] cooY = GetCoordinatesY(Height, TargetY, PosY, zoom);

            kernelCooXBuffer = accelerator.Allocate1D(cooX);
            kernelCooYBuffer = accelerator.Allocate1D(cooY);
            kernelImageIterations = accelerator.Allocate1D<double>(Width * Height);

            loadedMandlebrotKernel(Height * Width, kernelImageIterations.View, kernelCooXBuffer.View, kernelCooYBuffer.View, Iterations, Width);
            accelerator.Synchronize();
        }

        private void StartColouringKernel()
        {
            kernelImageBits = accelerator.Allocate1D<byte>(Width * Height * 4);

            loadedColouringKernel(Height * Width, kernelImageIterations.View, kernelImageBits.View);
            accelerator.Synchronize();
        }

        private void DisposeBuffers()
        {
            kernelCooXBuffer.Dispose();
            kernelCooYBuffer.Dispose();
            kernelImageIterations.Dispose();
            kernelImageBits.Dispose();
        }

        private Bitmap GenerateBitmap()
        {
            byte[] bits = kernelImageBits.GetAsArray1D();
            BitsHandle = GCHandle.Alloc(bits, GCHandleType.Pinned);

            return new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        private static void CalculateMandlebrotKernel(Index1D i, ArrayView<double> imageIterations, ArrayView<double> cooX0, ArrayView<double> cooY0, int maxIteration, int width)
        {
            double x0 = cooX0[i % width];
            double y0 = cooY0[i / width];

            int iteration = 0;

            double x = 0d;
            double y = 0d;

            double x2 = 0d;
            double y2 = 0d;

            while (x2 + y2 <= 4 && iteration < maxIteration)
            {
                y = 2d * x * y + y0;
                x = x2 - y2 + x0;
                x2 = x * x;
                y2 = y * y;
                ++iteration;
            }

            imageIterations[i] = IntrinsicMath.Clamp((float)iteration / (float)maxIteration,0,1);
        }

        private static void CalculateColorsKernel(Index1D i, ArrayView<double> imageIterations, ArrayView<byte> imageBits)
        {
            double H = imageIterations[i] * imageIterations[i] * 360d;
            double S = 0.5d;
            double L = imageIterations[i];

            while (H > 360)
                H -= 360;

            double C = (1 - IntrinsicMath.Abs(2 * L - 1)) * S;
            double X = C * (1 - IntrinsicMath.Abs((((IntrinsicMath.DivRoundDown((int)H, 60) & (1 << 0)) != 0) ? 0 : 1) - 1));
            double m = L - C / 2;

            int r = (int)(H / 60d);

            imageBits[i * 4] = (byte)((((r == 0 || r == 5) ? C : ((r == 1 || r == 4) ? X : 0)) + m) * 255);
            imageBits[i * 4 + 1] = (byte)((((r == 1 || r == 2) ? C : ((r == 0 || r == 3) ? X : 0)) + m) * 255);
            imageBits[i * 4 + 2] = (byte)((((r == 3 || r == 4) ? C : ((r == 2 || r == 5) ? X : 0)) + m) * 255);
            imageBits[i * 4 + 3] = 255;
        }

        private static double[] GetCoordinatesX(int width, double targetX, double posX, double zoom)
        {
            double[] result = new double[width];

            for (int x = 0; x < width; x++)
                result[x] = GetCoordinateX(width, targetX, posX, zoom, (double)x / width);

            return result;
        }

        private static double[] GetCoordinatesY(int height, double targetY, double posY, double zoom)
        {
            double[] result = new double[height];

            for (int y = 0; y < height; y++)
                result[y] = GetCoordinateY(height, targetY, posY, zoom, (double)y / height);

            return result;
        }

        internal double ScreenToX0(double screenPosX, double screenWidth) => GetCoordinateX(Width, 0, PosX, zoom, screenPosX / screenWidth);
        internal double ScreenToY0(double screenPosY, double screenHeight) => GetCoordinateY(Height, 0, PosY, zoom, screenPosY / screenHeight);

        internal double GetRangeWidth() => GetRangeWidth(Width, zoom);
        internal double GetRangeHeight() => GetRangeHeight(Height, zoom);

        private static double GetCoordinateX(int width, double targetX, double posX, double zoom, double ratioX) => posX + GetRangeWidth(width, zoom) * ratioX - GetRangeWidth(width, zoom) / 2d;
        private static double GetCoordinateY(int height, double targetY, double posY, double zoom, double ratioY) => -(posY + GetRangeHeight(height, zoom) * ratioY - GetRangeHeight(height, zoom) / 2d);

        private static double GetRangeWidth(int width, double zoom) => (MAX_X0 - MIN_X0) / DEFAULT_SCREEN_WIDTH / zoom * width;
        private static double GetRangeHeight(int height, double zoom) => (MAX_Y0 - MIN_Y0) / DEFAULT_SCREEN_HEIGHT / zoom * height;
    }
}
