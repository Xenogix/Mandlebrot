using Mandlebrot;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MandlebrotView
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            WindowsFormView();

            Console.ReadLine();
        }

        static void ConsoleView()
        {
            Stopwatch stopWatch = new Stopwatch();

            MandlebrotGPU mandlebrot = new MandlebrotGPU(1000, 1000, 1000, -0.74529d, 0.113075d, 1);

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                stopWatch.Restart();

                mandlebrot.GetMandlebrotImage();

                stopWatch.Stop();

                Console.WriteLine("Render Time : " + stopWatch.ElapsedMilliseconds + "ms");
            }
        }

        static void WindowsFormView()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Display());
        }
    }
}
