namespace Dental_Clinic.GUI.BacSi.ThongTin
{
    partial class FormLichLamViec
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
            dtpLichLamViec = new DateTimePicker();
            panel1 = new Panel();
            label1 = new Label();
            panelLichLamViec = new Panel();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnTop
            // 
            pnTop.Controls.Add(dtpLichLamViec);
            pnTop.Controls.Add(panel1);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 55;
            // 
            // dtpLichLamViec
            // 
            dtpLichLamViec.CalendarFont = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpLichLamViec.CustomFormat = "dddd, dd/MM/yyyy";
            dtpLichLamViec.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpLichLamViec.Format = DateTimePickerFormat.Custom;
            dtpLichLamViec.ImeMode = ImeMode.NoControl;
            dtpLichLamViec.Location = new Point(933, 25);
            dtpLichLamViec.Name = "dtpLichLamViec";
            dtpLichLamViec.RightToLeft = RightToLeft.No;
            dtpLichLamViec.Size = new Size(304, 39);
            dtpLichLamViec.TabIndex = 10;
            dtpLichLamViec.Value = new DateTime(2024, 11, 1, 20, 26, 21, 0);
            dtpLichLamViec.ValueChanged += DtpLichLamViec_ValueChanged;
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
            label1.Size = new Size(277, 54);
            label1.TabIndex = 0;
            label1.Text = "Lịch Làm Việc";
            // 
            // panelLichLamViec
            // 
            panelLichLamViec.Location = new Point(40, 105);
            panelLichLamViec.Margin = new Padding(4);
            panelLichLamViec.Name = "panelLichLamViec";
            panelLichLamViec.Size = new Size(1197, 588);
            panelLichLamViec.TabIndex = 54;
            // 
            // FormLichLamViec
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(panelLichLamViec);
            Name = "FormLichLamViec";
            Text = "FormLichLamViec";
            Load += FormLichLamViec_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTop;
        private DateTimePicker dtpLichLamViec;
        private Panel panel1;
        private Label label1;
        private Panel panelLichLamViec;
    }
}