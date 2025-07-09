namespace Dental_Clinic.GUI.BacSi.TrangChu
{
    partial class FormDatLichHen
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
            vbXacNhan = new CustomButton.VBButton();
            vbHuy = new CustomButton.VBButton();
            tbGhiChu = new TextBox();
            lbGhiChu = new Label();
            vbHoTen = new CustomButton.VBButton();
            tbCaLam = new TextBox();
            label1 = new Label();
            vbButton1 = new CustomButton.VBButton();
            label2 = new Label();
            vbButton2 = new CustomButton.VBButton();
            dateTimePicker = new DateTimePicker();
            SuspendLayout();
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
            vbXacNhan.Location = new Point(64, 382);
            vbXacNhan.Margin = new Padding(4);
            vbXacNhan.Name = "vbXacNhan";
            vbXacNhan.Size = new Size(273, 60);
            vbXacNhan.TabIndex = 169;
            vbXacNhan.Text = "Xác nhận";
            vbXacNhan.TextColor = Color.White;
            vbXacNhan.UseVisualStyleBackColor = false;
            vbXacNhan.Click += vbXacNhan_Click;
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
            vbHuy.Location = new Point(387, 382);
            vbHuy.Margin = new Padding(4);
            vbHuy.Name = "vbHuy";
            vbHuy.Size = new Size(273, 60);
            vbHuy.TabIndex = 170;
            vbHuy.Text = "Huỷ";
            vbHuy.TextColor = Color.White;
            vbHuy.UseVisualStyleBackColor = false;
            vbHuy.Click += vbHuy_Click;
            // 
            // tbGhiChu
            // 
            tbGhiChu.BorderStyle = BorderStyle.None;
            tbGhiChu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbGhiChu.Location = new Point(75, 286);
            tbGhiChu.Margin = new Padding(4);
            tbGhiChu.Name = "tbGhiChu";
            tbGhiChu.Size = new Size(567, 38);
            tbGhiChu.TabIndex = 171;
            // 
            // lbGhiChu
            // 
            lbGhiChu.AutoSize = true;
            lbGhiChu.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbGhiChu.Location = new Point(75, 246);
            lbGhiChu.Margin = new Padding(4, 0, 4, 0);
            lbGhiChu.Name = "lbGhiChu";
            lbGhiChu.Size = new Size(83, 28);
            lbGhiChu.TabIndex = 173;
            lbGhiChu.Text = "Ghi chú";
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
            vbHoTen.Location = new Point(64, 278);
            vbHoTen.Margin = new Padding(4);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(596, 60);
            vbHoTen.TabIndex = 172;
            vbHoTen.Text = "vbButton1";
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // tbCaLam
            // 
            tbCaLam.BorderStyle = BorderStyle.None;
            tbCaLam.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            tbCaLam.Location = new Point(75, 160);
            tbCaLam.Margin = new Padding(4);
            tbCaLam.Name = "tbCaLam";
            tbCaLam.Size = new Size(135, 38);
            tbCaLam.TabIndex = 174;
            tbCaLam.TextChanged += tbCaLam_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 176;
            label1.Text = "Ca làm";
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
            vbButton1.Location = new Point(64, 152);
            vbButton1.Margin = new Padding(4);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(164, 60);
            vbButton1.TabIndex = 175;
            vbButton1.Text = "vbButton1";
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(279, 121);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 28);
            label2.TabIndex = 179;
            label2.Text = "Ngày tái khám";
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
            vbButton2.Location = new Point(268, 153);
            vbButton2.Margin = new Padding(4);
            vbButton2.Name = "vbButton2";
            vbButton2.Size = new Size(388, 60);
            vbButton2.TabIndex = 178;
            vbButton2.Text = "vbButton1";
            vbButton2.TextColor = Color.White;
            vbButton2.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(279, 162);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(363, 37);
            dateTimePicker.TabIndex = 180;
            dateTimePicker.ValueChanged += dtpNgayHen_ValueChanged;
            // 
            // FormDatLichHen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(698, 563);
            Controls.Add(dateTimePicker);
            Controls.Add(label2);
            Controls.Add(vbButton2);
            Controls.Add(tbCaLam);
            Controls.Add(label1);
            Controls.Add(vbButton1);
            Controls.Add(tbGhiChu);
            Controls.Add(lbGhiChu);
            Controls.Add(vbHoTen);
            Controls.Add(vbHuy);
            Controls.Add(vbXacNhan);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDatLichHen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đặt lịch hẹn";
            Load += FormDatLichHen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomButton.VBButton vbXacNhan;
        private CustomButton.VBButton vbHuy;
        private TextBox tbGhiChu;
        private Label lbGhiChu;
        private CustomButton.VBButton vbHoTen;
        private TextBox tbCaLam;
        private Label label1;
        private CustomButton.VBButton vbButton1;
        private Label label2;
        private CustomButton.VBButton vbButton2;
        private DateTimePicker dateTimePicker;
    }
}