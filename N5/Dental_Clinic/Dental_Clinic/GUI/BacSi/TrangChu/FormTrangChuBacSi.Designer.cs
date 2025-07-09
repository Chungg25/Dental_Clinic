using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.BacSi.BenhNhan
{
    partial class FormTrangChuBacSi
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
            pnTop = new Panel();
            dateTimePicker = new DateTimePicker();
            pnLine = new Panel();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            pnChinh = new Panel();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbBenhNhan = new CustomButton.VBButton();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
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
            pnTop.TabIndex = 19;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.CustomFormat = "dddd, dd/MM/yyyy";
            dateTimePicker.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.ImeMode = ImeMode.NoControl;
            dateTimePicker.Location = new Point(908, 20);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.RightToLeft = RightToLeft.No;
            dateTimePicker.Size = new Size(350, 39);
            dateTimePicker.TabIndex = 28;
            dateTimePicker.Value = new DateTime(2024, 11, 1, 20, 26, 21, 0);
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(35, 65);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1300, 2);
            pnLine.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(35, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(395, 54);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Bệnh Nhân";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.DarkBlue;
            pictureBox5.Image = Resources.icons8_tooth_50;
            pictureBox5.Location = new Point(315, 108);
            pictureBox5.Margin = new Padding(4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(45, 45);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // pnChinh
            // 
            pnChinh.Location = new Point(35, 185);
            pnChinh.Margin = new Padding(4);
            pnChinh.Name = "pnChinh";
            pnChinh.Size = new Size(1222, 603);
            pnChinh.TabIndex = 26;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(482, 117);
            tbTimKiem.Margin = new Padding(4);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(758, 24);
            tbTimKiem.TabIndex = 22;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(429, 109);
            pictureBox8.Margin = new Padding(4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(45, 44);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 23;
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
            vbTimKiem.Location = new Point(413, 97);
            vbTimKiem.Margin = new Padding(4);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(844, 64);
            vbTimKiem.TabIndex = 25;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbBenhNhan
            // 
            vbBenhNhan.BackColor = Color.DarkBlue;
            vbBenhNhan.BackgroundColor = Color.DarkBlue;
            vbBenhNhan.BorderColor = Color.PaleVioletRed;
            vbBenhNhan.BorderRadius = 14;
            vbBenhNhan.BorderSize = 0;
            vbBenhNhan.Cursor = Cursors.Hand;
            vbBenhNhan.FlatAppearance.BorderSize = 0;
            vbBenhNhan.FlatStyle = FlatStyle.Flat;
            vbBenhNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBenhNhan.ForeColor = Color.White;
            vbBenhNhan.Location = new Point(35, 97);
            vbBenhNhan.Margin = new Padding(20, 4, 4, 20);
            vbBenhNhan.Name = "vbBenhNhan";
            vbBenhNhan.Size = new Size(345, 64);
            vbBenhNhan.TabIndex = 20;
            vbBenhNhan.Text = "Danh sách bệnh nhân";
            vbBenhNhan.TextAlign = ContentAlignment.MiddleLeft;
            vbBenhNhan.TextColor = Color.White;
            vbBenhNhan.UseVisualStyleBackColor = false;
            vbBenhNhan.Click += vbBenhNhan_Click;
            // 
            // FormTrangChuBacSi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(pictureBox5);
            Controls.Add(pnChinh);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbBenhNhan);
            Name = "FormTrangChuBacSi";
            Text = "FormBenhNhan";
            Load += FormTrangChuBacSi_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnTop;
        private Label label1;
        private PictureBox pictureBox5;
        private Panel pnChinh;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbBenhNhan;
        private Panel pnLine;
        private DateTimePicker dateTimePicker;
    }
}