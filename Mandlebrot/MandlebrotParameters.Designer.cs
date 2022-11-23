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
            this.iterLabel = new System.Windows.Forms.Label();
            this.labelZoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iterSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // iterSlider
            // 
            this.iterSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iterSlider.Location = new System.Drawing.Point(8, 36);
            this.iterSlider.Name = "iterSlider";
            this.iterSlider.Size = new System.Drawing.Size(104, 45);
            this.iterSlider.TabIndex = 0;
            // 
            // zoomSlider
            // 
            this.zoomSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zoomSlider.Location = new System.Drawing.Point(8, 103);
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.Size = new System.Drawing.Size(104, 45);
            this.zoomSlider.TabIndex = 1;
            // 
            // titleIter
            // 
            this.titleIter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleIter.AutoSize = true;
            this.titleIter.Location = new System.Drawing.Point(8, 20);
            this.titleIter.Name = "titleIter";
            this.titleIter.Size = new System.Drawing.Size(82, 13);
            this.titleIter.TabIndex = 2;
            this.titleIter.Text = "Iteration Count :";
            // 
            // titleZoom
            // 
            this.titleZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleZoom.AutoSize = true;
            this.titleZoom.Location = new System.Drawing.Point(8, 84);
            this.titleZoom.Name = "titleZoom";
            this.titleZoom.Size = new System.Drawing.Size(40, 13);
            this.titleZoom.TabIndex = 3;
            this.titleZoom.Text = "Zoom :";
            // 
            // iterLabel
            // 
            this.iterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iterLabel.AutoSize = true;
            this.iterLabel.Location = new System.Drawing.Point(96, 20);
            this.iterLabel.Name = "iterLabel";
            this.iterLabel.Size = new System.Drawing.Size(13, 13);
            this.iterLabel.TabIndex = 4;
            this.iterLabel.Text = "0";
            // 
            // labelZoom
            // 
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(54, 84);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(13, 13);
            this.labelZoom.TabIndex = 5;
            this.labelZoom.Text = "0";
            // 
            // MandlebrotParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.iterLabel);
            this.Controls.Add(this.titleZoom);
            this.Controls.Add(this.titleIter);
            this.Controls.Add(this.zoomSlider);
            this.Controls.Add(this.iterSlider);
            this.Name = "MandlebrotParameters";
            this.Size = new System.Drawing.Size(177, 155);
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
        private System.Windows.Forms.Label iterLabel;
        private System.Windows.Forms.Label labelZoom;
    }
}
