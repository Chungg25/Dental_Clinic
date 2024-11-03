using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator.User
{
    partial class FormLeTan
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
            panel1 = new Panel();
            label1 = new Label();
            tbTimKiem = new TextBox();
            pictureBox7 = new PictureBox();
            pictureBox3 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbLeTan = new CustomButton.VBButton();
            vbThemLeTan = new CustomButton.VBButton();
            panelLeTan = new Panel();
            pictureBox8 = new PictureBox();
            pictureBox1 = new PictureBox();
            vbBacSi = new CustomButton.VBButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(258, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Lễ Tân";
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(790, 116);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 20);
            tbTimKiem.TabIndex = 15;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox7.Image = Resources.icons8_plus_50;
            pictureBox7.Location = new Point(629, 108);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(47, 47);
            pictureBox7.TabIndex = 17;
            pictureBox7.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox3.Image = Resources.icons8_reception_30;
            pictureBox3.Location = new Point(330, 116);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 32);
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // vbTimKiem
            // 
            vbTimKiem.BackColor = SystemColors.ButtonFace;
            vbTimKiem.BackgroundColor = SystemColors.ButtonFace;
            vbTimKiem.BorderColor = Color.PaleVioletRed;
            vbTimKiem.BorderRadius = 10;
            vbTimKiem.BorderSize = 0;
            vbTimKiem.FlatAppearance.BorderSize = 0;
            vbTimKiem.FlatStyle = FlatStyle.Flat;
            vbTimKiem.ForeColor = Color.White;
            vbTimKiem.Location = new Point(726, 103);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(278, 57);
            vbTimKiem.TabIndex = 28;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbLeTan
            // 
            vbLeTan.BackColor = Color.FromArgb(163, 211, 229);
            vbLeTan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbLeTan.BorderColor = Color.PaleVioletRed;
            vbLeTan.BorderRadius = 10;
            vbLeTan.BorderSize = 0;
            vbLeTan.FlatAppearance.BorderSize = 0;
            vbLeTan.FlatStyle = FlatStyle.Flat;
            vbLeTan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbLeTan.ForeColor = Color.White;
            vbLeTan.Location = new Point(234, 103);
            vbLeTan.Name = "vbLeTan";
            vbLeTan.Size = new Size(149, 57);
            vbLeTan.TabIndex = 25;
            vbLeTan.Text = "Lễ tân";
            vbLeTan.TextAlign = ContentAlignment.MiddleLeft;
            vbLeTan.TextColor = Color.White;
            vbLeTan.UseVisualStyleBackColor = false;
            vbLeTan.Click += vbLeTan_Click;
            // 
            // vbThemLeTan
            // 
            vbThemLeTan.BackColor = Color.FromArgb(163, 211, 229);
            vbThemLeTan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThemLeTan.BorderColor = Color.PaleVioletRed;
            vbThemLeTan.BorderRadius = 8;
            vbThemLeTan.BorderSize = 0;
            vbThemLeTan.FlatAppearance.BorderSize = 0;
            vbThemLeTan.FlatStyle = FlatStyle.Flat;
            vbThemLeTan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThemLeTan.ForeColor = Color.White;
            vbThemLeTan.Location = new Point(493, 103);
            vbThemLeTan.Name = "vbThemLeTan";
            vbThemLeTan.Size = new Size(199, 57);
            vbThemLeTan.TabIndex = 21;
            vbThemLeTan.Text = "Thêm lễ tân";
            vbThemLeTan.TextAlign = ContentAlignment.MiddleLeft;
            vbThemLeTan.TextColor = Color.White;
            vbThemLeTan.UseVisualStyleBackColor = false;
            vbThemLeTan.Click += vbThemLeTan_Click;
            // 
            // panelLeTan
            // 
            panelLeTan.Location = new Point(7, 202);
            panelLeTan.Name = "panelLeTan";
            panelLeTan.Size = new Size(1236, 454);
            panelLeTan.TabIndex = 32;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(740, 110);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(44, 45);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 35;
            pictureBox8.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox1.Image = Resources.icons8_doctor_50__2_;
            pictureBox1.Location = new Point(128, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // vbBacSi
            // 
            vbBacSi.BackColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BorderColor = Color.PaleVioletRed;
            vbBacSi.BorderRadius = 10;
            vbBacSi.BorderSize = 0;
            vbBacSi.Cursor = Cursors.Hand;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBacSi.ForeColor = Color.White;
            vbBacSi.Location = new Point(32, 102);
            vbBacSi.Name = "vbBacSi";
            vbBacSi.Size = new Size(154, 57);
            vbBacSi.TabIndex = 37;
            vbBacSi.Text = "Bác sĩ";
            vbBacSi.TextAlign = ContentAlignment.MiddleLeft;
            vbBacSi.TextColor = Color.White;
            vbBacSi.UseVisualStyleBackColor = false;
            vbBacSi.Click += vbBacSi_Click;
            // 
            // FormLeTan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox1);
            Controls.Add(vbBacSi);
            Controls.Add(pictureBox8);
            Controls.Add(panelLeTan);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox3);
            Controls.Add(vbTimKiem);
            Controls.Add(vbLeTan);
            Controls.Add(vbThemLeTan);
            Controls.Add(panel1);
            Name = "FormLeTan";
            Text = "PatientForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox tbTimKiem;
        private PictureBox pictureBox7;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbLeTan;
        private CustomButton.VBButton vbBacSi;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbThemLeTan;
        private Panel panelLeTan;
    }
}