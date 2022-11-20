using System.Drawing;
using System.Drawing.Imaging;

namespace MandlebrotView
{
    internal static class MandlebrotHelper
    {
        internal static Bitmap ConvertMandlebrotToBitmap(double[,] mandlebrot)
        {
            int width = mandlebrot.GetLength(0);
            int height = mandlebrot.GetLength(1);

            Bitmap Image = new Bitmap(width, height);



            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    var color = ColorHelper.HSLToRGB(new ColorHelper.HSL((int)(240 - mandlebrot[x, y] * 140d), 50, 100));
                    Color c = Color.FromArgb(color.R, color.G, color.B);
                    Image.SetPixel(x, y, c);
                }

            return Image;
        }
    }
}
