namespace Dental_Clinic.GUI.BacSi.TrangChu
{
    partial class FormHoaDon
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
            vbHuy = new CustomButton.VBButton();
            tbSoLuongDichVu = new TextBox();
            vbSĐT = new CustomButton.VBButton();
            label2 = new Label();
            vbHoTen = new CustomButton.VBButton();
            label5 = new Label();
            vbXacNhan = new CustomButton.VBButton();
            cbLoaiDichVu = new ComboBox();
            cbDichVu = new ComboBox();
            label1 = new Label();
            vbButton1 = new CustomButton.VBButton();
            cbThuoc = new ComboBox();
            label3 = new Label();
            vbButton2 = new CustomButton.VBButton();
            vbButton3 = new CustomButton.VBButton();
            dgvDanhSach = new DataGridView();
            label4 = new Label();
            tbSoLuongThuoc = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
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
            vbHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbHuy.ForeColor = Color.White;
            vbHuy.Location = new Point(243, 492);
            vbHuy.Margin = new Padding(4);
            vbHuy.Name = "vbHuy";
            vbHuy.Size = new Size(148, 60);
            vbHuy.TabIndex = 173;
            vbHuy.Text = "Huỷ";
            vbHuy.TextColor = Color.White;
            vbHuy.UseVisualStyleBackColor = false;
            vbHuy.Click += vbHuy_Click;
            // 
            // tbSoLuongDichVu
            // 
            tbSoLuongDichVu.BorderStyle = BorderStyle.None;
            tbSoLuongDichVu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbSoLuongDichVu.Location = new Point(198, 411);
            tbSoLuongDichVu.Margin = new Padding(4);
            tbSoLuongDichVu.Name = "tbSoLuongDichVu";
            tbSoLuongDichVu.Size = new Size(157, 24);
            tbSoLuongDichVu.TabIndex = 170;
            // 
            // vbSĐT
            // 
            vbSĐT.BackColor = Color.White;
            vbSĐT.BackgroundColor = Color.White;
            vbSĐT.BorderColor = Color.Black;
            vbSĐT.BorderRadius = 14;
            vbSĐT.BorderSize = 1;
            vbSĐT.FlatAppearance.BorderSize = 0;
            vbSĐT.FlatStyle = FlatStyle.Flat;
            vbSĐT.ForeColor = Color.White;
            vbSĐT.Location = new Point(186, 396);
            vbSĐT.Margin = new Padding(4);
            vbSĐT.Name = "vbSĐT";
            vbSĐT.Size = new Size(182, 60);
            vbSĐT.TabIndex = 177;
            vbSĐT.Text = "vbButton3";
            vbSĐT.TextColor = Color.White;
            vbSĐT.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 12);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(126, 28);
            label2.TabIndex = 175;
            label2.Text = "Loại dịch vụ";
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
            vbHoTen.Location = new Point(1, 44);
            vbHoTen.Margin = new Padding(4);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(375, 60);
            vbHoTen.TabIndex = 174;
            vbHoTen.Text = "vbButton1";
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label5.Location = new Point(198, 361);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(170, 28);
            label5.TabIndex = 176;
            label5.Text = "Số lượng dịch vụ";
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
            vbXacNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbXacNhan.ForeColor = Color.White;
            vbXacNhan.Location = new Point(4, 492);
            vbXacNhan.Margin = new Padding(4);
            vbXacNhan.Name = "vbXacNhan";
            vbXacNhan.Size = new Size(222, 60);
            vbXacNhan.TabIndex = 172;
            vbXacNhan.Text = "Xác nhận";
            vbXacNhan.TextColor = Color.White;
            vbXacNhan.UseVisualStyleBackColor = false;
            vbXacNhan.Click += vbXacNhan_Click;
            // 
            // cbLoaiDichVu
            // 
            cbLoaiDichVu.FormattingEnabled = true;
            cbLoaiDichVu.Location = new Point(12, 59);
            cbLoaiDichVu.Name = "cbLoaiDichVu";
            cbLoaiDichVu.Size = new Size(345, 33);
            cbLoaiDichVu.TabIndex = 187;
            cbLoaiDichVu.SelectedIndexChanged += cbLoaiDichVu_SelectedIndexChanged;
            // 
            // cbDichVu
            // 
            cbDichVu.FormattingEnabled = true;
            cbDichVu.Location = new Point(15, 160);
            cbDichVu.Name = "cbDichVu";
            cbDichVu.Size = new Size(342, 33);
            cbDichVu.TabIndex = 190;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 113);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 189;
            label1.Text = "Tên dịch vụ";
            // 
            // vbButton1
            // 
            vbButton1.BackColor = Color.White;
            vbButton1.BackgroundColor = Color.White;
            vbButton1.BorderColor = Color.Black;
            vbButton1.BorderRadius = 14;
            vbButton1.BorderSize = 1;
            vbButton1.FlatAppearance.BorderSize = 0;
            vbButton1.FlatStyle = FlatStyle.Flat;
            vbButton1.ForeColor = Color.White;
            vbButton1.Location = new Point(4, 145);
            vbButton1.Margin = new Padding(4);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(370, 60);
            vbButton1.TabIndex = 188;
            vbButton1.Text = "vbButton1";
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // cbThuoc
            // 
            cbThuoc.FormattingEnabled = true;
            cbThuoc.Location = new Point(15, 283);
            cbThuoc.Name = "cbThuoc";
            cbThuoc.Size = new Size(342, 33);
            cbThuoc.TabIndex = 193;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 236);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(111, 28);
            label3.TabIndex = 192;
            label3.Text = "Loại thuốc";
            // 
            // vbButton2
            // 
            vbButton2.BackColor = Color.White;
            vbButton2.BackgroundColor = Color.White;
            vbButton2.BorderColor = Color.Black;
            vbButton2.BorderRadius = 14;
            vbButton2.BorderSize = 1;
            vbButton2.FlatAppearance.BorderSize = 0;
            vbButton2.FlatStyle = FlatStyle.Flat;
            vbButton2.ForeColor = Color.White;
            vbButton2.Location = new Point(4, 268);
            vbButton2.Margin = new Padding(4);
            vbButton2.Name = "vbButton2";
            vbButton2.Size = new Size(372, 60);
            vbButton2.TabIndex = 191;
            vbButton2.Text = "vbButton1";
            vbButton2.TextColor = Color.White;
            vbButton2.UseVisualStyleBackColor = false;
            // 
            // vbButton3
            // 
            vbButton3.BackColor = Color.White;
            vbButton3.BackgroundColor = Color.White;
            vbButton3.BorderColor = Color.Black;
            vbButton3.BorderRadius = 14;
            vbButton3.BorderSize = 1;
            vbButton3.FlatAppearance.BorderSize = 0;
            vbButton3.FlatStyle = FlatStyle.Flat;
            vbButton3.ForeColor = Color.White;
            vbButton3.Location = new Point(1, 393);
            vbButton3.Margin = new Padding(4);
            vbButton3.Name = "vbButton3";
            vbButton3.Size = new Size(167, 60);
            vbButton3.TabIndex = 196;
            vbButton3.Text = "vbButton3";
            vbButton3.TextColor = Color.White;
            vbButton3.UseVisualStyleBackColor = false;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.BackgroundColor = Color.White;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Location = new Point(431, 12);
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.RowHeadersWidth = 62;
            dgvDanhSach.Size = new Size(779, 568);
            dgvDanhSach.TabIndex = 197;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(12, 361);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(155, 28);
            label4.TabIndex = 198;
            label4.Text = "Số lượng thuốc";
            // 
            // tbSoLuongThuoc
            // 
            tbSoLuongThuoc.BorderStyle = BorderStyle.None;
            tbSoLuongThuoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbSoLuongThuoc.Location = new Point(13, 411);
            tbSoLuongThuoc.Margin = new Padding(4);
            tbSoLuongThuoc.Name = "tbSoLuongThuoc";
            tbSoLuongThuoc.Size = new Size(143, 24);
            tbSoLuongThuoc.TabIndex = 199;
            tbSoLuongThuoc.TextAlign = HorizontalAlignment.Center;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1222, 603);
            Controls.Add(tbSoLuongThuoc);
            Controls.Add(label4);
            Controls.Add(dgvDanhSach);
            Controls.Add(vbButton3);
            Controls.Add(cbThuoc);
            Controls.Add(label3);
            Controls.Add(vbButton2);
            Controls.Add(cbDichVu);
            Controls.Add(label1);
            Controls.Add(vbButton1);
            Controls.Add(cbLoaiDichVu);
            Controls.Add(vbHuy);
            Controls.Add(tbSoLuongDichVu);
            Controls.Add(vbSĐT);
            Controls.Add(label2);
            Controls.Add(vbHoTen);
            Controls.Add(label5);
            Controls.Add(vbXacNhan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHoaDon";
            Text = "FormHoaDon";
            Load += FormHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomButton.VBButton vbHuy;
        private TextBox tbSoLuongDichVu;
        private CustomButton.VBButton vbSĐT;
        private Label label2;
        private CustomButton.VBButton vbHoTen;
        private Label label5;
        private CustomButton.VBButton vbXacNhan;
        private ComboBox cbLoaiDichVu;
        private ComboBox cbDichVu;
        private Label label1;
        private CustomButton.VBButton vbButton1;
        private ComboBox cbThuoc;
        private Label label3;
        private CustomButton.VBButton vbButton2;
        private CustomButton.VBButton vbButton3;
        private DataGridView dgvDanhSach;
        private Label label4;
        private TextBox tbSoLuongThuoc;
    }
}