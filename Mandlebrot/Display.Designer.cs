﻿namespace MandlebrotView
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
            this.mandlebrotPanel = new Mandlebrot.MandlebrotPanel();
            this.SuspendLayout();
            // 
            // mandlebrotPanel
            // 
            this.mandlebrotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mandlebrotPanel.Location = new System.Drawing.Point(0, 0);
            this.mandlebrotPanel.Name = "mandlebrotPanel";
            this.mandlebrotPanel.Size = new System.Drawing.Size(800, 450);
            this.mandlebrotPanel.TabIndex = 0;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mandlebrotPanel);
            this.DoubleBuffered = true;
            this.Name = "Display";
            this.Text = "Display";
            this.ResumeLayout(false);

        }

        #endregion

        private Mandlebrot.MandlebrotPanel mandlebrotPanel;
    }
}