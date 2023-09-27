namespace MandlebrotDraw
{
    partial class Display
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mandlebrotPanel = new MandlebrotPanel();
            mandlebrotParameters = new MandlebrotParameters();
            SuspendLayout();
            // 
            // mandlebrotPanel
            // 
            mandlebrotPanel.Dock = DockStyle.Fill;
            mandlebrotPanel.Location = new Point(0, 0);
            mandlebrotPanel.Margin = new Padding(6, 7, 6, 7);
            mandlebrotPanel.Name = "mandlebrotPanel";
            mandlebrotPanel.Size = new Size(1600, 1038);
            mandlebrotPanel.TabIndex = 0;
            mandlebrotPanel.Load += MandlebrotPanelLoaded;
            // 
            // mandlebrotParameters
            // 
            mandlebrotParameters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mandlebrotParameters.Location = new Point(1209, 38);
            mandlebrotParameters.Mandlebrot = null;
            mandlebrotParameters.Margin = new Padding(6, 7, 6, 7);
            mandlebrotParameters.Name = "mandlebrotParameters";
            mandlebrotParameters.Size = new Size(354, 254);
            mandlebrotParameters.TabIndex = 1;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 1038);
            Controls.Add(mandlebrotParameters);
            Controls.Add(mandlebrotPanel);
            DoubleBuffered = true;
            Margin = new Padding(6, 7, 6, 7);
            Name = "Display";
            Text = "Display";
            ResumeLayout(false);
        }

        #endregion

        private MandlebrotDraw.MandlebrotPanel mandlebrotPanel;
        private MandlebrotDraw.MandlebrotParameters mandlebrotParameters;
    }
}