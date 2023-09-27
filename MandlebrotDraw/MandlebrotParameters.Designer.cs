namespace MandlebrotDraw
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
            iterSlider = new TrackBar();
            zoomSlider = new TrackBar();
            titleIter = new Label();
            titleZoom = new Label();
            labelIter = new Label();
            labelZoom = new Label();
            ((System.ComponentModel.ISupportInitialize)iterSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zoomSlider).BeginInit();
            SuspendLayout();
            // 
            // iterSlider
            // 
            iterSlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iterSlider.Location = new Point(3, 51);
            iterSlider.Margin = new Padding(7, 8, 7, 8);
            iterSlider.Maximum = 1000;
            iterSlider.Minimum = 1;
            iterSlider.Name = "iterSlider";
            iterSlider.Size = new Size(343, 80);
            iterSlider.TabIndex = 0;
            iterSlider.TickFrequency = 100;
            iterSlider.Value = 1;
            iterSlider.ValueChanged += IterSliderValueChanged;
            // 
            // zoomSlider
            // 
            zoomSlider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            zoomSlider.Location = new Point(3, 207);
            zoomSlider.Margin = new Padding(7, 8, 7, 8);
            zoomSlider.Maximum = 1000;
            zoomSlider.Minimum = 1;
            zoomSlider.Name = "zoomSlider";
            zoomSlider.Size = new Size(343, 80);
            zoomSlider.TabIndex = 1;
            zoomSlider.TickFrequency = 100;
            zoomSlider.Value = 1;
            zoomSlider.ValueChanged += ZoomSliderValueChanged;
            // 
            // titleIter
            // 
            titleIter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleIter.AutoSize = true;
            titleIter.Location = new Point(11, 15);
            titleIter.Margin = new Padding(7, 0, 7, 0);
            titleIter.Name = "titleIter";
            titleIter.Size = new Size(164, 30);
            titleIter.TabIndex = 2;
            titleIter.Text = "Iteration Count :";
            // 
            // titleZoom
            // 
            titleZoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleZoom.AutoSize = true;
            titleZoom.Location = new Point(11, 169);
            titleZoom.Margin = new Padding(7, 0, 7, 0);
            titleZoom.Name = "titleZoom";
            titleZoom.Size = new Size(78, 30);
            titleZoom.TabIndex = 3;
            titleZoom.Text = "Zoom :";
            // 
            // labelIter
            // 
            labelIter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelIter.AutoSize = true;
            labelIter.Location = new Point(188, 15);
            labelIter.Margin = new Padding(7, 0, 7, 0);
            labelIter.Name = "labelIter";
            labelIter.Size = new Size(24, 30);
            labelIter.TabIndex = 4;
            labelIter.Text = "0";
            // 
            // labelZoom
            // 
            labelZoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelZoom.AutoSize = true;
            labelZoom.Location = new Point(104, 169);
            labelZoom.Margin = new Padding(7, 0, 7, 0);
            labelZoom.Name = "labelZoom";
            labelZoom.Size = new Size(24, 30);
            labelZoom.TabIndex = 5;
            labelZoom.Text = "0";
            // 
            // MandlebrotParameters
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelZoom);
            Controls.Add(labelIter);
            Controls.Add(titleZoom);
            Controls.Add(titleIter);
            Controls.Add(zoomSlider);
            Controls.Add(iterSlider);
            Margin = new Padding(7, 8, 7, 8);
            Name = "MandlebrotParameters";
            Size = new Size(353, 277);
            ((System.ComponentModel.ISupportInitialize)iterSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)zoomSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar iterSlider;
        private TrackBar zoomSlider;
        private Label titleIter;
        private Label titleZoom;
        private Label labelIter;
        private Label labelZoom;
    }
}
