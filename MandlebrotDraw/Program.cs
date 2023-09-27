namespace MandlebrotDraw
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            WindowsFormView();

            Console.ReadLine();
        }

        static void WindowsFormView()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Display());
        }
    }
}
