using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class FormQuanLyLuong
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
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            vbLeTan = new CustomButton.VBButton();
            vbBacSi = new CustomButton.VBButton();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            panelDuLieu = new Panel();
            dtpNgay = new DateTimePicker();
            pnTop = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.DarkBlue;
            pictureBox3.Image = Resources.icons8_reception_30;
            pictureBox3.Location = new Point(403, 116);
            pictureBox3.Margin = new Padding(4, 4, 4, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 45);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 35;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkBlue;
            pictureBox1.Image = Resources.icons8_doctor_50__2_;
            pictureBox1.Location = new Point(149, 116);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            // 
            // vbLeTan
            // 
            vbLeTan.BackColor = Color.DarkBlue;
            vbLeTan.BackgroundColor = Color.DarkBlue;
            vbLeTan.BorderColor = Color.PaleVioletRed;
            vbLeTan.BorderRadius = 10;
            vbLeTan.BorderSize = 0;
            vbLeTan.Cursor = Cursors.Hand;
            vbLeTan.FlatAppearance.BorderSize = 0;
            vbLeTan.FlatStyle = FlatStyle.Flat;
            vbLeTan.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbLeTan.ForeColor = Color.White;
            vbLeTan.Location = new Point(287, 100);
            vbLeTan.Margin = new Padding(4, 4, 4, 4);
            vbLeTan.Name = "vbLeTan";
            vbLeTan.Size = new Size(179, 70);
            vbLeTan.TabIndex = 37;
            vbLeTan.Text = "Lễ tân";
            vbLeTan.TextAlign = ContentAlignment.MiddleLeft;
            vbLeTan.TextColor = Color.White;
            vbLeTan.UseVisualStyleBackColor = false;
            vbLeTan.Click += vbLeTan_Click;
            // 
            // vbBacSi
            // 
            vbBacSi.BackColor = Color.DarkBlue;
            vbBacSi.BackgroundColor = Color.DarkBlue;
            vbBacSi.BorderColor = Color.PaleVioletRed;
            vbBacSi.BorderRadius = 7;
            vbBacSi.BorderSize = 0;
            vbBacSi.Cursor = Cursors.Hand;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbBacSi.ForeColor = Color.White;
            vbBacSi.Location = new Point(40, 100);
            vbBacSi.Margin = new Padding(4, 4, 4, 4);
            vbBacSi.Name = "vbBacSi";
            vbBacSi.Size = new Size(179, 70);
            vbBacSi.TabIndex = 36;
            vbBacSi.Text = "Bác sĩ";
            vbBacSi.TextAlign = ContentAlignment.MiddleLeft;
            vbBacSi.TextColor = Color.White;
            vbBacSi.UseVisualStyleBackColor = false;
            vbBacSi.Click += vbBacSi_Click;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(937, 126);
            tbTimKiem.Margin = new Padding(4, 4, 4, 4);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(283, 24);
            tbTimKiem.TabIndex = 38;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(884, 116);
            pictureBox8.Margin = new Padding(4, 4, 4, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(45, 45);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 39;
            pictureBox8.TabStop = false;
            // 
            // vbTimKiem
            // 
            vbTimKiem.BackColor = SystemColors.ButtonFace;
            vbTimKiem.BackgroundColor = SystemColors.ButtonFace;
            vbTimKiem.BorderColor = Color.PaleVioletRed;
            vbTimKiem.BorderRadius = 15;
            vbTimKiem.BorderSize = 0;
            vbTimKiem.FlatAppearance.BorderSize = 0;
            vbTimKiem.FlatStyle = FlatStyle.Flat;
            vbTimKiem.ForeColor = Color.White;
            vbTimKiem.Location = new Point(868, 100);
            vbTimKiem.Margin = new Padding(4, 4, 4, 4);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(366, 70);
            vbTimKiem.TabIndex = 40;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Location = new Point(40, 198);
            panelDuLieu.Margin = new Padding(4, 4, 4, 4);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(1194, 594);
            panelDuLieu.TabIndex = 41;
            // 
            // dtpNgay
            // 
            dtpNgay.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgay.Location = new Point(513, 120);
            dtpNgay.Margin = new Padding(4, 4, 4, 4);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(312, 37);
            dtpNgay.TabIndex = 42;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(panel1);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 43;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(40, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(1278, 2);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(40, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(307, 54);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Lương";
            // 
            // FormQuanLyLuong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(dtpNgay);
            Controls.Add(panelDuLieu);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(vbLeTan);
            Controls.Add(vbBacSi);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormQuanLyLuong";
            Text = "v";
            Load += FormQuanLyLuong_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbLeTan;
        private CustomButton.VBButton vbBacSi;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private Panel panelDuLieu;
        private DateTimePicker dtpNgay;
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}