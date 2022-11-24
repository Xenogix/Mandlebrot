using System;
using System.Windows.Forms;

namespace Mandlebrot
{
    public partial class MandlebrotParameters : UserControl
    {
        private MandlebrotGPU mandlebrot;
        public MandlebrotGPU Mandlebrot
        {
            get => mandlebrot;
            set
            {
                if (value == null)
                    return;

                mandlebrot = value;
                mandlebrot.ValueChanged += UpdateValues;
                UpdateValues(this, EventArgs.Empty);
            }
        }

        public MandlebrotParameters()
        {
            InitializeComponent();
        }

        private void UpdateValues(object sender, EventArgs e)
        {
            if (Mandlebrot == null)
                return;

            labelIter.Text = Mandlebrot.Iterations.ToString();
            labelZoom.Text = Mandlebrot.Zoom.ToString();
        }

        private void IterSliderValueChanged(object sender, EventArgs e)
        {
            Mandlebrot.Iterations = (int)Math.Pow(MandlebrotGPU.MAX_ITERATION, (double)iterSlider.Value / (double)iterSlider.Maximum);
        }

        private void ZoomSliderValueChanged(object sender, EventArgs e)
        {
            mandlebrot.Zoom = Math.Pow(MandlebrotGPU.MAX_ZOOM,(double)zoomSlider.Value / (double)zoomSlider.Maximum);
        }
    }
}
