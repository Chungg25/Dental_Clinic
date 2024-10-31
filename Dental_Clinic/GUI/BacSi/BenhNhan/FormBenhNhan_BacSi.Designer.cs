using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.BacSi.BenhNhan
{
    partial class FormBenhNhan_BacSi
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
            pnTop = new Panel();
            pnLine = new Panel();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            panelBenhNhan = new Panel();
            pictureBox7 = new PictureBox();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbThemBenhNhan = new CustomButton.VBButton();
            vbBenhNhan = new CustomButton.VBButton();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // pnTop
            // 
            pnTop.Controls.Add(pnLine);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 19;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(60, 70);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1210, 2);
            pnLine.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(60, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(626, 54);
            label1.TabIndex = 0;
            label1.Text = "Trang Chủ / Quản Lý Bệnh Nhân";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox5.Image = Resources.icons8_tooth_50;
            pictureBox5.Location = new Point(221, 116);
            pictureBox5.Margin = new Padding(4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(45, 45);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // panelBenhNhan
            // 
            panelBenhNhan.Location = new Point(13, 216);
            panelBenhNhan.Margin = new Padding(4);
            panelBenhNhan.Name = "panelBenhNhan";
            panelBenhNhan.Size = new Size(1228, 601);
            panelBenhNhan.TabIndex = 26;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox7.Image = Resources.icons8_plus_50;
            pictureBox7.Location = new Point(577, 116);
            pictureBox7.Margin = new Padding(4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(45, 45);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 21;
            pictureBox7.TabStop = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(754, 125);
            tbTimKiem.Margin = new Padding(4);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(503, 24);
            tbTimKiem.TabIndex = 22;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(701, 117);
            pictureBox8.Margin = new Padding(4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(45, 44);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 23;
            pictureBox8.TabStop = false;
            // 
            // vbTimKiem
            // 
            vbTimKiem.BackColor = SystemColors.ButtonFace;
            vbTimKiem.BackgroundColor = SystemColors.ButtonFace;
            vbTimKiem.BorderColor = Color.PaleVioletRed;
            vbTimKiem.BorderRadius = 14;
            vbTimKiem.BorderSize = 0;
            vbTimKiem.FlatAppearance.BorderSize = 0;
            vbTimKiem.FlatStyle = FlatStyle.Flat;
            vbTimKiem.ForeColor = Color.White;
            vbTimKiem.Location = new Point(685, 105);
            vbTimKiem.Margin = new Padding(4);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(572, 64);
            vbTimKiem.TabIndex = 25;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbThemBenhNhan
            // 
            vbThemBenhNhan.BackColor = Color.FromArgb(163, 211, 229);
            vbThemBenhNhan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThemBenhNhan.BorderColor = Color.PaleVioletRed;
            vbThemBenhNhan.BorderRadius = 14;
            vbThemBenhNhan.BorderSize = 0;
            vbThemBenhNhan.Cursor = Cursors.Hand;
            vbThemBenhNhan.FlatAppearance.BorderSize = 0;
            vbThemBenhNhan.FlatStyle = FlatStyle.Flat;
            vbThemBenhNhan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThemBenhNhan.ForeColor = Color.White;
            vbThemBenhNhan.Location = new Point(341, 105);
            vbThemBenhNhan.Margin = new Padding(4);
            vbThemBenhNhan.Name = "vbThemBenhNhan";
            vbThemBenhNhan.Size = new Size(301, 64);
            vbThemBenhNhan.TabIndex = 24;
            vbThemBenhNhan.Text = "Thêm bệnh nhân";
            vbThemBenhNhan.TextAlign = ContentAlignment.MiddleLeft;
            vbThemBenhNhan.TextColor = Color.White;
            vbThemBenhNhan.UseVisualStyleBackColor = false;
            // 
            // vbBenhNhan
            // 
            vbBenhNhan.BackColor = Color.FromArgb(163, 211, 229);
            vbBenhNhan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbBenhNhan.BorderColor = Color.PaleVioletRed;
            vbBenhNhan.BorderRadius = 14;
            vbBenhNhan.BorderSize = 0;
            vbBenhNhan.Cursor = Cursors.Hand;
            vbBenhNhan.FlatAppearance.BorderSize = 0;
            vbBenhNhan.FlatStyle = FlatStyle.Flat;
            vbBenhNhan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBenhNhan.ForeColor = Color.White;
            vbBenhNhan.Location = new Point(60, 105);
            vbBenhNhan.Margin = new Padding(4);
            vbBenhNhan.Name = "vbBenhNhan";
            vbBenhNhan.Size = new Size(232, 64);
            vbBenhNhan.TabIndex = 20;
            vbBenhNhan.Text = "Bệnh nhân";
            vbBenhNhan.TextAlign = ContentAlignment.MiddleLeft;
            vbBenhNhan.TextColor = Color.White;
            vbBenhNhan.UseVisualStyleBackColor = false;
            // 
            // FormBenhNhan_BacSi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(pictureBox5);
            Controls.Add(panelBenhNhan);
            Controls.Add(pictureBox7);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbThemBenhNhan);
            Controls.Add(vbBenhNhan);
            Name = "FormBenhNhan_BacSi";
            Text = "FormBenhNhan";
            Load += FormBenhNhan_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnTop;
        private Label label1;
        private PictureBox pictureBox5;
        private Panel panelBenhNhan;
        private PictureBox pictureBox7;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbThemBenhNhan;
        private CustomButton.VBButton vbBenhNhan;
        private Panel pnLine;
    }
}