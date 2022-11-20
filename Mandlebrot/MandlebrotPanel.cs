using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandlebrot
{
    public partial class MandlebrotPanel : UserControl
    {
        public double x0;
        public double y0;

        public int lastMouseX;
        public int lastMouseY;

        public bool mouseEntered = false;

        bool isUpdated = false;

        private MandlebrotGPU mandlebrot;
        
        public MandlebrotPanel()
        {
            InitializeComponent();

            mandlebrot = new MandlebrotGPU(200, Width, Height, -0.45, 0, 1);

            MouseWheel += OnScroll;
        }

        private void CanvasSizeChanged(object sender, EventArgs e)
        {
            mandlebrot.width = Width;
            mandlebrot.height = Height;

            isUpdated = false;
            Picture.Invalidate();
        }


        private void OnScroll(object sender, MouseEventArgs e)
        {
            int direction = Math.Sign(e.Delta);

            if (direction == -1)
                mandlebrot.zoom *= 0.9;
            else
                mandlebrot.zoom *= 1.1;

            isUpdated = false;
            Picture.Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (isUpdated)
                return;

            Picture.Image = mandlebrot.GetMandlebrotImage().Clone() as Bitmap;

            isUpdated = true;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseX = e.X;
            lastMouseY = e.Y;

            mouseEntered = true;
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            mouseEntered = false;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseEntered)
            {
                mandlebrot.posX -= mandlebrot.GetRangeWidth() / Width * (e.X - lastMouseX);
                mandlebrot.posY -= mandlebrot.GetRangeHeight() / Height * (e.Y - lastMouseY);

                lastMouseX = e.X;
                lastMouseY = e.Y;

                isUpdated = false;
                Picture.Invalidate();
            }
            else
            {
                
                mandlebrot.x0 = mandlebrot.ScreenToX0(e.X, Width);
                mandlebrot.y0 = mandlebrot.ScreenToY0(e.Y, Height);
            }

            Console.WriteLine("X0 : " + mandlebrot.ScreenToX0(e.X, Width));
            Console.WriteLine("Y0 : " + mandlebrot.ScreenToY0(e.Y, Height));
        }
    }
}
