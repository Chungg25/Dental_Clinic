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
            pnTop = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).BeginInit();
            panelDuLieu.SuspendLayout();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(30, 101);
            pbQuayVe.Margin = new Padding(4, 4, 4, 4);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(88, 49);
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
            panelDuLieu.Location = new Point(126, 101);
            panelDuLieu.Margin = new Padding(4, 4, 4, 4);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(1051, 610);
            panelDuLieu.TabIndex = 49;
            panelDuLieu.Paint += panelDuLieu_Paint;
            // 
            // cbLoaiThuoc
            // 
            cbLoaiThuoc.Font = new Font("Segoe UI", 11F);
            cbLoaiThuoc.FormattingEnabled = true;
            cbLoaiThuoc.Location = new Point(381, 95);
            cbLoaiThuoc.Margin = new Padding(4, 4, 4, 4);
            cbLoaiThuoc.Name = "cbLoaiThuoc";
            cbLoaiThuoc.Size = new Size(235, 38);
            cbLoaiThuoc.TabIndex = 166;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Font = new Font("Segoe UI", 9F);
            dtpNgayNhap.Location = new Point(381, 352);
            dtpNgayNhap.Margin = new Padding(4, 4, 4, 4);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(235, 31);
            dtpNgayNhap.TabIndex = 165;
            dtpNgayNhap.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // tbGia
            // 
            tbGia.Font = new Font("Segoe UI", 11F);
            tbGia.Location = new Point(719, 215);
            tbGia.Margin = new Padding(4, 4, 4, 4);
            tbGia.Name = "tbGia";
            tbGia.Size = new Size(225, 37);
            tbGia.TabIndex = 86;
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Font = new Font("Segoe UI", 9F);
            dtpNgayHetHan.Location = new Point(720, 352);
            dtpNgayHetHan.Margin = new Padding(4, 4, 4, 4);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(224, 31);
            dtpNgayHetHan.TabIndex = 164;
            dtpNgayHetHan.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // tbSoLuong
            // 
            tbSoLuong.Font = new Font("Segoe UI", 11F);
            tbSoLuong.Location = new Point(719, 96);
            tbSoLuong.Margin = new Padding(4, 4, 4, 4);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(225, 37);
            tbSoLuong.TabIndex = 85;
            // 
            // dtpNgaySanXuat
            // 
            dtpNgaySanXuat.Font = new Font("Segoe UI", 9F);
            dtpNgaySanXuat.Location = new Point(37, 352);
            dtpNgaySanXuat.Margin = new Padding(4, 4, 4, 4);
            dtpNgaySanXuat.Name = "dtpNgaySanXuat";
            dtpNgaySanXuat.Size = new Size(252, 31);
            dtpNgaySanXuat.TabIndex = 163;
            dtpNgaySanXuat.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(707, 52);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 30);
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
            vbNgayHetHan.Font = new Font("Segoe UI", 11F);
            vbNgayHetHan.ForeColor = Color.White;
            vbNgayHetHan.Location = new Point(707, 344);
            vbNgayHetHan.Margin = new Padding(4, 4, 4, 4);
            vbNgayHetHan.Name = "vbNgayHetHan";
            vbNgayHetHan.Size = new Size(249, 55);
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
            vbSoLuong.Font = new Font("Segoe UI", 11F);
            vbSoLuong.ForeColor = Color.White;
            vbSoLuong.Location = new Point(706, 86);
            vbSoLuong.Margin = new Padding(4, 4, 4, 4);
            vbSoLuong.Name = "vbSoLuong";
            vbSoLuong.Size = new Size(249, 55);
            vbSoLuong.TabIndex = 83;
            vbSoLuong.Text = "vbButton1";
            vbSoLuong.TextColor = Color.White;
            vbSoLuong.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(368, 310);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(118, 30);
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
            vbNgaySanXuat.Font = new Font("Segoe UI", 11F);
            vbNgaySanXuat.ForeColor = Color.White;
            vbNgaySanXuat.Location = new Point(24, 344);
            vbNgaySanXuat.Margin = new Padding(4, 4, 4, 4);
            vbNgaySanXuat.Name = "vbNgaySanXuat";
            vbNgaySanXuat.Size = new Size(276, 55);
            vbNgaySanXuat.TabIndex = 159;
            vbNgaySanXuat.Text = "vbNgaySanXuat";
            vbNgaySanXuat.TextColor = Color.White;
            vbNgaySanXuat.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(368, 52);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(112, 30);
            label3.TabIndex = 81;
            label3.Text = "Loại thuốc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(24, 310);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(148, 30);
            label9.TabIndex = 158;
            label9.Text = "Ngày sản xuất";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F);
            label11.Location = new Point(706, 310);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(142, 30);
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
            vbLoaiThuoc.Font = new Font("Segoe UI", 11F);
            vbLoaiThuoc.ForeColor = Color.White;
            vbLoaiThuoc.Location = new Point(367, 86);
            vbLoaiThuoc.Margin = new Padding(4, 4, 4, 4);
            vbLoaiThuoc.Name = "vbLoaiThuoc";
            vbLoaiThuoc.Size = new Size(258, 55);
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
            vbNgayNhap.Font = new Font("Segoe UI", 11F);
            vbNgayNhap.ForeColor = Color.White;
            vbNgayNhap.Location = new Point(368, 344);
            vbNgayNhap.Margin = new Padding(4, 4, 4, 4);
            vbNgayNhap.Name = "vbNgayNhap";
            vbNgayNhap.Size = new Size(259, 55);
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
            vbThemThuoc.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThemThuoc.ForeColor = Color.White;
            vbThemThuoc.Location = new Point(368, 475);
            vbThemThuoc.Margin = new Padding(4, 4, 4, 4);
            vbThemThuoc.Name = "vbThemThuoc";
            vbThemThuoc.Size = new Size(257, 62);
            vbThemThuoc.TabIndex = 78;
            vbThemThuoc.Text = "Thêm thuốc";
            vbThemThuoc.TextColor = Color.White;
            vbThemThuoc.UseVisualStyleBackColor = false;
            vbThemThuoc.Click += vbThemThuoc_Click;
            // 
            // tbLieuLuong
            // 
            tbLieuLuong.Font = new Font("Segoe UI", 11F);
            tbLieuLuong.Location = new Point(380, 215);
            tbLieuLuong.Margin = new Padding(4, 4, 4, 4);
            tbLieuLuong.Name = "tbLieuLuong";
            tbLieuLuong.Size = new Size(233, 37);
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
            vbLieuLuong.Font = new Font("Segoe UI", 11F);
            vbLieuLuong.ForeColor = Color.White;
            vbLieuLuong.Location = new Point(366, 205);
            vbLieuLuong.Margin = new Padding(4, 4, 4, 4);
            vbLieuLuong.Name = "vbLieuLuong";
            vbLieuLuong.Size = new Size(259, 55);
            vbLieuLuong.TabIndex = 66;
            vbLieuLuong.Text = "vbButton4";
            vbLieuLuong.TextColor = Color.White;
            vbLieuLuong.UseVisualStyleBackColor = false;
            // 
            // tbDonViTinh
            // 
            tbDonViTinh.Font = new Font("Segoe UI", 11F);
            tbDonViTinh.Location = new Point(36, 215);
            tbDonViTinh.Margin = new Padding(4, 4, 4, 4);
            tbDonViTinh.Name = "tbDonViTinh";
            tbDonViTinh.Size = new Size(253, 37);
            tbDonViTinh.TabIndex = 65;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(707, 171);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(44, 30);
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
            vbDonViTinh.Font = new Font("Segoe UI", 11F);
            vbDonViTinh.ForeColor = Color.White;
            vbDonViTinh.Location = new Point(23, 205);
            vbDonViTinh.Margin = new Padding(4, 4, 4, 4);
            vbDonViTinh.Name = "vbDonViTinh";
            vbDonViTinh.Size = new Size(277, 55);
            vbDonViTinh.TabIndex = 62;
            vbDonViTinh.Text = "vbButton3";
            vbDonViTinh.TextColor = Color.White;
            vbDonViTinh.UseVisualStyleBackColor = false;
            // 
            // tbThuoc
            // 
            tbThuoc.Font = new Font("Segoe UI", 11F);
            tbThuoc.Location = new Point(36, 96);
            tbThuoc.Margin = new Padding(4, 4, 4, 4);
            tbThuoc.Name = "tbThuoc";
            tbThuoc.Size = new Size(253, 37);
            tbThuoc.TabIndex = 57;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(23, 52);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 30);
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
            vbThuoc.Font = new Font("Segoe UI", 11F);
            vbThuoc.ForeColor = Color.White;
            vbThuoc.Location = new Point(23, 86);
            vbThuoc.Margin = new Padding(4, 4, 4, 4);
            vbThuoc.Name = "vbThuoc";
            vbThuoc.Size = new Size(277, 55);
            vbThuoc.TabIndex = 54;
            vbThuoc.Text = "vbButton1";
            vbThuoc.TextColor = Color.White;
            vbThuoc.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(23, 171);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(117, 30);
            label5.TabIndex = 60;
            label5.Text = "Đơn vị tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(366, 171);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
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
            vbGia.Font = new Font("Segoe UI", 11F);
            vbGia.ForeColor = Color.White;
            vbGia.Location = new Point(706, 205);
            vbGia.Margin = new Padding(4, 4, 4, 4);
            vbGia.Name = "vbGia";
            vbGia.Size = new Size(249, 55);
            vbGia.TabIndex = 71;
            vbGia.Text = "vbGia";
            vbGia.TextColor = Color.White;
            vbGia.UseVisualStyleBackColor = false;
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
            pnTop.TabIndex = 51;
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
            label1.Size = new Size(254, 54);
            label1.TabIndex = 0;
            label1.Text = "Thêm Thuốc";
            // 
            // FormThemThuoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(pbQuayVe);
            Controls.Add(panelDuLieu);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormThemThuoc";
            Text = "AddMedicineForm";
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).EndInit();
            panelDuLieu.ResumeLayout(false);
            panelDuLieu.PerformLayout();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}