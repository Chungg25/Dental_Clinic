﻿namespace Dental_Clinic.GUI
{
    partial class Dental_Clinic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dental_Clinic));
            pictureBox1 = new PictureBox();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(604, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(412, 590);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel
            // 
            panel.Location = new Point(1, 1);
            panel.Name = "panel";
            panel.Size = new Size(502, 590);
            panel.TabIndex = 2;
            // 
            // Dental_Clinic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 590);
            Controls.Add(panel);
            Controls.Add(pictureBox1);
            Name = "Dental_Clinic";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dental Clinic";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel;
    }
}