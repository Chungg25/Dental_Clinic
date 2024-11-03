using Dental_Clinic.Properties;
namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    partial class FormThanhToan_ChuyenKhoan
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
            pbQR = new PictureBox();
            vbHuy = new CustomButton.VBButton();
            vbXacNhan = new CustomButton.VBButton();
            ((System.ComponentModel.ISupportInitialize)pbQR).BeginInit();
            SuspendLayout();
            // 
            // pbQR
            // 
            pbQR.Image = Resources.qr;
            pbQR.Location = new Point(125, 12);
            pbQR.Name = "pbQR";
            pbQR.Size = new Size(550, 550);
            pbQR.SizeMode = PictureBoxSizeMode.Zoom;
            pbQR.TabIndex = 0;
            pbQR.TabStop = false;
            // 
            // vbHuy
            // 
            vbHuy.BackColor = Color.FromArgb(108, 117, 125);
            vbHuy.BackgroundColor = Color.FromArgb(108, 117, 125);
            vbHuy.BorderColor = Color.PaleVioletRed;
            vbHuy.BorderRadius = 14;
            vbHuy.BorderSize = 0;
            vbHuy.Cursor = Cursors.Hand;
            vbHuy.FlatAppearance.BorderSize = 0;
            vbHuy.FlatStyle = FlatStyle.Flat;
            vbHuy.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbHuy.ForeColor = Color.White;
            vbHuy.Location = new Point(418, 602);
            vbHuy.Margin = new Padding(4);
            vbHuy.Name = "vbHuy";
            vbHuy.Size = new Size(224, 60);
            vbHuy.TabIndex = 139;
            vbHuy.Text = "Huỷ";
            vbHuy.TextColor = Color.White;
            vbHuy.UseVisualStyleBackColor = false;
            vbHuy.Click += vbHuy_Click;
            // 
            // vbXacNhan
            // 
            vbXacNhan.BackColor = Color.FromArgb(220, 53, 69);
            vbXacNhan.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbXacNhan.BorderColor = Color.PaleVioletRed;
            vbXacNhan.BorderRadius = 10;
            vbXacNhan.BorderSize = 0;
            vbXacNhan.Cursor = Cursors.Hand;
            vbXacNhan.FlatAppearance.BorderSize = 0;
            vbXacNhan.FlatStyle = FlatStyle.Flat;
            vbXacNhan.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            vbXacNhan.ForeColor = Color.White;
            vbXacNhan.Location = new Point(160, 602);
            vbXacNhan.Margin = new Padding(4);
            vbXacNhan.Name = "vbXacNhan";
            vbXacNhan.Size = new Size(224, 60);
            vbXacNhan.TabIndex = 138;
            vbXacNhan.Text = "Xác nhận";
            vbXacNhan.TextColor = Color.White;
            vbXacNhan.UseVisualStyleBackColor = false;
            vbXacNhan.Click += vbXacNhan_Click;
            // 
            // FormThanhToan_ChuyenKhoan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(778, 694);
            Controls.Add(vbHuy);
            Controls.Add(vbXacNhan);
            Controls.Add(pbQR);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormThanhToan_ChuyenKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thanh Toán";
            Load += FormThanhToan_ChuyenKhoan_Load;
            ((System.ComponentModel.ISupportInitialize)pbQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbQR;
        private CustomButton.VBButton vbHuy;
        private CustomButton.VBButton vbXacNhan;
    }
}