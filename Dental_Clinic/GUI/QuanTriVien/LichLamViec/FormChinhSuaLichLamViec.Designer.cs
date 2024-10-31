using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator.WorkSchedule
{
    partial class FormChinhSuaLichLamViec
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
            dtpLichLamViec = new DateTimePicker();
            pbQuayVe = new PictureBox();
            panelChiTiet = new Panel();
            vbButton1 = new CustomButton.VBButton();
            label2 = new Label();
            vbGioiTinh = new CustomButton.VBButton();
            vbEmail = new CustomButton.VBButton();
            tbQueQuan = new TextBox();
            label3 = new Label();
            vbQueQuan = new CustomButton.VBButton();
            label5 = new Label();
            vbHoTen = new CustomButton.VBButton();
            tbHoTen = new TextBox();
            tbEmail = new TextBox();
            vbSĐT = new CustomButton.VBButton();
            label8 = new Label();
            label6 = new Label();
            tbSĐT = new TextBox();
            cbGioiTinh = new ComboBox();
            vbThemBacSi = new CustomButton.VBButton();
            panelLichLamViec = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).BeginInit();
            panelChiTiet.SuspendLayout();
            panelLichLamViec.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(404, 46);
            label1.TabIndex = 0;
            label1.Text = "Chỉnh Sửa Lịch Làm Việc";
            // 
            // dtpLichLamViec
            // 
            dtpLichLamViec.Location = new Point(693, 99);
            dtpLichLamViec.Name = "dtpLichLamViec";
            dtpLichLamViec.Size = new Size(250, 27);
            dtpLichLamViec.TabIndex = 46;
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(12, 87);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(70, 39);
            pbQuayVe.SizeMode = PictureBoxSizeMode.Zoom;
            pbQuayVe.TabIndex = 47;
            pbQuayVe.TabStop = false;
            pbQuayVe.Click += pbQuayVe_Click;
            // 
            // panelChiTiet
            // 
            panelChiTiet.Controls.Add(vbButton1);
            panelChiTiet.Controls.Add(label2);
            panelChiTiet.Controls.Add(vbGioiTinh);
            panelChiTiet.Controls.Add(vbEmail);
            panelChiTiet.Controls.Add(tbQueQuan);
            panelChiTiet.Controls.Add(label3);
            panelChiTiet.Controls.Add(vbQueQuan);
            panelChiTiet.Controls.Add(label5);
            panelChiTiet.Controls.Add(vbHoTen);
            panelChiTiet.Controls.Add(tbHoTen);
            panelChiTiet.Controls.Add(tbEmail);
            panelChiTiet.Controls.Add(vbSĐT);
            panelChiTiet.Controls.Add(label8);
            panelChiTiet.Controls.Add(label6);
            panelChiTiet.Controls.Add(tbSĐT);
            panelChiTiet.Controls.Add(cbGioiTinh);
            panelChiTiet.Location = new Point(72, 208);
            panelChiTiet.Name = "panelChiTiet";
            panelChiTiet.Size = new Size(871, 403);
            panelChiTiet.TabIndex = 81;
            // 
            // vbButton1
            // 
            vbButton1.BackColor = Color.FromArgb(220, 53, 69);
            vbButton1.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbButton1.BorderColor = Color.PaleVioletRed;
            vbButton1.BorderRadius = 10;
            vbButton1.BorderSize = 0;
            vbButton1.Cursor = Cursors.Hand;
            vbButton1.FlatAppearance.BorderSize = 0;
            vbButton1.FlatStyle = FlatStyle.Flat;
            vbButton1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbButton1.ForeColor = Color.White;
            vbButton1.Location = new Point(169, 337);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(144, 50);
            vbButton1.TabIndex = 80;
            vbButton1.Text = "Thêm Bác Sĩ";
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 27);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 82;
            label2.Text = "Họ và tên";
            // 
            // vbGioiTinh
            // 
            vbGioiTinh.BackColor = Color.White;
            vbGioiTinh.BackgroundColor = Color.White;
            vbGioiTinh.BorderColor = Color.Black;
            vbGioiTinh.BorderRadius = 10;
            vbGioiTinh.BorderSize = 1;
            vbGioiTinh.FlatAppearance.BorderSize = 0;
            vbGioiTinh.FlatStyle = FlatStyle.Flat;
            vbGioiTinh.ForeColor = Color.White;
            vbGioiTinh.Location = new Point(485, 152);
            vbGioiTinh.Name = "vbGioiTinh";
            vbGioiTinh.Size = new Size(154, 38);
            vbGioiTinh.TabIndex = 93;
            vbGioiTinh.TextColor = Color.White;
            vbGioiTinh.UseVisualStyleBackColor = false;
            // 
            // vbEmail
            // 
            vbEmail.BackColor = Color.White;
            vbEmail.BackgroundColor = Color.White;
            vbEmail.BorderColor = Color.Black;
            vbEmail.BorderRadius = 10;
            vbEmail.BorderSize = 1;
            vbEmail.FlatAppearance.BorderSize = 0;
            vbEmail.FlatStyle = FlatStyle.Flat;
            vbEmail.ForeColor = Color.White;
            vbEmail.Location = new Point(485, 60);
            vbEmail.Name = "vbEmail";
            vbEmail.Size = new Size(300, 38);
            vbEmail.TabIndex = 87;
            vbEmail.Text = "vbButton2";
            vbEmail.TextColor = Color.White;
            vbEmail.UseVisualStyleBackColor = false;
            // 
            // tbQueQuan
            // 
            tbQueQuan.Location = new Point(179, 259);
            tbQueQuan.Name = "tbQueQuan";
            tbQueQuan.Size = new Size(725, 27);
            tbQueQuan.TabIndex = 95;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 27);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 83;
            label3.Text = "Email";
            // 
            // vbQueQuan
            // 
            vbQueQuan.BackColor = Color.White;
            vbQueQuan.BackgroundColor = Color.White;
            vbQueQuan.BorderColor = Color.Black;
            vbQueQuan.BorderRadius = 8;
            vbQueQuan.BorderSize = 1;
            vbQueQuan.FlatAppearance.BorderSize = 0;
            vbQueQuan.FlatStyle = FlatStyle.Flat;
            vbQueQuan.ForeColor = Color.White;
            vbQueQuan.Location = new Point(168, 251);
            vbQueQuan.Name = "vbQueQuan";
            vbQueQuan.Size = new Size(745, 38);
            vbQueQuan.TabIndex = 94;
            vbQueQuan.TextColor = Color.White;
            vbQueQuan.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(168, 118);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 86;
            label5.Text = "Số Điện Thoại";
            // 
            // vbHoTen
            // 
            vbHoTen.BackColor = Color.White;
            vbHoTen.BackgroundColor = Color.White;
            vbHoTen.BorderColor = Color.Black;
            vbHoTen.BorderRadius = 8;
            vbHoTen.BorderSize = 1;
            vbHoTen.FlatAppearance.BorderSize = 0;
            vbHoTen.FlatStyle = FlatStyle.Flat;
            vbHoTen.ForeColor = Color.White;
            vbHoTen.Location = new Point(169, 60);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(154, 38);
            vbHoTen.TabIndex = 81;
            vbHoTen.Text = "vbButton1";
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // tbHoTen
            // 
            tbHoTen.Location = new Point(179, 68);
            tbHoTen.Name = "tbHoTen";
            tbHoTen.Size = new Size(135, 27);
            tbHoTen.TabIndex = 84;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(496, 68);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(279, 27);
            tbEmail.TabIndex = 85;
            // 
            // vbSĐT
            // 
            vbSĐT.BackColor = Color.White;
            vbSĐT.BackgroundColor = Color.White;
            vbSĐT.BorderColor = Color.Black;
            vbSĐT.BorderRadius = 8;
            vbSĐT.BorderSize = 1;
            vbSĐT.FlatAppearance.BorderSize = 0;
            vbSĐT.FlatStyle = FlatStyle.Flat;
            vbSĐT.ForeColor = Color.White;
            vbSĐT.Location = new Point(169, 155);
            vbSĐT.Name = "vbSĐT";
            vbSĐT.Size = new Size(154, 38);
            vbSĐT.TabIndex = 88;
            vbSĐT.Text = "vbButton3";
            vbSĐT.TextColor = Color.White;
            vbSĐT.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(170, 219);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 91;
            label8.Text = "Quê quán";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(485, 118);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 89;
            label6.Text = "Giới tính";
            // 
            // tbSĐT
            // 
            tbSĐT.Location = new Point(179, 163);
            tbSĐT.Name = "tbSĐT";
            tbSĐT.Size = new Size(135, 27);
            tbSĐT.TabIndex = 90;
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Location = new Point(496, 158);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(137, 28);
            cbGioiTinh.TabIndex = 92;
            // 
            // vbThemBacSi
            // 
            vbThemBacSi.BackColor = Color.FromArgb(220, 53, 69);
            vbThemBacSi.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbThemBacSi.BorderColor = Color.PaleVioletRed;
            vbThemBacSi.BorderRadius = 10;
            vbThemBacSi.BorderSize = 0;
            vbThemBacSi.Cursor = Cursors.Hand;
            vbThemBacSi.FlatAppearance.BorderSize = 0;
            vbThemBacSi.FlatStyle = FlatStyle.Flat;
            vbThemBacSi.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vbThemBacSi.ForeColor = Color.White;
            vbThemBacSi.Location = new Point(128, 480);
            vbThemBacSi.Name = "vbThemBacSi";
            vbThemBacSi.Size = new Size(144, 50);
            vbThemBacSi.TabIndex = 80;
            vbThemBacSi.Text = "Thêm Bác Sĩ";
            vbThemBacSi.TextColor = Color.White;
            vbThemBacSi.UseVisualStyleBackColor = false;
            // 
            // panelLichLamViec
            // 
            panelLichLamViec.Controls.Add(vbThemBacSi);
            panelLichLamViec.Location = new Point(15, 166);
            panelLichLamViec.Name = "panelLichLamViec";
            panelLichLamViec.Size = new Size(1012, 502);
            panelLichLamViec.TabIndex = 45;
            // 
            // FormChinhSuaLichLamViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pbQuayVe);
            Controls.Add(panelChiTiet);
            Controls.Add(dtpLichLamViec);
            Controls.Add(panelLichLamViec);
            Controls.Add(panel1);
            Name = "FormChinhSuaLichLamViec";
            Text = "EditWorkScheduleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).EndInit();
            panelChiTiet.ResumeLayout(false);
            panelChiTiet.PerformLayout();
            panelLichLamViec.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DateTimePicker dtpLichLamViec;
        private PictureBox pbQuayVe;
        private Panel panelChiTiet;
        private CustomButton.VBButton vbButton1;
        private Label label2;
        private CustomButton.VBButton vbGioiTinh;
        private CustomButton.VBButton vbEmail;
        private TextBox tbQueQuan;
        private Label label3;
        private CustomButton.VBButton vbQueQuan;
        private Label label5;
        private CustomButton.VBButton vbHoTen;
        private TextBox tbHoTen;
        private TextBox tbEmail;
        private CustomButton.VBButton vbSĐT;
        private Label label8;
        private Label label6;
        private TextBox tbSĐT;
        private ComboBox cbGioiTinh;
        private CustomButton.VBButton vbThemBacSi;
        private Panel panelLichLamViec;
    }
}