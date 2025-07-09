namespace Dental_Clinic.GUI.LeTan
{
    partial class FormQuanLyLuong_LeTan
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
            label1 = new Label();
            pnTop = new Panel();
            dtpNgay = new DateTimePicker();
            pnLine = new Panel();
            tbHoTen = new TextBox();
            label5 = new Label();
            vbHoTen = new CustomButton.VBButton();
            tbSoNgayLam = new TextBox();
            label2 = new Label();
            vbButton1 = new CustomButton.VBButton();
            tbTongSoLoi = new TextBox();
            label3 = new Label();
            vbButton2 = new CustomButton.VBButton();
            tbTongLuong = new TextBox();
            label4 = new Label();
            vbButton3 = new CustomButton.VBButton();
            tbTongTienPhat = new TextBox();
            label6 = new Label();
            vbButton4 = new CustomButton.VBButton();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(60, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(290, 54);
            label1.TabIndex = 0;
            label1.Text = "Quản lý lương";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(dtpNgay);
            pnTop.Controls.Add(pnLine);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 47;
            // 
            // dtpNgay
            // 
            dtpNgay.CalendarFont = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpNgay.CustomFormat = "dddd, dd/MM/yyyy";
            dtpNgay.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.ImeMode = ImeMode.NoControl;
            dtpNgay.Location = new Point(941, 25);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.RightToLeft = RightToLeft.No;
            dtpNgay.Size = new Size(304, 39);
            dtpNgay.TabIndex = 2;
            dtpNgay.Value = new DateTime(2024, 11, 1, 20, 26, 21, 0);
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(60, 70);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1210, 2);
            pnLine.TabIndex = 1;
            // 
            // tbHoTen
            // 
            tbHoTen.BorderStyle = BorderStyle.None;
            tbHoTen.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbHoTen.Location = new Point(166, 322);
            tbHoTen.Margin = new Padding(4);
            tbHoTen.Name = "tbHoTen";
            tbHoTen.Size = new Size(389, 38);
            tbHoTen.TabIndex = 138;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(166, 282);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(104, 28);
            label5.TabIndex = 149;
            label5.Text = "Họ và tên";
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
            vbHoTen.Location = new Point(155, 314);
            vbHoTen.Margin = new Padding(4);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(418, 60);
            vbHoTen.TabIndex = 148;
            vbHoTen.Text = "vbButton1";
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // tbSoNgayLam
            // 
            tbSoNgayLam.BorderStyle = BorderStyle.None;
            tbSoNgayLam.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbSoNgayLam.Location = new Point(895, 321);
            tbSoNgayLam.Margin = new Padding(4);
            tbSoNgayLam.Name = "tbSoNgayLam";
            tbSoNgayLam.Size = new Size(202, 38);
            tbSoNgayLam.TabIndex = 150;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(895, 281);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 28);
            label2.TabIndex = 152;
            label2.Text = "Số ngày làm";
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
            vbButton1.Location = new Point(884, 313);
            vbButton1.Margin = new Padding(4);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(231, 60);
            vbButton1.TabIndex = 151;
            vbButton1.Text = "vbButton1";
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // tbTongSoLoi
            // 
            tbTongSoLoi.BorderStyle = BorderStyle.None;
            tbTongSoLoi.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbTongSoLoi.Location = new Point(166, 472);
            tbTongSoLoi.Margin = new Padding(4);
            tbTongSoLoi.Name = "tbTongSoLoi";
            tbTongSoLoi.Size = new Size(202, 38);
            tbTongSoLoi.TabIndex = 153;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(166, 432);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 155;
            label3.Text = "Tổng số lỗi";
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
            vbButton2.Location = new Point(155, 464);
            vbButton2.Margin = new Padding(4);
            vbButton2.Name = "vbButton2";
            vbButton2.Size = new Size(231, 60);
            vbButton2.TabIndex = 154;
            vbButton2.Text = "vbButton2";
            vbButton2.TextColor = Color.White;
            vbButton2.UseVisualStyleBackColor = false;
            // 
            // tbTongLuong
            // 
            tbTongLuong.BorderStyle = BorderStyle.None;
            tbTongLuong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbTongLuong.Location = new Point(884, 464);
            tbTongLuong.Margin = new Padding(4);
            tbTongLuong.Name = "tbTongLuong";
            tbTongLuong.Size = new Size(202, 38);
            tbTongLuong.TabIndex = 159;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(884, 424);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 161;
            label4.Text = "Tổng lương";
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
            vbButton3.Location = new Point(873, 456);
            vbButton3.Margin = new Padding(4);
            vbButton3.Name = "vbButton3";
            vbButton3.Size = new Size(231, 60);
            vbButton3.TabIndex = 160;
            vbButton3.Text = "vbButton3";
            vbButton3.TextColor = Color.White;
            vbButton3.UseVisualStyleBackColor = false;
            // 
            // tbTongTienPhat
            // 
            tbTongTienPhat.BorderStyle = BorderStyle.None;
            tbTongTienPhat.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbTongTienPhat.Location = new Point(487, 471);
            tbTongTienPhat.Margin = new Padding(4);
            tbTongTienPhat.Name = "tbTongTienPhat";
            tbTongTienPhat.Size = new Size(202, 38);
            tbTongTienPhat.TabIndex = 156;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(487, 431);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(152, 28);
            label6.TabIndex = 158;
            label6.Text = "Tổng tiền phạt";
            // 
            // vbButton4
            // 
            vbButton4.BackColor = Color.White;
            vbButton4.BackgroundColor = Color.White;
            vbButton4.BorderColor = Color.Black;
            vbButton4.BorderRadius = 14;
            vbButton4.BorderSize = 1;
            vbButton4.FlatAppearance.BorderSize = 0;
            vbButton4.FlatStyle = FlatStyle.Flat;
            vbButton4.ForeColor = Color.White;
            vbButton4.Location = new Point(476, 463);
            vbButton4.Margin = new Padding(4);
            vbButton4.Name = "vbButton4";
            vbButton4.Size = new Size(231, 60);
            vbButton4.TabIndex = 157;
            vbButton4.Text = "vbButton4";
            vbButton4.TextColor = Color.White;
            vbButton4.UseVisualStyleBackColor = false;
            // 
            // FormQuanLyLuong_LeTan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(tbTongLuong);
            Controls.Add(label4);
            Controls.Add(vbButton3);
            Controls.Add(tbTongTienPhat);
            Controls.Add(label6);
            Controls.Add(vbButton4);
            Controls.Add(tbTongSoLoi);
            Controls.Add(label3);
            Controls.Add(vbButton2);
            Controls.Add(tbSoNgayLam);
            Controls.Add(label2);
            Controls.Add(vbButton1);
            Controls.Add(tbHoTen);
            Controls.Add(label5);
            Controls.Add(vbHoTen);
            Controls.Add(pnTop);
            Name = "FormQuanLyLuong_LeTan";
            Text = "FormQuanLyLuong";
            Load += FormQuanLyLuong_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel pnTop;
        private DateTimePicker dtpNgay;
        private Panel pnLine;
        private TextBox tbHoTen;
        private Label label5;
        private CustomButton.VBButton vbHoTen;
        private TextBox tbSoNgayLam;
        private Label label2;
        private CustomButton.VBButton vbButton1;
        private TextBox tbTongSoLoi;
        private Label label3;
        private CustomButton.VBButton vbButton2;
        private TextBox tbTongLuong;
        private Label label4;
        private CustomButton.VBButton vbButton3;
        private TextBox tbTongTienPhat;
        private Label label6;
        private CustomButton.VBButton vbButton4;
    }
}