using MandlebrotLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandlebrotDraw
{
    public partial class MandlebrotPanel : UserControl
    {
        private int lastMouseX;
        private int lastMouseY;

        private bool mouseEntered = false;

        private bool isUpdated = false;

        public MandlebrotGPU Mandlebrot { get; set; }


        public MandlebrotPanel()
        {
            InitializeComponent();

            Mandlebrot = new MandlebrotGPU(100, Width, Height);
            Mandlebrot.ValueChanged += UpdateMandlebrot;

            MouseWheel += OnScroll;
        }

        public void UpdateMandlebrot(object? sender, EventArgs? e)
        {
            isUpdated = false;
            Picture.Invalidate();
        }

        private void CanvasSizeChanged(object sender, EventArgs e)
        {
            if (Mandlebrot == null)
                return;

            Mandlebrot.Width = Width;
            Mandlebrot.Height = Height;
        }

        private void OnScroll(object? sender, MouseEventArgs e)
        {
            int direction = Math.Sign(e.Delta);

            if (direction == -1)
                Mandlebrot.Zoom *= 0.9;
            else
                Mandlebrot.Zoom *= 1.1;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (isUpdated)
                return;

            if (Picture.Image != null)
                Picture.Image.Dispose();

            Picture.Image = Mandlebrot.GetMandlebrotImage();
            ;
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
                Mandlebrot.PosX -= Mandlebrot.GetRangeWidth() / Width * (e.X - lastMouseX);
                Mandlebrot.PosY -= Mandlebrot.GetRangeHeight() / Height * (e.Y - lastMouseY);

                lastMouseX = e.X;
                lastMouseY = e.Y;
            }
        }
    }
}
