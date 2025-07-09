using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    partial class FormChiTietHoaDon
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
            label6 = new Label();
            pnHoaDon = new Panel();
            grbHoaDon = new GroupBox();
            vbHuy = new CustomButton.VBButton();
            vbXacNhan = new CustomButton.VBButton();
            pbBacSi = new PictureBox();
            vbTienMat = new CustomButton.VBButton();
            pictureBox1 = new PictureBox();
            vbChuyenKhoan = new CustomButton.VBButton();
            lbTongTien = new Label();
            tablePanel = new TableLayoutPanel();
            lbTienTraLai = new Label();
            lbTienDaDua = new Label();
            lbPhuongThucThanhToan = new Label();
            pnTienKhachDua = new Panel();
            tbTienKhachDua = new TextBox();
            vbHoTen = new CustomButton.VBButton();
            label2 = new Label();
            vbXuatHoaDon = new CustomButton.VBButton();
            grbHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBacSi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tablePanel.SuspendLayout();
            pnTienKhachDua.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.Location = new Point(0, 295);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(316, 36);
            label6.TabIndex = 132;
            label6.Text = "Phương thức thanh toán";
            // 
            // pnHoaDon
            // 
            pnHoaDon.AutoScroll = true;
            pnHoaDon.Location = new Point(12, 33);
            pnHoaDon.Name = "pnHoaDon";
            pnHoaDon.Size = new Size(1161, 253);
            pnHoaDon.TabIndex = 134;
            // 
            // grbHoaDon
            // 
            grbHoaDon.Controls.Add(pnHoaDon);
            grbHoaDon.Dock = DockStyle.Top;
            grbHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            grbHoaDon.Location = new Point(0, 0);
            grbHoaDon.Name = "grbHoaDon";
            grbHoaDon.Size = new Size(1185, 292);
            grbHoaDon.TabIndex = 135;
            grbHoaDon.TabStop = false;
            grbHoaDon.Text = "Danh sách hoá đơn";
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
            vbHuy.Location = new Point(1019, 547);
            vbHuy.Margin = new Padding(4);
            vbHuy.Name = "vbHuy";
            vbHuy.Size = new Size(150, 60);
            vbHuy.TabIndex = 137;
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
            vbXacNhan.Location = new Point(740, 547);
            vbXacNhan.Margin = new Padding(4);
            vbXacNhan.Name = "vbXacNhan";
            vbXacNhan.Size = new Size(224, 60);
            vbXacNhan.TabIndex = 136;
            vbXacNhan.Text = "Xác nhận";
            vbXacNhan.TextColor = Color.White;
            vbXacNhan.UseVisualStyleBackColor = false;
            vbXacNhan.Click += vbXacNhan_Click;
            // 
            // pbBacSi
            // 
            pbBacSi.BackColor = Color.DarkGreen;
            pbBacSi.Image = Resources.icons8_wallet_1001;
            pbBacSi.Location = new Point(110, 345);
            pbBacSi.Margin = new Padding(4);
            pbBacSi.Name = "pbBacSi";
            pbBacSi.Size = new Size(35, 35);
            pbBacSi.SizeMode = PictureBoxSizeMode.Zoom;
            pbBacSi.TabIndex = 139;
            pbBacSi.TabStop = false;
            // 
            // vbTienMat
            // 
            vbTienMat.BackColor = Color.DarkGreen;
            vbTienMat.BackgroundColor = Color.DarkGreen;
            vbTienMat.BorderColor = Color.PaleVioletRed;
            vbTienMat.BorderRadius = 14;
            vbTienMat.BorderSize = 0;
            vbTienMat.Cursor = Cursors.Hand;
            vbTienMat.FlatAppearance.BorderSize = 0;
            vbTienMat.FlatStyle = FlatStyle.Flat;
            vbTienMat.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbTienMat.ForeColor = Color.White;
            vbTienMat.Location = new Point(0, 335);
            vbTienMat.Margin = new Padding(4);
            vbTienMat.Name = "vbTienMat";
            vbTienMat.Size = new Size(158, 54);
            vbTienMat.TabIndex = 140;
            vbTienMat.Text = "Tiền mặt";
            vbTienMat.TextAlign = ContentAlignment.MiddleLeft;
            vbTienMat.TextColor = Color.White;
            vbTienMat.UseVisualStyleBackColor = false;
            vbTienMat.Click += vbTienMat_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkGreen;
            pictureBox1.Image = Resources.icons8_qr_code_1001;
            pictureBox1.Location = new Point(324, 344);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 141;
            pictureBox1.TabStop = false;
            // 
            // vbChuyenKhoan
            // 
            vbChuyenKhoan.BackColor = Color.DarkGreen;
            vbChuyenKhoan.BackgroundColor = Color.DarkGreen;
            vbChuyenKhoan.BorderColor = Color.PaleVioletRed;
            vbChuyenKhoan.BorderRadius = 14;
            vbChuyenKhoan.BorderSize = 0;
            vbChuyenKhoan.Cursor = Cursors.Hand;
            vbChuyenKhoan.FlatAppearance.BorderSize = 0;
            vbChuyenKhoan.FlatStyle = FlatStyle.Flat;
            vbChuyenKhoan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            vbChuyenKhoan.ForeColor = Color.White;
            vbChuyenKhoan.Location = new Point(166, 335);
            vbChuyenKhoan.Margin = new Padding(4);
            vbChuyenKhoan.Name = "vbChuyenKhoan";
            vbChuyenKhoan.Size = new Size(205, 54);
            vbChuyenKhoan.TabIndex = 142;
            vbChuyenKhoan.Text = "Chuyển khoản";
            vbChuyenKhoan.TextAlign = ContentAlignment.MiddleLeft;
            vbChuyenKhoan.TextColor = Color.White;
            vbChuyenKhoan.UseVisualStyleBackColor = false;
            vbChuyenKhoan.Click += vbChuyenKhoan_Click;
            // 
            // lbTongTien
            // 
            lbTongTien.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTongTien.AutoSize = true;
            lbTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTongTien.Location = new Point(1027, 295);
            lbTongTien.Margin = new Padding(4, 0, 4, 0);
            lbTongTien.Name = "lbTongTien";
            lbTongTien.Size = new Size(146, 36);
            lbTongTien.TabIndex = 149;
            lbTongTien.Text = "Tổng tiền: ";
            lbTongTien.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tablePanel
            // 
            tablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tablePanel.AutoSize = true;
            tablePanel.ColumnCount = 1;
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePanel.Controls.Add(lbTienTraLai, 1, 2);
            tablePanel.Controls.Add(lbTienDaDua, 1, 1);
            tablePanel.Controls.Add(lbPhuongThucThanhToan, 1, 0);
            tablePanel.Location = new Point(1019, 335);
            tablePanel.Name = "tablePanel";
            tablePanel.RowCount = 3;
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.3333321F));
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.6666679F));
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tablePanel.Size = new Size(154, 150);
            tablePanel.TabIndex = 156;
            // 
            // lbTienTraLai
            // 
            lbTienTraLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTienTraLai.AutoSize = true;
            lbTienTraLai.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTienTraLai.Location = new Point(4, 97);
            lbTienTraLai.Margin = new Padding(4, 0, 4, 0);
            lbTienTraLai.Name = "lbTienTraLai";
            lbTienTraLai.Size = new Size(146, 36);
            lbTienTraLai.TabIndex = 157;
            lbTienTraLai.Text = "Tổng tiền: ";
            lbTienTraLai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbTienDaDua
            // 
            lbTienDaDua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTienDaDua.AutoSize = true;
            lbTienDaDua.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTienDaDua.Location = new Point(4, 50);
            lbTienDaDua.Margin = new Padding(4, 0, 4, 0);
            lbTienDaDua.Name = "lbTienDaDua";
            lbTienDaDua.Size = new Size(146, 36);
            lbTienDaDua.TabIndex = 158;
            lbTienDaDua.Text = "Tổng tiền: ";
            lbTienDaDua.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbPhuongThucThanhToan
            // 
            lbPhuongThucThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbPhuongThucThanhToan.AutoSize = true;
            lbPhuongThucThanhToan.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPhuongThucThanhToan.Location = new Point(4, 0);
            lbPhuongThucThanhToan.Margin = new Padding(4, 0, 4, 0);
            lbPhuongThucThanhToan.Name = "lbPhuongThucThanhToan";
            lbPhuongThucThanhToan.Size = new Size(146, 36);
            lbPhuongThucThanhToan.TabIndex = 159;
            lbPhuongThucThanhToan.Text = "Tổng tiền: ";
            lbPhuongThucThanhToan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnTienKhachDua
            // 
            pnTienKhachDua.AutoSize = true;
            pnTienKhachDua.Controls.Add(tbTienKhachDua);
            pnTienKhachDua.Controls.Add(vbHoTen);
            pnTienKhachDua.Controls.Add(label2);
            pnTienKhachDua.Location = new Point(0, 396);
            pnTienKhachDua.Name = "pnTienKhachDua";
            pnTienKhachDua.Size = new Size(262, 101);
            pnTienKhachDua.TabIndex = 148;
            // 
            // tbTienKhachDua
            // 
            tbTienKhachDua.BorderStyle = BorderStyle.None;
            tbTienKhachDua.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbTienKhachDua.Location = new Point(13, 45);
            tbTienKhachDua.Margin = new Padding(4);
            tbTienKhachDua.Name = "tbTienKhachDua";
            tbTienKhachDua.Size = new Size(227, 38);
            tbTienKhachDua.TabIndex = 145;
            tbTienKhachDua.TextChanged += tbTienKhachDua_TextChanged;
            // 
            // vbHoTen
            // 
            vbHoTen.BackColor = Color.White;
            vbHoTen.BackgroundColor = Color.White;
            vbHoTen.BorderColor = Color.Black;
            vbHoTen.BorderRadius = 14;
            vbHoTen.BorderSize = 1;
            vbHoTen.FlatAppearance.BorderSize = 0;
            vbHoTen.FlatStyle = FlatStyle.Flat;
            vbHoTen.ForeColor = Color.White;
            vbHoTen.Location = new Point(2, 37);
            vbHoTen.Margin = new Padding(4);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(256, 60);
            vbHoTen.TabIndex = 146;
            vbHoTen.Text = "vbButton1";
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 5);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 28);
            label2.TabIndex = 147;
            label2.Text = "Tiền khách đưa";
            // 
            // vbXuatHoaDon
            // 
            vbXuatHoaDon.BackColor = Color.FromArgb(192, 192, 0);
            vbXuatHoaDon.BackgroundColor = Color.FromArgb(192, 192, 0);
            vbXuatHoaDon.BorderColor = Color.PaleVioletRed;
            vbXuatHoaDon.BorderRadius = 14;
            vbXuatHoaDon.BorderSize = 0;
            vbXuatHoaDon.Cursor = Cursors.Hand;
            vbXuatHoaDon.FlatAppearance.BorderSize = 0;
            vbXuatHoaDon.FlatStyle = FlatStyle.Flat;
            vbXuatHoaDon.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbXuatHoaDon.ForeColor = Color.White;
            vbXuatHoaDon.Location = new Point(415, 547);
            vbXuatHoaDon.Margin = new Padding(4);
            vbXuatHoaDon.Name = "vbXuatHoaDon";
            vbXuatHoaDon.Size = new Size(266, 60);
            vbXuatHoaDon.TabIndex = 157;
            vbXuatHoaDon.Text = "Xuất hoá đơn";
            vbXuatHoaDon.TextColor = Color.White;
            vbXuatHoaDon.UseVisualStyleBackColor = false;
            vbXuatHoaDon.Click += vbXuatHoaDon_Click;
            // 
            // FormChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1185, 653);
            Controls.Add(vbXuatHoaDon);
            Controls.Add(tablePanel);
            Controls.Add(lbTongTien);
            Controls.Add(pnTienKhachDua);
            Controls.Add(pictureBox1);
            Controls.Add(vbChuyenKhoan);
            Controls.Add(pbBacSi);
            Controls.Add(vbTienMat);
            Controls.Add(vbHuy);
            Controls.Add(vbXacNhan);
            Controls.Add(grbHoaDon);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormChiTietHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChiTietHoaDon";
            Load += FormChiTietHoaDon_Load;
            grbHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbBacSi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tablePanel.ResumeLayout(false);
            tablePanel.PerformLayout();
            pnTienKhachDua.ResumeLayout(false);
            pnTienKhachDua.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private Panel pnHoaDon;
        private GroupBox grbHoaDon;
        private CustomButton.VBButton vbHuy;
        private CustomButton.VBButton vbXacNhan;
        private PictureBox pbBacSi;
        private CustomButton.VBButton vbTienMat;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbChuyenKhoan;
        private Label lbTongTien;
        private TableLayoutPanel tablePanel;
        private Label lbTienTraLai;
        private Label lbTienDaDua;
        private Label lbPhuongThucThanhToan;
        private Panel pnTienKhachDua;
        private TextBox tbTienKhachDua;
        private CustomButton.VBButton vbHoTen;
        private Label label2;
        private CustomButton.VBButton vbXuatHoaDon;
    }
}