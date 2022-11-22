namespace Mandlebrot
{
    partial class MandlebrotPanel
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
            this.Picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(300, 288);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            this.Picture.SizeChanged += new System.EventHandler(this.CanvasSizeChanged);
            this.Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
            this.Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
            this.Picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
            this.Picture.Resize += new System.EventHandler(this.CanvasSizeChanged);
            // 
            // MandlebrotPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Picture);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MandlebrotPanel";
            this.Size = new System.Drawing.Size(300, 288);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
    }
}
