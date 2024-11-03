using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class FormBenhNhan
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
            pictureBox7 = new PictureBox();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbThemBenhNhan = new CustomButton.VBButton();
            panelBenhNhan = new Panel();
            vbBenhNhan = new CustomButton.VBButton();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            label1.Size = new Size(334, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Bệnh Nhân";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox7.Image = Resources.icons8_plus_50;
            pictureBox7.Location = new Point(626, 107);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(47, 47);
            pictureBox7.TabIndex = 12;
            pictureBox7.TabStop = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(797, 116);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(183, 20);
            tbTimKiem.TabIndex = 13;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(740, 110);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(44, 45);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 14;
            pictureBox8.TabStop = false;
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
            vbTimKiem.TabIndex = 16;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbThemBenhNhan
            // 
            vbThemBenhNhan.BackColor = Color.FromArgb(163, 211, 229);
            vbThemBenhNhan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThemBenhNhan.BorderColor = Color.PaleVioletRed;
            vbThemBenhNhan.BorderRadius = 8;
            vbThemBenhNhan.BorderSize = 0;
            vbThemBenhNhan.Cursor = Cursors.Hand;
            vbThemBenhNhan.FlatAppearance.BorderSize = 0;
            vbThemBenhNhan.FlatStyle = FlatStyle.Flat;
            vbThemBenhNhan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThemBenhNhan.ForeColor = Color.White;
            vbThemBenhNhan.Location = new Point(437, 103);
            vbThemBenhNhan.Name = "vbThemBenhNhan";
            vbThemBenhNhan.Size = new Size(241, 57);
            vbThemBenhNhan.TabIndex = 15;
            vbThemBenhNhan.Text = "Thêm bệnh nhân";
            vbThemBenhNhan.TextAlign = ContentAlignment.MiddleLeft;
            vbThemBenhNhan.TextColor = Color.White;
            vbThemBenhNhan.UseVisualStyleBackColor = false;
            vbThemBenhNhan.Click += vbThemBenhNhan_Click;
            // 
            // panelBenhNhan
            // 
            panelBenhNhan.Location = new Point(7, 202);
            panelBenhNhan.Name = "panelBenhNhan";
            panelBenhNhan.Size = new Size(1137, 454);
            panelBenhNhan.TabIndex = 17;
            // 
            // vbBenhNhan
            // 
            vbBenhNhan.BackColor = Color.FromArgb(163, 211, 229);
            vbBenhNhan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbBenhNhan.BorderColor = Color.PaleVioletRed;
            vbBenhNhan.BorderRadius = 10;
            vbBenhNhan.BorderSize = 0;
            vbBenhNhan.Cursor = Cursors.Hand;
            vbBenhNhan.FlatAppearance.BorderSize = 0;
            vbBenhNhan.FlatStyle = FlatStyle.Flat;
            vbBenhNhan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBenhNhan.ForeColor = Color.White;
            vbBenhNhan.Location = new Point(32, 103);
            vbBenhNhan.Name = "vbBenhNhan";
            vbBenhNhan.Size = new Size(186, 57);
            vbBenhNhan.TabIndex = 9;
            vbBenhNhan.Text = "Bệnh nhân";
            vbBenhNhan.TextAlign = ContentAlignment.MiddleLeft;
            vbBenhNhan.TextColor = Color.White;
            vbBenhNhan.UseVisualStyleBackColor = false;
            vbBenhNhan.Click += vbBenhNhan_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox5.Image = Resources.icons8_tooth_50;
            pictureBox5.Location = new Point(164, 116);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(37, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // FormBenhNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pictureBox5);
            Controls.Add(panelBenhNhan);
            Controls.Add(pictureBox7);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbThemBenhNhan);
            Controls.Add(panel1);
            Controls.Add(vbBenhNhan);
            Name = "FormBenhNhan";
            Text = "PatientForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox7;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbThemBenhNhan;
        private Panel panelBenhNhan;
        private CustomButton.VBButton vbBenhNhan;
        private PictureBox pictureBox5;
    }
}