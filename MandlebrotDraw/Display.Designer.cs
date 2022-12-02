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
            this.mandlebrotPanel = new MandlebrotDraw.MandlebrotPanel();
            this.mandlebrotParameters = new MandlebrotDraw.MandlebrotParameters();
            this.SuspendLayout();
            // 
            // mandlebrotPanel
            // 
            this.mandlebrotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mandlebrotPanel.Location = new System.Drawing.Point(0, 0);
            this.mandlebrotPanel.Margin = new System.Windows.Forms.Padding(6);
            this.mandlebrotPanel.Name = "mandlebrotPanel";
            this.mandlebrotPanel.Size = new System.Drawing.Size(1600, 865);
            this.mandlebrotPanel.TabIndex = 0;
            this.mandlebrotPanel.Load += new System.EventHandler(this.MandlebrotPanelLoaded);
            // 
            // mandlebrotParameters
            // 
            this.mandlebrotParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mandlebrotParameters.Location = new System.Drawing.Point(1209, 32);
            this.mandlebrotParameters.Mandlebrot = null;
            this.mandlebrotParameters.Margin = new System.Windows.Forms.Padding(6);
            this.mandlebrotParameters.Name = "mandlebrotParameters";
            this.mandlebrotParameters.Size = new System.Drawing.Size(354, 298);
            this.mandlebrotParameters.TabIndex = 1;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.mandlebrotParameters);
            this.Controls.Add(this.mandlebrotPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Display";
            this.Text = "Display";
            this.ResumeLayout(false);

        }

        #endregion

        private MandlebrotDraw.MandlebrotPanel mandlebrotPanel;
        private MandlebrotDraw.MandlebrotParameters mandlebrotParameters;
    }
}