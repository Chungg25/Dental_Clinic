using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator.Supplies
{
    partial class FormThemThuoc
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
            cbLoaiThuoc = new ComboBox();
            dtpNgayNhap = new DateTimePicker();
            tbGia = new TextBox();
            dtpNgayHetHan = new DateTimePicker();
            tbSoLuong = new TextBox();
            dtpNgaySanXuat = new DateTimePicker();
            label10 = new Label();
            vbNgayHetHan = new CustomButton.VBButton();
            vbSoLuong = new CustomButton.VBButton();
            label7 = new Label();
            vbNgaySanXuat = new CustomButton.VBButton();
            label3 = new Label();
            label9 = new Label();
            label11 = new Label();
            vbLoaiThuoc = new CustomButton.VBButton();
            vbNgayNhap = new CustomButton.VBButton();
            vbThemThuoc = new CustomButton.VBButton();
            tbLieuLuong = new TextBox();
            vbLieuLuong = new CustomButton.VBButton();
            tbDonViTinh = new TextBox();
            label6 = new Label();
            vbDonViTinh = new CustomButton.VBButton();
            tbThuoc = new TextBox();
            label2 = new Label();
            vbThuoc = new CustomButton.VBButton();
            label5 = new Label();
            label4 = new Label();
            vbGia = new CustomButton.VBButton();
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
            label1.Size = new Size(216, 46);
            label1.TabIndex = 0;
            label1.Text = "Thêm Thuốc";
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(24, 81);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(70, 39);
            pbQuayVe.SizeMode = PictureBoxSizeMode.Zoom;
            pbQuayVe.TabIndex = 50;
            pbQuayVe.TabStop = false;
            pbQuayVe.Click += pbQuayVe_Click;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Controls.Add(cbLoaiThuoc);
            panelDuLieu.Controls.Add(dtpNgayNhap);
            panelDuLieu.Controls.Add(tbGia);
            panelDuLieu.Controls.Add(dtpNgayHetHan);
            panelDuLieu.Controls.Add(tbSoLuong);
            panelDuLieu.Controls.Add(dtpNgaySanXuat);
            panelDuLieu.Controls.Add(label10);
            panelDuLieu.Controls.Add(vbNgayHetHan);
            panelDuLieu.Controls.Add(vbSoLuong);
            panelDuLieu.Controls.Add(label7);
            panelDuLieu.Controls.Add(vbNgaySanXuat);
            panelDuLieu.Controls.Add(label3);
            panelDuLieu.Controls.Add(label9);
            panelDuLieu.Controls.Add(label11);
            panelDuLieu.Controls.Add(vbLoaiThuoc);
            panelDuLieu.Controls.Add(vbNgayNhap);
            panelDuLieu.Controls.Add(vbThemThuoc);
            panelDuLieu.Controls.Add(tbLieuLuong);
            panelDuLieu.Controls.Add(vbLieuLuong);
            panelDuLieu.Controls.Add(tbDonViTinh);
            panelDuLieu.Controls.Add(label6);
            panelDuLieu.Controls.Add(vbDonViTinh);
            panelDuLieu.Controls.Add(tbThuoc);
            panelDuLieu.Controls.Add(label2);
            panelDuLieu.Controls.Add(vbThuoc);
            panelDuLieu.Controls.Add(label5);
            panelDuLieu.Controls.Add(label4);
            panelDuLieu.Controls.Add(vbGia);
            panelDuLieu.Location = new Point(100, 135);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(841, 488);
            panelDuLieu.TabIndex = 49;
            // 
            // cbLoaiThuoc
            // 
            cbLoaiThuoc.FormattingEnabled = true;
            cbLoaiThuoc.Location = new Point(404, 76);
            cbLoaiThuoc.Name = "cbLoaiThuoc";
            cbLoaiThuoc.Size = new Size(136, 28);
            cbLoaiThuoc.TabIndex = 166;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(404, 282);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(135, 27);
            dtpNgayNhap.TabIndex = 165;
            dtpNgayNhap.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // tbGia
            // 
            tbGia.Location = new Point(667, 172);
            tbGia.Name = "tbGia";
            tbGia.Size = new Size(135, 27);
            tbGia.TabIndex = 86;
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Location = new Point(668, 282);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(136, 27);
            dtpNgayHetHan.TabIndex = 164;
            dtpNgayHetHan.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // tbSoLuong
            // 
            tbSoLuong.Location = new Point(667, 77);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(135, 27);
            tbSoLuong.TabIndex = 85;
            // 
            // dtpNgaySanXuat
            // 
            dtpNgaySanXuat.Location = new Point(87, 282);
            dtpNgaySanXuat.Name = "dtpNgaySanXuat";
            dtpNgaySanXuat.Size = new Size(135, 27);
            dtpNgaySanXuat.TabIndex = 163;
            dtpNgaySanXuat.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(657, 36);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 84;
            label10.Text = "Số lượng";
            // 
            // vbNgayHetHan
            // 
            vbNgayHetHan.BackColor = Color.White;
            vbNgayHetHan.BackgroundColor = Color.White;
            vbNgayHetHan.BorderColor = Color.Black;
            vbNgayHetHan.BorderRadius = 8;
            vbNgayHetHan.BorderSize = 1;
            vbNgayHetHan.FlatAppearance.BorderSize = 0;
            vbNgayHetHan.FlatStyle = FlatStyle.Flat;
            vbNgayHetHan.ForeColor = Color.White;
            vbNgayHetHan.Location = new Point(658, 275);
            vbNgayHetHan.Name = "vbNgayHetHan";
            vbNgayHetHan.Size = new Size(155, 38);
            vbNgayHetHan.TabIndex = 161;
            vbNgayHetHan.Text = "vbButton4";
            vbNgayHetHan.TextColor = Color.White;
            vbNgayHetHan.UseVisualStyleBackColor = false;
            // 
            // vbSoLuong
            // 
            vbSoLuong.BackColor = Color.White;
            vbSoLuong.BackgroundColor = Color.White;
            vbSoLuong.BorderColor = Color.Black;
            vbSoLuong.BorderRadius = 8;
            vbSoLuong.BorderSize = 1;
            vbSoLuong.FlatAppearance.BorderSize = 0;
            vbSoLuong.FlatStyle = FlatStyle.Flat;
            vbSoLuong.ForeColor = Color.White;
            vbSoLuong.Location = new Point(657, 69);
            vbSoLuong.Name = "vbSoLuong";
            vbSoLuong.Size = new Size(154, 38);
            vbSoLuong.TabIndex = 83;
            vbSoLuong.Text = "vbButton1";
            vbSoLuong.TextColor = Color.White;
            vbSoLuong.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(394, 238);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 160;
            label7.Text = "Ngày nhập";
            // 
            // vbNgaySanXuat
            // 
            vbNgaySanXuat.BackColor = Color.White;
            vbNgaySanXuat.BackgroundColor = Color.White;
            vbNgaySanXuat.BorderColor = Color.Black;
            vbNgaySanXuat.BorderRadius = 8;
            vbNgaySanXuat.BorderSize = 1;
            vbNgaySanXuat.FlatAppearance.BorderSize = 0;
            vbNgaySanXuat.FlatStyle = FlatStyle.Flat;
            vbNgaySanXuat.ForeColor = Color.White;
            vbNgaySanXuat.Location = new Point(77, 275);
            vbNgaySanXuat.Name = "vbNgaySanXuat";
            vbNgaySanXuat.Size = new Size(154, 38);
            vbNgaySanXuat.TabIndex = 159;
            vbNgaySanXuat.Text = "vbNgaySanXuat";
            vbNgaySanXuat.TextColor = Color.White;
            vbNgaySanXuat.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 36);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 81;
            label3.Text = "Loại thuốc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(77, 238);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 158;
            label9.Text = "Ngày sản xuất";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(658, 238);
            label11.Name = "label11";
            label11.Size = new Size(97, 20);
            label11.TabIndex = 157;
            label11.Text = "Ngày hết hạn";
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
            vbLoaiThuoc.Location = new Point(393, 69);
            vbLoaiThuoc.Name = "vbLoaiThuoc";
            vbLoaiThuoc.Size = new Size(154, 38);
            vbLoaiThuoc.TabIndex = 80;
            vbLoaiThuoc.Text = "vbButton1";
            vbLoaiThuoc.TextColor = Color.White;
            vbLoaiThuoc.UseVisualStyleBackColor = false;
            // 
            // vbNgayNhap
            // 
            vbNgayNhap.BackColor = Color.White;
            vbNgayNhap.BackgroundColor = Color.White;
            vbNgayNhap.BorderColor = Color.Black;
            vbNgayNhap.BorderRadius = 10;
            vbNgayNhap.BorderSize = 1;
            vbNgayNhap.FlatAppearance.BorderSize = 0;
            vbNgayNhap.FlatStyle = FlatStyle.Flat;
            vbNgayNhap.ForeColor = Color.White;
            vbNgayNhap.Location = new Point(394, 275);
            vbNgayNhap.Name = "vbNgayNhap";
            vbNgayNhap.Size = new Size(154, 38);
            vbNgayNhap.TabIndex = 162;
            vbNgayNhap.Text = "vbGia";
            vbNgayNhap.TextColor = Color.White;
            vbNgayNhap.UseVisualStyleBackColor = false;
            // 
            // vbThemThuoc
            // 
            vbThemThuoc.BackColor = Color.FromArgb(220, 53, 69);
            vbThemThuoc.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbThemThuoc.BorderColor = Color.PaleVioletRed;
            vbThemThuoc.BorderRadius = 10;
            vbThemThuoc.BorderSize = 0;
            vbThemThuoc.Cursor = Cursors.Hand;
            vbThemThuoc.FlatAppearance.BorderSize = 0;
            vbThemThuoc.FlatStyle = FlatStyle.Flat;
            vbThemThuoc.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbThemThuoc.ForeColor = Color.White;
            vbThemThuoc.Location = new Point(77, 362);
            vbThemThuoc.Name = "vbThemThuoc";
            vbThemThuoc.Size = new Size(144, 50);
            vbThemThuoc.TabIndex = 78;
            vbThemThuoc.Text = "Thêm thuốc";
            vbThemThuoc.TextColor = Color.White;
            vbThemThuoc.UseVisualStyleBackColor = false;
            vbThemThuoc.Click += vbThemThuoc_Click;
            // 
            // tbLieuLuong
            // 
            tbLieuLuong.Location = new Point(403, 172);
            tbLieuLuong.Name = "tbLieuLuong";
            tbLieuLuong.Size = new Size(135, 27);
            tbLieuLuong.TabIndex = 69;
            // 
            // vbLieuLuong
            // 
            vbLieuLuong.BackColor = Color.White;
            vbLieuLuong.BackgroundColor = Color.White;
            vbLieuLuong.BorderColor = Color.Black;
            vbLieuLuong.BorderRadius = 8;
            vbLieuLuong.BorderSize = 1;
            vbLieuLuong.FlatAppearance.BorderSize = 0;
            vbLieuLuong.FlatStyle = FlatStyle.Flat;
            vbLieuLuong.ForeColor = Color.White;
            vbLieuLuong.Location = new Point(392, 164);
            vbLieuLuong.Name = "vbLieuLuong";
            vbLieuLuong.Size = new Size(155, 38);
            vbLieuLuong.TabIndex = 66;
            vbLieuLuong.Text = "vbButton4";
            vbLieuLuong.TextColor = Color.White;
            vbLieuLuong.UseVisualStyleBackColor = false;
            // 
            // tbDonViTinh
            // 
            tbDonViTinh.Location = new Point(86, 172);
            tbDonViTinh.Name = "tbDonViTinh";
            tbDonViTinh.Size = new Size(135, 27);
            tbDonViTinh.TabIndex = 65;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(657, 127);
            label6.Name = "label6";
            label6.Size = new Size(31, 20);
            label6.TabIndex = 63;
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
            vbDonViTinh.Location = new Point(76, 164);
            vbDonViTinh.Name = "vbDonViTinh";
            vbDonViTinh.Size = new Size(154, 38);
            vbDonViTinh.TabIndex = 62;
            vbDonViTinh.Text = "vbButton3";
            vbDonViTinh.TextColor = Color.White;
            vbDonViTinh.UseVisualStyleBackColor = false;
            // 
            // tbThuoc
            // 
            tbThuoc.Location = new Point(86, 77);
            tbThuoc.Name = "tbThuoc";
            tbThuoc.Size = new Size(135, 27);
            tbThuoc.TabIndex = 57;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 36);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 55;
            label2.Text = "Tên thuốc";
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
            vbThuoc.Location = new Point(76, 69);
            vbThuoc.Name = "vbThuoc";
            vbThuoc.Size = new Size(154, 38);
            vbThuoc.TabIndex = 54;
            vbThuoc.Text = "vbButton1";
            vbThuoc.TextColor = Color.White;
            vbThuoc.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 127);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 60;
            label5.Text = "Đơn vị tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(392, 127);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 58;
            label4.Text = "Liều lượng";
            // 
            // vbGia
            // 
            vbGia.BackColor = Color.White;
            vbGia.BackgroundColor = Color.White;
            vbGia.BorderColor = Color.Black;
            vbGia.BorderRadius = 10;
            vbGia.BorderSize = 1;
            vbGia.FlatAppearance.BorderSize = 0;
            vbGia.FlatStyle = FlatStyle.Flat;
            vbGia.ForeColor = Color.White;
            vbGia.Location = new Point(657, 164);
            vbGia.Name = "vbGia";
            vbGia.Size = new Size(154, 38);
            vbGia.TabIndex = 71;
            vbGia.Text = "vbGia";
            vbGia.TextColor = Color.White;
            vbGia.UseVisualStyleBackColor = false;
            // 
            // FormThemThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pbQuayVe);
            Controls.Add(panelDuLieu);
            Controls.Add(panel1);
            Name = "FormThemThuoc";
            Text = "AddMedicineForm";
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
        private TextBox tbGia;
        private TextBox tbSoLuong;
        private Label label10;
        private CustomButton.VBButton vbSoLuong;
        private Label label3;
        private CustomButton.VBButton vbLoaiThuoc;
        private CustomButton.VBButton vbThemThuoc;
        private TextBox tbLieuLuong;
        private CustomButton.VBButton vbLieuLuong;
        private TextBox tbDonViTinh;
        private Label label6;
        private CustomButton.VBButton vbDonViTinh;
        private TextBox tbThuoc;
        private Label label2;
        private CustomButton.VBButton vbThuoc;
        private Label label5;
        private Label label4;
        private CustomButton.VBButton vbGia;
        private DateTimePicker dtpNgayNhap;
        private DateTimePicker dtpNgayHetHan;
        private DateTimePicker dtpNgaySanXuat;
        private CustomButton.VBButton vbNgayHetHan;
        private Label label7;
        private CustomButton.VBButton vbNgaySanXuat;
        private Label label9;
        private Label label11;
        private CustomButton.VBButton vbNgayNhap;
        private ComboBox cbLoaiThuoc;
    }
}