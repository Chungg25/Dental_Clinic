using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.QuanTriVien.VatTu
{
    partial class FormChinhSuaDichVu
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
            pbQuayVe = new PictureBox();
            panelDuLieu = new Panel();
            vbHuy = new CustomButton.VBButton();
            vbLuuThayDoi = new CustomButton.VBButton();
            tbGia = new TextBox();
            tbLoaiThuoc = new TextBox();
            label3 = new Label();
            vbLoaiThuoc = new CustomButton.VBButton();
            tbDonViTinh = new TextBox();
            label6 = new Label();
            vbDonViTinh = new CustomButton.VBButton();
            tbThuoc = new TextBox();
            label2 = new Label();
            vbThuoc = new CustomButton.VBButton();
            label5 = new Label();
            vbButton5 = new CustomButton.VBButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).BeginInit();
            panelDuLieu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(486, 46);
            label1.TabIndex = 0;
            label1.Text = "Chỉnh Sửa Thông Tin Dịch Vụ";
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(12, 82);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(70, 39);
            pbQuayVe.SizeMode = PictureBoxSizeMode.Zoom;
            pbQuayVe.TabIndex = 82;
            pbQuayVe.TabStop = false;
            pbQuayVe.Click += pbQuayVe_Click;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Controls.Add(vbHuy);
            panelDuLieu.Controls.Add(vbLuuThayDoi);
            panelDuLieu.Controls.Add(tbGia);
            panelDuLieu.Controls.Add(tbLoaiThuoc);
            panelDuLieu.Controls.Add(label3);
            panelDuLieu.Controls.Add(vbLoaiThuoc);
            panelDuLieu.Controls.Add(tbDonViTinh);
            panelDuLieu.Controls.Add(label6);
            panelDuLieu.Controls.Add(vbDonViTinh);
            panelDuLieu.Controls.Add(tbThuoc);
            panelDuLieu.Controls.Add(label2);
            panelDuLieu.Controls.Add(vbThuoc);
            panelDuLieu.Controls.Add(label5);
            panelDuLieu.Controls.Add(vbButton5);
            panelDuLieu.Location = new Point(88, 136);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(841, 493);
            panelDuLieu.TabIndex = 81;
            // 
            // vbHuy
            // 
            vbHuy.BackColor = Color.FromArgb(108, 117, 125);
            vbHuy.BackgroundColor = Color.FromArgb(108, 117, 125);
            vbHuy.BorderColor = Color.PaleVioletRed;
            vbHuy.BorderRadius = 10;
            vbHuy.BorderSize = 0;
            vbHuy.Cursor = Cursors.Hand;
            vbHuy.FlatAppearance.BorderSize = 0;
            vbHuy.FlatStyle = FlatStyle.Flat;
            vbHuy.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbHuy.ForeColor = Color.White;
            vbHuy.Location = new Point(444, 332);
            vbHuy.Name = "vbHuy";
            vbHuy.Size = new Size(87, 50);
            vbHuy.TabIndex = 153;
            vbHuy.Text = "Hủy";
            vbHuy.TextColor = Color.White;
            vbHuy.UseVisualStyleBackColor = false;
            vbHuy.Click += vbHuy_Click_1;
            // 
            // vbLuuThayDoi
            // 
            vbLuuThayDoi.BackColor = Color.FromArgb(220, 53, 69);
            vbLuuThayDoi.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbLuuThayDoi.BorderColor = Color.PaleVioletRed;
            vbLuuThayDoi.BorderRadius = 10;
            vbLuuThayDoi.BorderSize = 0;
            vbLuuThayDoi.Cursor = Cursors.Hand;
            vbLuuThayDoi.FlatAppearance.BorderSize = 0;
            vbLuuThayDoi.FlatStyle = FlatStyle.Flat;
            vbLuuThayDoi.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbLuuThayDoi.ForeColor = Color.White;
            vbLuuThayDoi.Location = new Point(279, 332);
            vbLuuThayDoi.Name = "vbLuuThayDoi";
            vbLuuThayDoi.Size = new Size(144, 50);
            vbLuuThayDoi.TabIndex = 152;
            vbLuuThayDoi.Text = "Lưu Thay Đổi";
            vbLuuThayDoi.TextColor = Color.White;
            vbLuuThayDoi.UseVisualStyleBackColor = false;
            vbLuuThayDoi.Click += vbLuuThayDoi_Click;
            // 
            // tbGia
            // 
            tbGia.Location = new Point(556, 226);
            tbGia.Name = "tbGia";
            tbGia.Size = new Size(135, 27);
            tbGia.TabIndex = 142;
            // 
            // tbLoaiThuoc
            // 
            tbLoaiThuoc.Location = new Point(556, 106);
            tbLoaiThuoc.Name = "tbLoaiThuoc";
            tbLoaiThuoc.Size = new Size(135, 27);
            tbLoaiThuoc.TabIndex = 138;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(546, 65);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 137;
            label3.Text = "Loại dịch vụ";
            // 
            // vbLoaiThuoc
            // 
            vbLoaiThuoc.BackColor = Color.White;
            vbLoaiThuoc.BackgroundColor = Color.White;
            vbLoaiThuoc.BorderColor = Color.Black;
            vbLoaiThuoc.BorderRadius = 8;
            vbLoaiThuoc.BorderSize = 1;
            vbLoaiThuoc.FlatAppearance.BorderSize = 0;
            vbLoaiThuoc.FlatStyle = FlatStyle.Flat;
            vbLoaiThuoc.ForeColor = Color.White;
            vbLoaiThuoc.Location = new Point(546, 98);
            vbLoaiThuoc.Name = "vbLoaiThuoc";
            vbLoaiThuoc.Size = new Size(154, 38);
            vbLoaiThuoc.TabIndex = 136;
            vbLoaiThuoc.Text = "vbButton1";
            vbLoaiThuoc.TextColor = Color.White;
            vbLoaiThuoc.UseVisualStyleBackColor = false;
            // 
            // tbDonViTinh
            // 
            tbDonViTinh.Location = new Point(154, 226);
            tbDonViTinh.Name = "tbDonViTinh";
            tbDonViTinh.Size = new Size(135, 27);
            tbDonViTinh.TabIndex = 132;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(546, 181);
            label6.Name = "label6";
            label6.Size = new Size(31, 20);
            label6.TabIndex = 131;
            label6.Text = "Giá";
            // 
            // vbDonViTinh
            // 
            vbDonViTinh.BackColor = Color.White;
            vbDonViTinh.BackgroundColor = Color.White;
            vbDonViTinh.BorderColor = Color.Black;
            vbDonViTinh.BorderRadius = 8;
            vbDonViTinh.BorderSize = 1;
            vbDonViTinh.FlatAppearance.BorderSize = 0;
            vbDonViTinh.FlatStyle = FlatStyle.Flat;
            vbDonViTinh.ForeColor = Color.White;
            vbDonViTinh.Location = new Point(144, 218);
            vbDonViTinh.Name = "vbDonViTinh";
            vbDonViTinh.Size = new Size(154, 38);
            vbDonViTinh.TabIndex = 130;
            vbDonViTinh.Text = "vbButton3";
            vbDonViTinh.TextColor = Color.White;
            vbDonViTinh.UseVisualStyleBackColor = false;
            // 
            // tbThuoc
            // 
            tbThuoc.Location = new Point(154, 106);
            tbThuoc.Name = "tbThuoc";
            tbThuoc.Size = new Size(135, 27);
            tbThuoc.TabIndex = 127;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 64);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 126;
            label2.Text = "Tên dịch vụ";
            // 
            // vbThuoc
            // 
            vbThuoc.BackColor = Color.White;
            vbThuoc.BackgroundColor = Color.White;
            vbThuoc.BorderColor = Color.Black;
            vbThuoc.BorderRadius = 8;
            vbThuoc.BorderSize = 1;
            vbThuoc.FlatAppearance.BorderSize = 0;
            vbThuoc.FlatStyle = FlatStyle.Flat;
            vbThuoc.ForeColor = Color.White;
            vbThuoc.Location = new Point(144, 98);
            vbThuoc.Name = "vbThuoc";
            vbThuoc.Size = new Size(154, 38);
            vbThuoc.TabIndex = 125;
            vbThuoc.Text = "vbButton1";
            vbThuoc.TextColor = Color.White;
            vbThuoc.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(144, 181);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 129;
            label5.Text = "Đơn vị tính";
            // 
            // vbButton5
            // 
            vbButton5.BackColor = Color.White;
            vbButton5.BackgroundColor = Color.White;
            vbButton5.BorderColor = Color.Black;
            vbButton5.BorderRadius = 10;
            vbButton5.BorderSize = 1;
            vbButton5.FlatAppearance.BorderSize = 0;
            vbButton5.FlatStyle = FlatStyle.Flat;
            vbButton5.ForeColor = Color.White;
            vbButton5.Location = new Point(546, 218);
            vbButton5.Name = "vbButton5";
            vbButton5.Size = new Size(154, 38);
            vbButton5.TabIndex = 135;
            vbButton5.Text = "vbGia";
            vbButton5.TextColor = Color.White;
            vbButton5.UseVisualStyleBackColor = false;
            // 
            // FormChinhSuaDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pbQuayVe);
            Controls.Add(panelDuLieu);
            Controls.Add(panel1);
            Name = "FormChinhSuaDichVu";
            Text = "FormChinhSuaDichVu";
            Load += FormChinhSuaDichVu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).EndInit();
            panelDuLieu.ResumeLayout(false);
            panelDuLieu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pbQuayVe;
        private Panel panelDuLieu;
        private CustomButton.VBButton vbHuy;
        private CustomButton.VBButton vbLuuThayDoi;
        private TextBox tbGia;
        private TextBox tbLoaiThuoc;
        private Label label3;
        private CustomButton.VBButton vbLoaiThuoc;
        private TextBox tbDonViTinh;
        private Label label6;
        private CustomButton.VBButton vbDonViTinh;
        private TextBox tbThuoc;
        private Label label2;
        private CustomButton.VBButton vbThuoc;
        private Label label5;
        private CustomButton.VBButton vbButton5;
    }
}