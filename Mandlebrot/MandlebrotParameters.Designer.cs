namespace Mandlebrot
{
    partial class MandlebrotParameters
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.iterSlider = new System.Windows.Forms.TrackBar();
            this.zoomSlider = new System.Windows.Forms.TrackBar();
            this.titleIter = new System.Windows.Forms.Label();
            this.titleZoom = new System.Windows.Forms.Label();
            this.labelIter = new System.Windows.Forms.Label();
            this.labelZoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iterSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // iterSlider
            // 
            this.iterSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iterSlider.Location = new System.Drawing.Point(6, 69);
            this.iterSlider.Margin = new System.Windows.Forms.Padding(6);
            this.iterSlider.Maximum = 1000;
            this.iterSlider.Minimum = 1;
            this.iterSlider.Name = "iterSlider";
            this.iterSlider.Size = new System.Drawing.Size(342, 90);
            this.iterSlider.TabIndex = 0;
            this.iterSlider.TickFrequency = 100;
            this.iterSlider.Value = 1;
            this.iterSlider.ValueChanged += new System.EventHandler(this.IterSliderValueChanged);
            // 
            // zoomSlider
            // 
            this.zoomSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zoomSlider.Location = new System.Drawing.Point(6, 198);
            this.zoomSlider.Margin = new System.Windows.Forms.Padding(6);
            this.zoomSlider.Maximum = 1000;
            this.zoomSlider.Minimum = 1;
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.Size = new System.Drawing.Size(342, 90);
            this.zoomSlider.TabIndex = 1;
            this.zoomSlider.TickFrequency = 100;
            this.zoomSlider.Value = 1;
            this.zoomSlider.ValueChanged += new System.EventHandler(this.ZoomSliderValueChanged);
            // 
            // titleIter
            // 
            this.titleIter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleIter.AutoSize = true;
            this.titleIter.Location = new System.Drawing.Point(16, 38);
            this.titleIter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.titleIter.Name = "titleIter";
            this.titleIter.Size = new System.Drawing.Size(164, 25);
            this.titleIter.TabIndex = 2;
            this.titleIter.Text = "Iteration Count :";
            // 
            // titleZoom
            // 
            this.titleZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleZoom.AutoSize = true;
            this.titleZoom.Location = new System.Drawing.Point(16, 167);
            this.titleZoom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.titleZoom.Name = "titleZoom";
            this.titleZoom.Size = new System.Drawing.Size(78, 25);
            this.titleZoom.TabIndex = 3;
            this.titleZoom.Text = "Zoom :";
            // 
            // labelIter
            // 
            this.labelIter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIter.AutoSize = true;
            this.labelIter.Location = new System.Drawing.Point(192, 38);
            this.labelIter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelIter.Name = "labelIter";
            this.labelIter.Size = new System.Drawing.Size(24, 25);
            this.labelIter.TabIndex = 4;
            this.labelIter.Text = "0";
            // 
            // labelZoom
            // 
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(108, 167);
            this.labelZoom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(24, 25);
            this.labelZoom.TabIndex = 5;
            this.labelZoom.Text = "0";
            // 
            // MandlebrotParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.labelIter);
            this.Controls.Add(this.titleZoom);
            this.Controls.Add(this.titleIter);
            this.Controls.Add(this.zoomSlider);
            this.Controls.Add(this.iterSlider);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MandlebrotParameters";
            this.Size = new System.Drawing.Size(354, 298);
            ((System.ComponentModel.ISupportInitialize)(this.iterSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar iterSlider;
        private System.Windows.Forms.TrackBar zoomSlider;
        private System.Windows.Forms.Label titleIter;
        private System.Windows.Forms.Label titleZoom;
        private System.Windows.Forms.Label labelIter;
        private System.Windows.Forms.Label labelZoom;
    }
}
