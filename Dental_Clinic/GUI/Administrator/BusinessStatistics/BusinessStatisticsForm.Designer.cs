namespace Dental_Clinic.GUI.Administrator
{
    partial class BusinessStatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessStatisticsForm));
            panel1 = new Panel();
            label1 = new Label();
            vbThongKeDoanhThu = new CustomButton.VBButton();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
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
            vbThongKeDoanhThu.Location = new Point(46, 103);
            vbThongKeDoanhThu.Name = "vbThongKeDoanhThu";
            vbThongKeDoanhThu.Size = new Size(271, 57);
            vbThongKeDoanhThu.TabIndex = 11;
            vbThongKeDoanhThu.Text = "Thống kê doanh thu";
            vbThongKeDoanhThu.TextAlign = ContentAlignment.MiddleLeft;
            vbThongKeDoanhThu.TextColor = Color.White;
            vbThongKeDoanhThu.UseVisualStyleBackColor = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(270, 116);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(37, 31);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // BusinessStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pictureBox5);
            Controls.Add(vbThongKeDoanhThu);
            Controls.Add(panel1);
            Name = "BusinessStatisticsForm";
            Text = "BusinessStatisticsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CustomButton.VBButton vbThongKeDoanhThu;
        private PictureBox pictureBox5;
    }
}