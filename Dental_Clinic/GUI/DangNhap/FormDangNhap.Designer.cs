﻿using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Login
{
    partial class FormDangNhap
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            lbQuenMatKhau = new Label();
            pbHienMatKhau = new PictureBox();
            tbTenDangNhap = new TextBox();
            tbMatKhau = new TextBox();
            imageList1 = new ImageList(components);
            vbDangNhap = new CustomButton.VBButton();
            lbSai = new Label();
            pbFaceID = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHienMatKhau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFaceID).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(169, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(177, 107);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(165, 146);
            label1.Name = "label1";
            label1.Size = new Size(194, 46);
            label1.TabIndex = 3;
            label1.Text = "Đăng nhập";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 89, 253);
            panel1.Location = new Point(68, 275);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 3);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_user_60;
            pictureBox1.Location = new Point(68, 220);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Resources.icons8_password_52;
            pictureBox3.Location = new Point(68, 321);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 89, 253);
            panel3.Location = new Point(68, 374);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 3);
            panel3.TabIndex = 8;
            // 
            // lbQuenMatKhau
            // 
            lbQuenMatKhau.AutoSize = true;
            lbQuenMatKhau.Cursor = Cursors.Hand;
            lbQuenMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbQuenMatKhau.ForeColor = Color.Black;
            lbQuenMatKhau.Location = new Point(338, 393);
            lbQuenMatKhau.Name = "lbQuenMatKhau";
            lbQuenMatKhau.Size = new Size(109, 20);
            lbQuenMatKhau.TabIndex = 10;
            lbQuenMatKhau.Text = "Quên mật khẩu";
            lbQuenMatKhau.TextAlign = ContentAlignment.MiddleCenter;
            lbQuenMatKhau.Click += lbQuenMatKhau_Click;
            // 
            // pbHienMatKhau
            // 
            pbHienMatKhau.Image = Resources.icons8_invisible_48;
            pbHienMatKhau.Location = new Point(368, 332);
            pbHienMatKhau.Name = "pbHienMatKhau";
            pbHienMatKhau.Size = new Size(48, 33);
            pbHienMatKhau.SizeMode = PictureBoxSizeMode.Zoom;
            pbHienMatKhau.TabIndex = 11;
            pbHienMatKhau.TabStop = false;
            pbHienMatKhau.Click += pbHienMatKhau_Click;
            // 
            // tbTenDangNhap
            // 
            tbTenDangNhap.BorderStyle = BorderStyle.None;
            tbTenDangNhap.Cursor = Cursors.IBeam;
            tbTenDangNhap.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbTenDangNhap.Location = new Point(135, 233);
            tbTenDangNhap.Name = "tbTenDangNhap";
            tbTenDangNhap.Size = new Size(281, 31);
            tbTenDangNhap.TabIndex = 12;
            // 
            // tbMatKhau
            // 
            tbMatKhau.BorderStyle = BorderStyle.None;
            tbMatKhau.Cursor = Cursors.IBeam;
            tbMatKhau.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbMatKhau.Location = new Point(126, 334);
            tbMatKhau.Name = "tbMatKhau";
            tbMatKhau.Size = new Size(236, 31);
            tbMatKhau.TabIndex = 13;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // vbDangNhap
            // 
            vbDangNhap.BackColor = SystemColors.Highlight;
            vbDangNhap.BackgroundColor = SystemColors.Highlight;
            vbDangNhap.BorderColor = Color.PaleVioletRed;
            vbDangNhap.BorderRadius = 20;
            vbDangNhap.BorderSize = 0;
            vbDangNhap.Cursor = Cursors.Hand;
            vbDangNhap.FlatAppearance.BorderSize = 0;
            vbDangNhap.FlatStyle = FlatStyle.Flat;
            vbDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbDangNhap.ForeColor = Color.White;
            vbDangNhap.Location = new Point(68, 430);
            vbDangNhap.Name = "vbDangNhap";
            vbDangNhap.Size = new Size(261, 53);
            vbDangNhap.TabIndex = 15;
            vbDangNhap.Text = "Đăng Nhập";
            vbDangNhap.TextColor = Color.White;
            vbDangNhap.UseVisualStyleBackColor = false;
            vbDangNhap.Click += vbDangNhap_Click;
            // 
            // lbSai
            // 
            lbSai.AutoSize = true;
            lbSai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSai.Location = new Point(126, 511);
            lbSai.Name = "lbSai";
            lbSai.Size = new Size(263, 23);
            lbSai.TabIndex = 16;
            lbSai.Text = "Sai tài khoản hoặc sai mật khẩu";
            // 
            // pbFaceID
            // 
            pbFaceID.Image = Resources.icons8_face_scan_50;
            pbFaceID.Location = new Point(347, 430);
            pbFaceID.Name = "pbFaceID";
            pbFaceID.Size = new Size(69, 53);
            pbFaceID.SizeMode = PictureBoxSizeMode.Zoom;
            pbFaceID.TabIndex = 17;
            pbFaceID.TabStop = false;
            pbFaceID.Click += pbFaceID_Click;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(484, 543);
            Controls.Add(pbFaceID);
            Controls.Add(lbSai);
            Controls.Add(vbDangNhap);
            Controls.Add(tbMatKhau);
            Controls.Add(tbTenDangNhap);
            Controls.Add(pbHienMatKhau);
            Controls.Add(lbQuenMatKhau);
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHienMatKhau).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFaceID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel panel3;
        private Label lbQuenMatKhau;
        private PictureBox pbHienMatKhau;
        private TextBox tbTenDangNhap;
        private TextBox tbMatKhau;
        private ImageList imageList1;
        private CustomButton.VBButton vbDangNhap;
        private Label lbSai;
        private PictureBox pbFaceID;
    }
}