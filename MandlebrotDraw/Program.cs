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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Display());
        }
    }
}
