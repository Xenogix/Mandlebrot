using ILGPU;
using ILGPU.Runtime;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Mandlebrot
{
    internal class MandlebrotGPU
    {
        const double MIN_X0 = -2.00;
        const double MAX_X0 = 0.47;

        const double MIN_Y0 = -1.12;
        const double MAX_Y0 = 1.12;

        const double DEFAULT_SCREEN_WIDTH = 500d;
        const double DEFAULT_SCREEN_HEIGHT = 300d;

        public int maxIteration;
        public int width;
        public int height;
        public double x0;
        public double y0;
        public double posX;
        public double posY;
        public double zoom;

        private Context context;
        private Accelerator accelerator;

        private Action<Index1D, ArrayView<UInt32>, ArrayView<double>, ArrayView<double>, int, int> loadedKernel;

        private MemoryBuffer1D<UInt32, Stride1D.Dense> kernelImageBits;

        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooXBuffer;
        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooYBuffer;

        internal MandlebrotGPU(int maxIteration, int width, int height, double x0 = 0, double y0 = 0, double posX = 0, double posY = 0, double zoom = 1)
        {
            this.maxIteration = maxIteration;
            this.width = width;
            this.height = height;
            this.x0 = x0;
            this.y0 = y0;
            this.posX = posX;
            this.posY = posY;
            this.zoom = zoom;

            Initialize();
        }

        private void Initialize()
        {
            context = Context.CreateDefault();

            accelerator = context.GetPreferredDevice(false).CreateAccelerator(context);

            loadedKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<UInt32>, ArrayView<double>, ArrayView<double>, int, int>(Kernel);
        }

        internal Bitmap GetMandlebrotImage()
        {
            return GetMandlebrotImage(maxIteration, width, height, x0, y0, posX, posY, zoom);
        }

        private Bitmap GetMandlebrotImage(int maxIteration, int width, int height, double x0, double y0, double posX, double posY, double zoom)
        {
            if (width <= 0 || height <= 0 || zoom <= 0)
                return new Bitmap(0, 0);

            double[] cooX = GetCoordinatesX(width, x0, posX, zoom);
            double[] cooY = GetCoordinatesY(height, y0, posY, zoom);

            kernelCooXBuffer = accelerator.Allocate1D(cooX);
            kernelCooYBuffer = accelerator.Allocate1D(cooY);
            kernelImageBits = accelerator.Allocate1D<UInt32>(width * height);

            loadedKernel((int)kernelImageBits.Length, kernelImageBits.View, kernelCooXBuffer.View, kernelCooYBuffer.View, maxIteration, width);
            accelerator.Synchronize();

            UInt32[] bits = kernelImageBits.GetAsArray1D();
            GCHandle bitsHandle = GCHandle.Alloc(bits, GCHandleType.Pinned);

            Bitmap bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject());

            bitsHandle.Free();
            kernelCooXBuffer.Dispose();
            kernelCooYBuffer.Dispose();
            kernelImageBits.Dispose();

            return bitmap;
        }

        private static void Kernel(Index1D i, ArrayView<UInt32> imageBits, ArrayView<double> cooX0, ArrayView<double> cooY0, int maxIteration, int width)
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

            float ratio = (float)iteration / maxIteration;

            imageBits[i] = 4278190080u;
            imageBits[i] += (uint)(ratio * 255u);
        }

        private static double[] GetCoordinatesX(int width, double x0, double posX, double zoom)
        {
            double[] result = new double[width];

            for (int x = 0; x < width; x++)
                result[x] = GetCoordinateX(width, x0, posX, zoom, (double)x / width);

            return result;
        }

        private static double[] GetCoordinatesY(int height, double y0, double posY, double zoom)
        {
            double[] result = new double[height];

            for (int y = 0; y < height; y++)
                result[y] = GetCoordinateY(height, y0, posY, zoom, (double)y / height);

            return result;
        }

        internal double ScreenToX0(double screenPosX, double screenWidth) => GetCoordinateX(width, 0, posX, zoom, screenPosX / screenWidth);
        internal double ScreenToY0(double screenPosY, double screenHeight) => GetCoordinateY(height, 0, posY, zoom, screenPosY / screenHeight);

        internal double GetRangeWidth() => GetRangeWidth(width, zoom);
        internal double GetRangeHeight() => GetRangeHeight(height, zoom);


        private static double GetCoordinateX(int width, double x0, double posX, double zoom, double ratioX) => (posX + MIN_X0) + GetRangeWidth(width, zoom) * ratioX - GetRangeWidth(width, zoom) / 2d;
        private static double GetCoordinateY(int height, double y0, double posY, double zoom, double ratioY) => -((posY + MIN_Y0) + GetRangeHeight(height, zoom) * ratioY - GetRangeHeight(height, zoom) / 2d);

        private static double GetRangeWidth(int width, double zoom) => (MAX_X0 - MIN_X0) / DEFAULT_SCREEN_WIDTH / zoom * width;
        private static double GetRangeHeight(int height, double zoom) => (MAX_Y0 - MIN_Y0) / DEFAULT_SCREEN_HEIGHT / zoom * height;
    }
}
