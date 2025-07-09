using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class FormThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKe));
            vbThongKeDoanhThu = new CustomButton.VBButton();
            pictureBox5 = new PictureBox();
            pictureBox1 = new PictureBox();
            vbThongKeBenh = new CustomButton.VBButton();
            panelThongKe = new Panel();
            dtpNgay = new DateTimePicker();
            pnTop = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // vbThongKeDoanhThu
            // 
            vbThongKeDoanhThu.BackColor = Color.DarkBlue;
            vbThongKeDoanhThu.BackgroundColor = Color.DarkBlue;
            vbThongKeDoanhThu.BorderColor = Color.PaleVioletRed;
            vbThongKeDoanhThu.BorderRadius = 14;
            vbThongKeDoanhThu.BorderSize = 0;
            vbThongKeDoanhThu.Cursor = Cursors.Hand;
            vbThongKeDoanhThu.FlatAppearance.BorderSize = 0;
            vbThongKeDoanhThu.FlatStyle = FlatStyle.Flat;
            vbThongKeDoanhThu.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbThongKeDoanhThu.ForeColor = Color.White;
            vbThongKeDoanhThu.Location = new Point(40, 98);
            vbThongKeDoanhThu.Margin = new Padding(4, 4, 4, 4);
            vbThongKeDoanhThu.Name = "vbThongKeDoanhThu";
            vbThongKeDoanhThu.Size = new Size(339, 71);
            vbThongKeDoanhThu.TabIndex = 11;
            vbThongKeDoanhThu.Text = "Thống kê doanh thu";
            vbThongKeDoanhThu.TextAlign = ContentAlignment.MiddleLeft;
            vbThongKeDoanhThu.TextColor = Color.White;
            vbThongKeDoanhThu.UseVisualStyleBackColor = false;
            vbThongKeDoanhThu.Click += vbThongKeDoanhThu_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.DarkBlue;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(310, 111);
            pictureBox5.Margin = new Padding(4, 4, 4, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(45, 45);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkBlue;
            pictureBox1.Image = Resources.icons8_disease_32;
            pictureBox1.Location = new Point(690, 111);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // vbThongKeBenh
            // 
            vbThongKeBenh.BackColor = Color.DarkBlue;
            vbThongKeBenh.BackgroundColor = Color.DarkBlue;
            vbThongKeBenh.BorderColor = Color.PaleVioletRed;
            vbThongKeBenh.BorderRadius = 14;
            vbThongKeBenh.BorderSize = 0;
            vbThongKeBenh.Cursor = Cursors.Hand;
            vbThongKeBenh.FlatAppearance.BorderSize = 0;
            vbThongKeBenh.FlatStyle = FlatStyle.Flat;
            vbThongKeBenh.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbThongKeBenh.ForeColor = Color.White;
            vbThongKeBenh.Location = new Point(421, 98);
            vbThongKeBenh.Margin = new Padding(4, 4, 4, 4);
            vbThongKeBenh.Name = "vbThongKeBenh";
            vbThongKeBenh.Size = new Size(326, 71);
            vbThongKeBenh.TabIndex = 13;
            vbThongKeBenh.Text = "Thống kê mặt bệnh";
            vbThongKeBenh.TextAlign = ContentAlignment.MiddleLeft;
            vbThongKeBenh.TextColor = Color.White;
            vbThongKeBenh.UseVisualStyleBackColor = false;
            vbThongKeBenh.Click += vbThongKeBenh_Click;
            // 
            // panelThongKe
            // 
            panelThongKe.Location = new Point(40, 204);
            panelThongKe.Margin = new Padding(4, 4, 4, 4);
            panelThongKe.Name = "panelThongKe";
            panelThongKe.Size = new Size(1187, 588);
            panelThongKe.TabIndex = 18;
            // 
            // dtpNgay
            // 
            dtpNgay.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgay.Location = new Point(845, 117);
            dtpNgay.Margin = new Padding(4, 4, 4, 4);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(382, 37);
            dtpNgay.TabIndex = 19;
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
            pnTop.TabIndex = 35;
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
            label1.Size = new Size(202, 54);
            label1.TabIndex = 0;
            label1.Text = "Thống Kê";
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(dtpNgay);
            Controls.Add(panelThongKe);
            Controls.Add(pictureBox1);
            Controls.Add(vbThongKeBenh);
            Controls.Add(pictureBox5);
            Controls.Add(vbThongKeDoanhThu);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormThongKe";
            Text = "BusinessStatisticsForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CustomButton.VBButton vbThongKeDoanhThu;
        private PictureBox pictureBox5;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbThongKeBenh;
        private Panel panelThongKe;
        private DateTimePicker dtpNgay;
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}