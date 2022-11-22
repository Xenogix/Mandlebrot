using ILGPU;
using ILGPU.Algorithms;
using ILGPU.Runtime;
using ILGPU.Runtime.Cuda;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static MandlebrotView.ColorHelper;

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
        public double targetX;
        public double targetY;
        public double posX;
        public double posY;
        public double zoom;

        private Context context;
        private Accelerator accelerator;

        private Action<Index1D, ArrayView<byte>, ArrayView<double>, ArrayView<double>, int, int> loadedKernel;

        private MemoryBuffer1D<byte, Stride1D.Dense> kernelImageBits;

        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooXBuffer;
        private MemoryBuffer1D<double, Stride1D.Dense> kernelCooYBuffer;

        internal MandlebrotGPU(int maxIteration, int width, int height, double targetX = 0, double targetY = 0, double posX = 0, double posY = 0, double zoom = 1)
        {
            this.maxIteration = maxIteration;
            this.width = width;
            this.height = height;
            this.targetX = targetX;
            this.targetY = targetY;
            this.posX = posX;
            this.posY = posY;
            this.zoom = zoom;

            Initialize();
        }

        private void Initialize()
        {
            context = Context.CreateDefault();

            accelerator = context.CreateCudaAccelerator(0);

            loadedKernel = accelerator.LoadAutoGroupedStreamKernel<Index1D, ArrayView<byte>, ArrayView<double>, ArrayView<double>, int, int>(Kernel);
        }

        public Bitmap GetMandlebrotImage()
        {
            if (width <= 0 || height <= 0 || zoom <= 0)
                return new Bitmap(0, 0);

            double[] cooX = GetCoordinatesX(width, targetX, posX, zoom);
            double[] cooY = GetCoordinatesY(height, targetY, posY, zoom);

            kernelCooXBuffer = accelerator.Allocate1D(cooX);
            kernelCooYBuffer = accelerator.Allocate1D(cooY);
            kernelImageBits = accelerator.Allocate1D<byte>(width * height * 4);

            loadedKernel(height*width, kernelImageBits.View, kernelCooXBuffer.View, kernelCooYBuffer.View, maxIteration, width);
            accelerator.Synchronize();

            byte[] bits = kernelImageBits.GetAsArray1D();
            GCHandle bitsHandle = GCHandle.Alloc(bits, GCHandleType.Pinned);

            Bitmap bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject());

            bitsHandle.Free();

            kernelCooXBuffer.Dispose();
            kernelCooYBuffer.Dispose();
            kernelImageBits.Dispose();

            return bitmap;
        }

        private static void Kernel(Index1D i, ArrayView<byte> imageBits, ArrayView<double> cooX0, ArrayView<double> cooY0, int maxIteration, int width)
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

            double ratio = IntrinsicMath.Clamp((double)iteration / maxIteration,0,1);

            double h = XMath.Rem(XMath.Pow(ratio * 360, 1.5), 360);
            double s = 0.5;
            double l = ratio;

            imageBits[i * 4]     = 0;
            imageBits[i * 4 + 1] = 0;
            imageBits[i * 4 + 2] = 0;
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

        internal double ScreenToX0(double screenPosX, double screenWidth) => GetCoordinateX(width, 0, posX, zoom, screenPosX / screenWidth);
        internal double ScreenToY0(double screenPosY, double screenHeight) => GetCoordinateY(height, 0, posY, zoom, screenPosY / screenHeight);

        internal double GetRangeWidth() => GetRangeWidth(width, zoom);
        internal double GetRangeHeight() => GetRangeHeight(height, zoom);


        private static double GetCoordinateX(int width, double targetX, double posX, double zoom, double ratioX) => (posX + MIN_X0) + GetRangeWidth(width, zoom) * ratioX - GetRangeWidth(width, zoom) / 2d;
        private static double GetCoordinateY(int height, double targetY, double posY, double zoom, double ratioY) => -((posY + MIN_Y0) + GetRangeHeight(height, zoom) * ratioY - GetRangeHeight(height, zoom) / 2d);

        private static double GetRangeWidth(int width, double zoom) => (MAX_X0 - MIN_X0) / DEFAULT_SCREEN_WIDTH / zoom * width;
        private static double GetRangeHeight(int height, double zoom) => (MAX_Y0 - MIN_Y0) / DEFAULT_SCREEN_HEIGHT / zoom * height;
    }
}
