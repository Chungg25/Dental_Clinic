using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.LeTan
{
    partial class FormTrangChuLeTan
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
            dateTimePicker = new DateTimePicker();
            pnLine = new Panel();
            pbLichHen = new PictureBox();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbLichHen = new CustomButton.VBButton();
            vbBacSi = new CustomButton.VBButton();
            pbBacSi = new PictureBox();
            vbThemLichHen = new CustomButton.VBButton();
            pbThemLichHen = new PictureBox();
            pnChinh = new Panel();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLichHen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBacSi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbThemLichHen).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(60, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(208, 54);
            label1.TabIndex = 0;
            label1.Text = "Trang chủ";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(dateTimePicker);
            pnTop.Controls.Add(pnLine);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 17;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.CustomFormat = "dddd, dd/MM/yyyy";
            dateTimePicker.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.ImeMode = ImeMode.NoControl;
            dateTimePicker.Location = new Point(945, 25);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.Size = new Size(304, 39);
            dateTimePicker.TabIndex = 2;
            dateTimePicker.Value = new DateTime(2024, 11, 1, 20, 26, 21, 0);
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(60, 70);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1210, 2);
            pnLine.TabIndex = 1;
            // 
            // pbLichHen
            // 
            pbLichHen.BackColor = Color.DarkBlue;
            pbLichHen.Image = Resources.icons8_calendar_64;
            pbLichHen.Location = new Point(377, 119);
            pbLichHen.Margin = new Padding(4);
            pbLichHen.Name = "pbLichHen";
            pbLichHen.Size = new Size(45, 45);
            pbLichHen.SizeMode = PictureBoxSizeMode.Zoom;
            pbLichHen.TabIndex = 28;
            pbLichHen.TabStop = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(917, 128);
            tbTimKiem.Margin = new Padding(4);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(323, 24);
            tbTimKiem.TabIndex = 29;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(864, 120);
            pictureBox8.Margin = new Padding(4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(39, 44);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 30;
            pictureBox8.TabStop = false;
            // 
            // vbTimKiem
            // 
            vbTimKiem.BackColor = SystemColors.ButtonFace;
            vbTimKiem.BackgroundColor = SystemColors.ButtonFace;
            vbTimKiem.BorderColor = Color.PaleVioletRed;
            vbTimKiem.BorderRadius = 14;
            vbTimKiem.BorderSize = 0;
            vbTimKiem.FlatAppearance.BorderSize = 0;
            vbTimKiem.FlatStyle = FlatStyle.Flat;
            vbTimKiem.ForeColor = Color.White;
            vbTimKiem.Location = new Point(848, 108);
            vbTimKiem.Margin = new Padding(4);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(401, 64);
            vbTimKiem.TabIndex = 32;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbLichHen
            // 
            vbLichHen.BackColor = Color.DarkBlue;
            vbLichHen.BackgroundColor = Color.DarkBlue;
            vbLichHen.BorderColor = Color.PaleVioletRed;
            vbLichHen.BorderRadius = 14;
            vbLichHen.BorderSize = 0;
            vbLichHen.Cursor = Cursors.Hand;
            vbLichHen.FlatAppearance.BorderSize = 0;
            vbLichHen.FlatStyle = FlatStyle.Flat;
            vbLichHen.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbLichHen.ForeColor = Color.White;
            vbLichHen.Location = new Point(267, 108);
            vbLichHen.Margin = new Padding(4);
            vbLichHen.Name = "vbLichHen";
            vbLichHen.Size = new Size(175, 64);
            vbLichHen.TabIndex = 31;
            vbLichHen.Text = "Lịch hẹn";
            vbLichHen.TextAlign = ContentAlignment.MiddleLeft;
            vbLichHen.TextColor = Color.White;
            vbLichHen.UseVisualStyleBackColor = false;
            vbLichHen.Click += vbLichHen_Click;
            // 
            // vbBacSi
            // 
            vbBacSi.BackColor = Color.DarkBlue;
            vbBacSi.BackgroundColor = Color.DarkBlue;
            vbBacSi.BorderColor = Color.PaleVioletRed;
            vbBacSi.BorderRadius = 14;
            vbBacSi.BorderSize = 0;
            vbBacSi.Cursor = Cursors.Hand;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbBacSi.ForeColor = Color.White;
            vbBacSi.Location = new Point(60, 108);
            vbBacSi.Margin = new Padding(4);
            vbBacSi.Name = "vbBacSi";
            vbBacSi.Size = new Size(154, 64);
            vbBacSi.TabIndex = 27;
            vbBacSi.Text = "Bác sĩ";
            vbBacSi.TextAlign = ContentAlignment.MiddleLeft;
            vbBacSi.TextColor = Color.White;
            vbBacSi.UseVisualStyleBackColor = false;
            vbBacSi.Click += vbBacSi_Click;
            // 
            // pbBacSi
            // 
            pbBacSi.BackColor = Color.DarkBlue;
            pbBacSi.Image = Resources.icons8_doctor_50__2_;
            pbBacSi.Location = new Point(152, 119);
            pbBacSi.Margin = new Padding(4);
            pbBacSi.Name = "pbBacSi";
            pbBacSi.Size = new Size(45, 45);
            pbBacSi.SizeMode = PictureBoxSizeMode.Zoom;
            pbBacSi.TabIndex = 26;
            pbBacSi.TabStop = false;
            // 
            // vbThemLichHen
            // 
            vbThemLichHen.BackColor = Color.DarkBlue;
            vbThemLichHen.BackgroundColor = Color.DarkBlue;
            vbThemLichHen.BorderColor = Color.PaleVioletRed;
            vbThemLichHen.BorderRadius = 14;
            vbThemLichHen.BorderSize = 0;
            vbThemLichHen.Cursor = Cursors.Hand;
            vbThemLichHen.FlatAppearance.BorderSize = 0;
            vbThemLichHen.FlatStyle = FlatStyle.Flat;
            vbThemLichHen.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold);
            vbThemLichHen.ForeColor = Color.White;
            vbThemLichHen.Location = new Point(522, 108);
            vbThemLichHen.Margin = new Padding(4);
            vbThemLichHen.Name = "vbThemLichHen";
            vbThemLichHen.Size = new Size(250, 64);
            vbThemLichHen.TabIndex = 33;
            vbThemLichHen.Text = "Thêm lịch hẹn";
            vbThemLichHen.TextAlign = ContentAlignment.MiddleLeft;
            vbThemLichHen.TextColor = Color.White;
            vbThemLichHen.UseVisualStyleBackColor = false;
            vbThemLichHen.Click += vbThemLichHen_Click;
            // 
            // pbThemLichHen
            // 
            pbThemLichHen.BackColor = Color.DarkBlue;
            pbThemLichHen.Image = Resources.icons8_plus_50;
            pbThemLichHen.Location = new Point(696, 120);
            pbThemLichHen.Margin = new Padding(4);
            pbThemLichHen.Name = "pbThemLichHen";
            pbThemLichHen.Size = new Size(45, 45);
            pbThemLichHen.SizeMode = PictureBoxSizeMode.Zoom;
            pbThemLichHen.TabIndex = 34;
            pbThemLichHen.TabStop = false;
            // 
            // pnChinh
            // 
            pnChinh.Location = new Point(60, 202);
            pnChinh.Name = "pnChinh";
            pnChinh.Size = new Size(1189, 591);
            pnChinh.TabIndex = 35;
            // 
            // FormTrangChuLeTan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnChinh);
            Controls.Add(pbThemLichHen);
            Controls.Add(vbThemLichHen);
            Controls.Add(pbBacSi);
            Controls.Add(pbLichHen);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbLichHen);
            Controls.Add(vbBacSi);
            Controls.Add(pnTop);
            Name = "FormTrangChuLeTan";
            Text = "FormTrangChuLeTan";
            Load += FormTrangChuLeTan_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLichHen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBacSi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbThemLichHen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel pnTop;
        private Panel pnLine;
        private DateTimePicker dateTimePicker;
        private PictureBox pbLichHen;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbLichHen;
        private CustomButton.VBButton vbBacSi;
        private PictureBox pbBacSi;
        private CustomButton.VBButton vbThemLichHen;
        private PictureBox pbThemLichHen;
        private Panel pnChinh;
    }
}