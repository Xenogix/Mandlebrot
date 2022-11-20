using ILGPU;
using ILGPU.Runtime;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mandlebrot
{
    internal static class Mandlebrot
    {
        const double MIN_X0 = -2.00;
        const double MAX_X0 = 0.47;

        const double MIN_Y0 = -1.12;
        const double MAX_Y0 = 1.12;

        internal static double[,] GetMandlebrotValues(int maxIteration, int width, int height, [Range(MIN_X0, MAX_X0)] double x0 = 0, [Range(MIN_Y0, MAX_Y0)] double y0 = 0, double zoom = 1)
        {
            double[,] result = new double[width, height];

            Tuple<double, double>[,] coordinates = GetCoordinates(width, height, x0, y0, zoom);

            for (int y = 0; y < coordinates.GetLength(1); y++)
                for (int x = 0; x < coordinates.GetLength(0); x++)
                    result[x, y] = GetMandlebrotPixel(maxIteration, coordinates[x, y].Item1, coordinates[x, y].Item2);

            return result;
        }

        internal static double[,] GetMandlebrotValuesParallel(int maxIteration, int width, int height, [Range(MIN_X0, MAX_X0)] double x0 = 0, [Range(MIN_Y0, MAX_Y0)] double y0 = 0, double zoom = 1)
        {
            double[,] result = new double[width, height];

            Tuple<double, double>[,] coordinates = GetCoordinates(width, height, x0, y0, zoom);

            Parallel.For(0, coordinates.GetLength(1),
                y => {
                    Parallel.For(0, coordinates.GetLength(0),
                        x =>
                        {
                            result[x, y] = GetMandlebrotPixel(maxIteration, coordinates[x, y].Item1, coordinates[x, y].Item2);
                        });
                });

            return result;
        }

        internal static double GetMandlebrotPixel(int maxIteration, [Range(MIN_X0, MAX_X0)] double x0, [Range(MIN_Y0, MAX_Y0)] double y0)
        {
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
                iteration++;
            }

            return (double)iteration / maxIteration;
        }

        internal static Tuple<double, double>[,] GetCoordinates(int width, int height, [Range(MIN_X0, MAX_X0)] double cooX = 0, [Range(MIN_Y0, MAX_Y0)] double cooY = 0, double zoom = 1)
        {
            Tuple<double, double>[,] result = new Tuple<double, double>[width, height];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    double x0 = MIN_X0 / zoom + (MAX_X0 - MIN_X0) / width / zoom * x + cooX;
                    double y0 = MIN_Y0 / zoom + (MAX_Y0 - MIN_Y0) / height / zoom * y + cooY;

                    result[x, y] = Tuple.Create(x0, y0);
                }

            return result;
        }
    }
}
