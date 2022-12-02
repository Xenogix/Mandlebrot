namespace MandlebrotDraw
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void MandlebrotPanelLoaded(object sender, EventArgs e)
        {
            mandlebrotParameters.Mandlebrot = mandlebrotPanel.Mandlebrot;
        }
    }
}
