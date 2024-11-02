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
            panel1 = new Panel();
            label1 = new Label();
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
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(224, 46);
            label1.TabIndex = 0;
            label1.Text = "Thêm Vật Tư";
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(24, 81);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(70, 39);
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
            panelDuLieu.Location = new Point(100, 135);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(841, 493);
            panelDuLieu.TabIndex = 81;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(667, 274);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(135, 27);
            dtpNgayNhap.TabIndex = 156;
            dtpNgayNhap.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.Location = new Point(402, 274);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(136, 27);
            dtpNgayHetHan.TabIndex = 155;
            dtpNgayHetHan.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // dtpNgaySanXuat
            // 
            dtpNgaySanXuat.Location = new Point(86, 274);
            dtpNgaySanXuat.Name = "dtpNgaySanXuat";
            dtpNgaySanXuat.Size = new Size(135, 27);
            dtpNgaySanXuat.TabIndex = 154;
            dtpNgaySanXuat.Value = new DateTime(2024, 11, 2, 0, 0, 0, 0);
            // 
            // cbLoaiVatTu
            // 
            cbLoaiVatTu.FormattingEnabled = true;
            cbLoaiVatTu.Location = new Point(403, 76);
            cbLoaiVatTu.Name = "cbLoaiVatTu";
            cbLoaiVatTu.Size = new Size(135, 28);
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
            vbThemVatTu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbThemVatTu.ForeColor = Color.White;
            vbThemVatTu.Location = new Point(77, 362);
            vbThemVatTu.Name = "vbThemVatTu";
            vbThemVatTu.Size = new Size(144, 50);
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
            vbNgayHetHan.ForeColor = Color.White;
            vbNgayHetHan.Location = new Point(392, 267);
            vbNgayHetHan.Name = "vbNgayHetHan";
            vbNgayHetHan.Size = new Size(155, 38);
            vbNgayHetHan.TabIndex = 148;
            vbNgayHetHan.Text = "vbButton4";
            vbNgayHetHan.TextColor = Color.White;
            vbNgayHetHan.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(657, 230);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
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
            vbNgaySanXuat.ForeColor = Color.White;
            vbNgaySanXuat.Location = new Point(76, 267);
            vbNgaySanXuat.Name = "vbNgaySanXuat";
            vbNgaySanXuat.Size = new Size(154, 38);
            vbNgaySanXuat.TabIndex = 145;
            vbNgaySanXuat.Text = "vbNgaySanXuat";
            vbNgaySanXuat.TextColor = Color.White;
            vbNgaySanXuat.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(76, 230);
            label9.Name = "label9";
            label9.Size = new Size(102, 20);
            label9.TabIndex = 144;
            label9.Text = "Ngày sản xuất";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(392, 230);
            label11.Name = "label11";
            label11.Size = new Size(97, 20);
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
            vbNgayNhap.ForeColor = Color.White;
            vbNgayNhap.Location = new Point(657, 267);
            vbNgayNhap.Name = "vbNgayNhap";
            vbNgayNhap.Size = new Size(154, 38);
            vbNgayNhap.TabIndex = 150;
            vbNgayNhap.Text = "vbGia";
            vbNgayNhap.TextColor = Color.White;
            vbNgayNhap.UseVisualStyleBackColor = false;
            // 
            // tbGia
            // 
            tbGia.Location = new Point(667, 173);
            tbGia.Name = "tbGia";
            tbGia.Size = new Size(135, 27);
            tbGia.TabIndex = 142;
            // 
            // tbSoLuong
            // 
            tbSoLuong.Location = new Point(667, 78);
            tbSoLuong.Name = "tbSoLuong";
            tbSoLuong.Size = new Size(135, 27);
            tbSoLuong.TabIndex = 141;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(657, 37);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
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
            vbSoLuong.ForeColor = Color.White;
            vbSoLuong.Location = new Point(657, 70);
            vbSoLuong.Name = "vbSoLuong";
            vbSoLuong.Size = new Size(154, 38);
            vbSoLuong.TabIndex = 139;
            vbSoLuong.Text = "vbButton1";
            vbSoLuong.TextColor = Color.White;
            vbSoLuong.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 37);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
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
            vbLoaiThuoc.ForeColor = Color.White;
            vbLoaiThuoc.Location = new Point(393, 70);
            vbLoaiThuoc.Name = "vbLoaiThuoc";
            vbLoaiThuoc.Size = new Size(154, 38);
            vbLoaiThuoc.TabIndex = 136;
            vbLoaiThuoc.Text = "vbButton1";
            vbLoaiThuoc.TextColor = Color.White;
            vbLoaiThuoc.UseVisualStyleBackColor = false;
            // 
            // tbLieuLuong
            // 
            tbLieuLuong.Location = new Point(403, 173);
            tbLieuLuong.Name = "tbLieuLuong";
            tbLieuLuong.Size = new Size(135, 27);
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
            vbLieuLuong.ForeColor = Color.White;
            vbLieuLuong.Location = new Point(392, 165);
            vbLieuLuong.Name = "vbLieuLuong";
            vbLieuLuong.Size = new Size(155, 38);
            vbLieuLuong.TabIndex = 133;
            vbLieuLuong.Text = "vbButton4";
            vbLieuLuong.TextColor = Color.White;
            vbLieuLuong.UseVisualStyleBackColor = false;
            // 
            // tbDonViTinh
            // 
            tbDonViTinh.Location = new Point(86, 173);
            tbDonViTinh.Name = "tbDonViTinh";
            tbDonViTinh.Size = new Size(135, 27);
            tbDonViTinh.TabIndex = 132;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(657, 128);
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
            vbDonViTinh.Location = new Point(76, 165);
            vbDonViTinh.Name = "vbDonViTinh";
            vbDonViTinh.Size = new Size(154, 38);
            vbDonViTinh.TabIndex = 130;
            vbDonViTinh.Text = "vbButton3";
            vbDonViTinh.TextColor = Color.White;
            vbDonViTinh.UseVisualStyleBackColor = false;
            // 
            // tbThuoc
            // 
            tbThuoc.Location = new Point(86, 78);
            tbThuoc.Name = "tbThuoc";
            tbThuoc.Size = new Size(135, 27);
            tbThuoc.TabIndex = 127;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 36);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
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
            vbThuoc.ForeColor = Color.White;
            vbThuoc.Location = new Point(76, 70);
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
            label5.Location = new Point(76, 128);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 129;
            label5.Text = "Đơn vị tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(392, 128);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
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
            vbGia.ForeColor = Color.White;
            vbGia.Location = new Point(657, 165);
            vbGia.Name = "vbGia";
            vbGia.Size = new Size(154, 38);
            vbGia.TabIndex = 135;
            vbGia.Text = "vbGia";
            vbGia.TextColor = Color.White;
            vbGia.UseVisualStyleBackColor = false;
            // 
            // FormThemVatTu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pbQuayVe);
            Controls.Add(panelDuLieu);
            Controls.Add(panel1);
            Name = "FormThemVatTu";
            Text = "AddSuppliesForm";
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
    }
}