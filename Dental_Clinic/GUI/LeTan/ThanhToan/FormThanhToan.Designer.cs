using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    partial class FormThanhToan
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
            pnChinh = new Panel();
            label1 = new Label();
            pnTop = new Panel();
            dateTimePicker = new DateTimePicker();
            pnLine = new Panel();
            pbBacSi = new PictureBox();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbBacSi = new CustomButton.VBButton();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBacSi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // pnChinh
            // 
            pnChinh.Location = new Point(60, 185);
            pnChinh.Name = "pnChinh";
            pnChinh.Size = new Size(1185, 608);
            pnChinh.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(60, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(237, 54);
            label1.TabIndex = 0;
            label1.Text = "Thanh toán";
            // 
            // pnTop
            // 
            pnTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnTop.Controls.Add(dateTimePicker);
            pnTop.Controls.Add(pnLine);
            pnTop.Controls.Add(label1);
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 36;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.CustomFormat = "dddd, dd/MM/yyyy";
            dateTimePicker.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.ImeMode = ImeMode.NoControl;
            dateTimePicker.Location = new Point(941, 25);
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
            // pbBacSi
            // 
            pbBacSi.BackColor = Color.FromArgb(163, 211, 229);
            pbBacSi.Image = Resources.icons8_invoice_100;
            pbBacSi.Location = new Point(357, 108);
            pbBacSi.Margin = new Padding(4);
            pbBacSi.Name = "pbBacSi";
            pbBacSi.Size = new Size(45, 45);
            pbBacSi.SizeMode = PictureBoxSizeMode.Zoom;
            pbBacSi.TabIndex = 37;
            pbBacSi.TabStop = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(562, 117);
            tbTimKiem.Margin = new Padding(4);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(671, 24);
            tbTimKiem.TabIndex = 40;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(515, 109);
            pictureBox8.Margin = new Padding(4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(39, 44);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 41;
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
            vbTimKiem.Location = new Point(499, 97);
            vbTimKiem.Margin = new Padding(4);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(746, 64);
            vbTimKiem.TabIndex = 43;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbBacSi
            // 
            vbBacSi.BackColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BorderColor = Color.PaleVioletRed;
            vbBacSi.BorderRadius = 14;
            vbBacSi.BorderSize = 0;
            vbBacSi.Cursor = Cursors.Hand;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBacSi.ForeColor = Color.White;
            vbBacSi.Location = new Point(60, 97);
            vbBacSi.Margin = new Padding(4);
            vbBacSi.Name = "vbBacSi";
            vbBacSi.Size = new Size(356, 64);
            vbBacSi.TabIndex = 38;
            vbBacSi.Text = "Danh sách thanh toán";
            vbBacSi.TextAlign = ContentAlignment.MiddleLeft;
            vbBacSi.TextColor = Color.White;
            vbBacSi.UseVisualStyleBackColor = false;
            // 
            // FormThanhToan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnChinh);
            Controls.Add(pnTop);
            Controls.Add(pbBacSi);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbBacSi);
            Name = "FormThanhToan";
            Text = "FormThanhToan";
            Load += FormThanhToan_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBacSi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnChinh;
        private Label label1;
        private Panel pnTop;
        private DateTimePicker dateTimePicker;
        private Panel pnLine;
        private PictureBox pbBacSi;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbBacSi;
    }
}