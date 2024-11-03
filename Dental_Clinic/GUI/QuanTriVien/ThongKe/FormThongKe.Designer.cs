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
            panel1 = new Panel();
            label1 = new Label();
            vbThongKeDoanhThu = new CustomButton.VBButton();
            pictureBox5 = new PictureBox();
            pictureBox1 = new PictureBox();
            vbThongKeBenh = new CustomButton.VBButton();
            panelThongKe = new Panel();
            dtpNgay = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(172, 46);
            label1.TabIndex = 0;
            label1.Text = "Thống Kê";
            // 
            // vbThongKeDoanhThu
            // 
            vbThongKeDoanhThu.BackColor = Color.FromArgb(163, 211, 229);
            vbThongKeDoanhThu.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThongKeDoanhThu.BorderColor = Color.PaleVioletRed;
            vbThongKeDoanhThu.BorderRadius = 10;
            vbThongKeDoanhThu.BorderSize = 0;
            vbThongKeDoanhThu.Cursor = Cursors.Hand;
            vbThongKeDoanhThu.FlatAppearance.BorderSize = 0;
            vbThongKeDoanhThu.FlatStyle = FlatStyle.Flat;
            vbThongKeDoanhThu.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThongKeDoanhThu.ForeColor = Color.White;
            vbThongKeDoanhThu.Location = new Point(17, 103);
            vbThongKeDoanhThu.Name = "vbThongKeDoanhThu";
            vbThongKeDoanhThu.Size = new Size(271, 57);
            vbThongKeDoanhThu.TabIndex = 11;
            vbThongKeDoanhThu.Text = "Thống kê doanh thu";
            vbThongKeDoanhThu.TextAlign = ContentAlignment.MiddleLeft;
            vbThongKeDoanhThu.TextColor = Color.White;
            vbThongKeDoanhThu.UseVisualStyleBackColor = false;
            vbThongKeDoanhThu.Click += vbThongKeDoanhThu_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(241, 116);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(37, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox1.Image = Resources.icons8_disease_32;
            pictureBox1.Location = new Point(537, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // vbThongKeBenh
            // 
            vbThongKeBenh.BackColor = Color.FromArgb(163, 211, 229);
            vbThongKeBenh.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThongKeBenh.BorderColor = Color.PaleVioletRed;
            vbThongKeBenh.BorderRadius = 10;
            vbThongKeBenh.BorderSize = 0;
            vbThongKeBenh.Cursor = Cursors.Hand;
            vbThongKeBenh.FlatAppearance.BorderSize = 0;
            vbThongKeBenh.FlatStyle = FlatStyle.Flat;
            vbThongKeBenh.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThongKeBenh.ForeColor = Color.White;
            vbThongKeBenh.Location = new Point(322, 103);
            vbThongKeBenh.Name = "vbThongKeBenh";
            vbThongKeBenh.Size = new Size(261, 57);
            vbThongKeBenh.TabIndex = 13;
            vbThongKeBenh.Text = "Thống kê mặt bệnh";
            vbThongKeBenh.TextAlign = ContentAlignment.MiddleLeft;
            vbThongKeBenh.TextColor = Color.White;
            vbThongKeBenh.UseVisualStyleBackColor = false;
            vbThongKeBenh.Click += vbThongKeBenh_Click;
            // 
            // panelThongKe
            // 
            panelThongKe.Location = new Point(7, 202);
            panelThongKe.Name = "panelThongKe";
            panelThongKe.Size = new Size(1012, 454);
            panelThongKe.TabIndex = 18;
            // 
            // dtpNgay
            // 
            dtpNgay.Location = new Point(740, 120);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(250, 27);
            dtpNgay.TabIndex = 19;
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(dtpNgay);
            Controls.Add(panelThongKe);
            Controls.Add(pictureBox1);
            Controls.Add(vbThongKeBenh);
            Controls.Add(pictureBox5);
            Controls.Add(vbThongKeDoanhThu);
            Controls.Add(panel1);
            Name = "FormThongKe";
            Text = "BusinessStatisticsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CustomButton.VBButton vbThongKeDoanhThu;
        private PictureBox pictureBox5;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbThongKeBenh;
        private Panel panelThongKe;
        private DateTimePicker dtpNgay;
    }
}