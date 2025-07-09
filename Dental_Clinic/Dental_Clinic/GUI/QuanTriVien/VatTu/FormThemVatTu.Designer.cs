using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator.Supplies
{
    partial class FormThemVatTu
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
            dtpNgayNhap = new DateTimePicker();
            dtpNgayHetHan = new DateTimePicker();
            dtpNgaySanXuat = new DateTimePicker();
            cbLoaiVatTu = new ComboBox();
            vbThemVatTu = new CustomButton.VBButton();
            vbNgayHetHan = new CustomButton.VBButton();
            label7 = new Label();
            vbNgaySanXuat = new CustomButton.VBButton();
            label9 = new Label();
            label11 = new Label();
            vbNgayNhap = new CustomButton.VBButton();
            tbGia = new TextBox();
            tbSoLuong = new TextBox();
            label10 = new Label();
            vbSoLuong = new CustomButton.VBButton();
            label3 = new Label();
            vbLoaiThuoc = new CustomButton.VBButton();
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
            pbQuayVe.TabIndex = 82;
            pbQuayVe.TabStop = false;
            pbQuayVe.Click += pbQuayVe_Click;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Controls.Add(dtpNgayNhap);
            panelDuLieu.Controls.Add(dtpNgayHetHan);
            panelDuLieu.Controls.Add(dtpNgaySanXuat);
            panelDuLieu.Controls.Add(cbLoaiVatTu);
            panelDuLieu.Controls.Add(vbThemVatTu);
            panelDuLieu.Controls.Add(vbNgayHetHan);
            panelDuLieu.Controls.Add(label7);
            panelDuLieu.Controls.Add(vbNgaySanXuat);
            panelDuLieu.Controls.Add(label9);
            panelDuLieu.Controls.Add(label11);
            panelDuLieu.Controls.Add(vbNgayNhap);
            panelDuLieu.Controls.Add(tbGia);
            panelDuLieu.Controls.Add(tbSoLuong);
            panelDuLieu.Controls.Add(label10);
            panelDuLieu.Controls.Add(vbSoLuong);
            panelDuLieu.Controls.Add(label3);
            panelDuLieu.Controls.Add(vbLoaiThuoc);
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
            panelDuLieu.Size = new Size(1051, 616);
            panelDuLieu.TabIndex = 81;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Font = new Font("Segoe UI", 9F);
            dtpNgayNhap.Location = new Point(403, 341);
            dtpNgayNhap.Margin = new Padding(4, 4, 4, 4);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(252, 31);
            dtpNgayNhap.TabIndex = 156;
            dtpNgayNhap.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Font = new Font("Segoe UI", 9F);
            dtpNgayHetHan.Location = new Point(756, 341);
            dtpNgayHetHan.Margin = new Padding(4, 4, 4, 4);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(250, 31);
            dtpNgayHetHan.TabIndex = 155;
            dtpNgayHetHan.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // dtpNgaySanXuat
            // 
            dtpNgaySanXuat.Font = new Font("Segoe UI", 9F);
            dtpNgaySanXuat.Location = new Point(30, 341);
            dtpNgaySanXuat.Margin = new Padding(4, 4, 4, 4);
            dtpNgaySanXuat.Name = "dtpNgaySanXuat";
            dtpNgaySanXuat.Size = new Size(246, 31);
            dtpNgaySanXuat.TabIndex = 154;
            dtpNgaySanXuat.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // cbLoaiVatTu
            // 
            cbLoaiVatTu.Font = new Font("Segoe UI", 11F);
            cbLoaiVatTu.FormattingEnabled = true;
            cbLoaiVatTu.Location = new Point(403, 94);
            cbLoaiVatTu.Margin = new Padding(4, 4, 4, 4);
            cbLoaiVatTu.Name = "cbLoaiVatTu";
            cbLoaiVatTu.Size = new Size(252, 38);
            cbLoaiVatTu.TabIndex = 153;
            // 
            // vbThemVatTu
            // 
            vbThemVatTu.BackColor = Color.FromArgb(220, 53, 69);
            vbThemVatTu.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbThemVatTu.BorderColor = Color.PaleVioletRed;
            vbThemVatTu.BorderRadius = 10;
            vbThemVatTu.BorderSize = 0;
            vbThemVatTu.Cursor = Cursors.Hand;
            vbThemVatTu.FlatAppearance.BorderSize = 0;
            vbThemVatTu.FlatStyle = FlatStyle.Flat;
            vbThemVatTu.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThemVatTu.ForeColor = Color.White;
            vbThemVatTu.Location = new Point(390, 452);
            vbThemVatTu.Margin = new Padding(4, 4, 4, 4);
            vbThemVatTu.Name = "vbThemVatTu";
            vbThemVatTu.Size = new Size(277, 62);
            vbThemVatTu.TabIndex = 152;
            vbThemVatTu.Text = "Thêm Vật Tư";
            vbThemVatTu.TextColor = Color.White;
            vbThemVatTu.UseVisualStyleBackColor = false;
            vbThemVatTu.Click += vbThemVatTu_Click;
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
            vbNgayHetHan.Location = new Point(743, 333);
            vbNgayHetHan.Margin = new Padding(4, 4, 4, 4);
            vbNgayHetHan.Name = "vbNgayHetHan";
            vbNgayHetHan.Size = new Size(275, 55);
            vbNgayHetHan.TabIndex = 148;
            vbNgayHetHan.Text = "vbButton4";
            vbNgayHetHan.TextColor = Color.White;
            vbNgayHetHan.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(390, 299);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(118, 30);
            label7.TabIndex = 146;
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
            vbNgaySanXuat.Location = new Point(17, 333);
            vbNgaySanXuat.Margin = new Padding(4, 4, 4, 4);
            vbNgaySanXuat.Name = "vbNgaySanXuat";
            vbNgaySanXuat.Size = new Size(270, 55);
            vbNgaySanXuat.TabIndex = 145;
            vbNgaySanXuat.Text = "vbNgaySanXuat";
            vbNgaySanXuat.TextColor = Color.White;
            vbNgaySanXuat.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(17, 299);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(148, 30);
            label9.TabIndex = 144;
            label9.Text = "Ngày sản xuất";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F);
            label11.Location = new Point(743, 299);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(142, 30);
            label11.TabIndex = 143;
            label11.Text = "Ngày hết hạn";
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
            vbNgayNhap.Location = new Point(390, 333);
            vbNgayNhap.Margin = new Padding(4, 4, 4, 4);
            vbNgayNhap.Name = "vbNgayNhap";
            vbNgayNhap.Size = new Size(276, 55);
            vbNgayNhap.TabIndex = 150;
            vbNgayNhap.Text = "vbGia";
            vbNgayNhap.TextColor = Color.White;
            vbNgayNhap.UseVisualStyleBackColor = false;
            // 
            // tbGia
            // 
            tbGia.Font = new Font("Segoe UI", 11F);
            tbGia.Location = new Point(756, 215);
            tbGia.Margin = new Padding(4, 4, 4, 4);
            tbGia.Name = "tbGia";
            tbGia.Size = new Size(250, 37);
            tbGia.TabIndex = 142;
            // 
            // tbSoLuong
            // 
            tbSoLuong.Font = new Font("Segoe UI", 11F);
            tbSoLuong.Location = new Point(756, 97);
            tbSoLuong.Margin = new Padding(4, 4, 4, 4);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(250, 37);
            tbSoLuong.TabIndex = 141;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(743, 53);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 30);
            label10.TabIndex = 140;
            label10.Text = "Số lượng";
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
            vbSoLuong.Location = new Point(743, 87);
            vbSoLuong.Margin = new Padding(4, 4, 4, 4);
            vbSoLuong.Name = "vbSoLuong";
            vbSoLuong.Size = new Size(274, 55);
            vbSoLuong.TabIndex = 139;
            vbSoLuong.Text = "vbButton1";
            vbSoLuong.TextColor = Color.White;
            vbSoLuong.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(390, 53);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 30);
            label3.TabIndex = 137;
            label3.Text = "Loại vật tư";
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
            vbLoaiThuoc.Location = new Point(390, 87);
            vbLoaiThuoc.Margin = new Padding(4, 4, 4, 4);
            vbLoaiThuoc.Name = "vbLoaiThuoc";
            vbLoaiThuoc.Size = new Size(276, 55);
            vbLoaiThuoc.TabIndex = 136;
            vbLoaiThuoc.Text = "vbButton1";
            vbLoaiThuoc.TextColor = Color.White;
            vbLoaiThuoc.UseVisualStyleBackColor = false;
            // 
            // tbLieuLuong
            // 
            tbLieuLuong.Font = new Font("Segoe UI", 11F);
            tbLieuLuong.Location = new Point(403, 215);
            tbLieuLuong.Margin = new Padding(4, 4, 4, 4);
            tbLieuLuong.Name = "tbLieuLuong";
            tbLieuLuong.Size = new Size(252, 37);
            tbLieuLuong.TabIndex = 134;
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
            vbLieuLuong.Location = new Point(389, 205);
            vbLieuLuong.Margin = new Padding(4, 4, 4, 4);
            vbLieuLuong.Name = "vbLieuLuong";
            vbLieuLuong.Size = new Size(278, 55);
            vbLieuLuong.TabIndex = 133;
            vbLieuLuong.Text = "vbButton4";
            vbLieuLuong.TextColor = Color.White;
            vbLieuLuong.UseVisualStyleBackColor = false;
            // 
            // tbDonViTinh
            // 
            tbDonViTinh.Font = new Font("Segoe UI", 11F);
            tbDonViTinh.Location = new Point(30, 215);
            tbDonViTinh.Margin = new Padding(4, 4, 4, 4);
            tbDonViTinh.Name = "tbDonViTinh";
            tbDonViTinh.Size = new Size(246, 37);
            tbDonViTinh.TabIndex = 132;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(743, 171);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(44, 30);
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
            vbDonViTinh.Font = new Font("Segoe UI", 11F);
            vbDonViTinh.ForeColor = Color.White;
            vbDonViTinh.Location = new Point(17, 205);
            vbDonViTinh.Margin = new Padding(4, 4, 4, 4);
            vbDonViTinh.Name = "vbDonViTinh";
            vbDonViTinh.Size = new Size(270, 55);
            vbDonViTinh.TabIndex = 130;
            vbDonViTinh.Text = "vbButton3";
            vbDonViTinh.TextColor = Color.White;
            vbDonViTinh.UseVisualStyleBackColor = false;
            // 
            // tbThuoc
            // 
            tbThuoc.Font = new Font("Segoe UI", 11F);
            tbThuoc.Location = new Point(30, 97);
            tbThuoc.Margin = new Padding(4, 4, 4, 4);
            tbThuoc.Name = "tbThuoc";
            tbThuoc.Size = new Size(250, 37);
            tbThuoc.TabIndex = 127;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(17, 53);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 30);
            label2.TabIndex = 126;
            label2.Text = "Tên vật tư";
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
            vbThuoc.Location = new Point(17, 87);
            vbThuoc.Margin = new Padding(4, 4, 4, 4);
            vbThuoc.Name = "vbThuoc";
            vbThuoc.Size = new Size(274, 55);
            vbThuoc.TabIndex = 125;
            vbThuoc.Text = "vbButton1";
            vbThuoc.TextColor = Color.White;
            vbThuoc.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(17, 171);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(117, 30);
            label5.TabIndex = 129;
            label5.Text = "Đơn vị tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(389, 171);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 128;
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
            vbGia.Location = new Point(743, 205);
            vbGia.Margin = new Padding(4, 4, 4, 4);
            vbGia.Name = "vbGia";
            vbGia.Size = new Size(274, 55);
            vbGia.TabIndex = 135;
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
            pnTop.TabIndex = 83;
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
            label1.Size = new Size(266, 54);
            label1.TabIndex = 0;
            label1.Text = "Thêm Vật Tư";
            // 
            // FormThemVatTu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(pbQuayVe);
            Controls.Add(panelDuLieu);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormThemVatTu";
            Text = "AddSuppliesForm";
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
        private CustomButton.VBButton vbHuy;
        private CustomButton.VBButton vbThemVatTu;
        private CustomButton.VBButton vbNgayHetHan;
        private Label label7;
        private CustomButton.VBButton vbNgaySanXuat;
        private Label label9;
        private Label label11;
        private CustomButton.VBButton vbNgayNhap;
        private TextBox tbGia;
        private TextBox tbSoLuong;
        private Label label10;
        private CustomButton.VBButton vbSoLuong;
        private Label label3;
        private CustomButton.VBButton vbLoaiThuoc;
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
        private ComboBox cbLoaiVatTu;
        private DateTimePicker dtpNgayNhap;
        private DateTimePicker dtpNgayHetHan;
        private DateTimePicker dtpNgaySanXuat;
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}