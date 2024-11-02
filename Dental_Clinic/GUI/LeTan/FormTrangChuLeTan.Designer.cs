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
            GirdHienThiDanhSach = new DataGridView();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GirdHienThiDanhSach).BeginInit();
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
            dateTimePicker.Location = new Point(954, 21);
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
            // GirdHienThiDanhSach
            // 
            GirdHienThiDanhSach.BackgroundColor = Color.White;
            GirdHienThiDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GirdHienThiDanhSach.Location = new Point(12, 87);
            GirdHienThiDanhSach.Name = "GirdHienThiDanhSach";
            GirdHienThiDanhSach.RowHeadersWidth = 62;
            GirdHienThiDanhSach.Size = new Size(1246, 706);
            GirdHienThiDanhSach.TabIndex = 18;
            // 
            // FormTrangChuLeTan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(GirdHienThiDanhSach);
            Controls.Add(pnTop);
            Name = "FormTrangChuLeTan";
            Text = "FormTrangChuLeTan";
            Load += FormTrangChuLeTan_Load;
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GirdHienThiDanhSach).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel pnTop;
        private Panel pnLine;
        private DateTimePicker dateTimePicker;
        private DataGridView GirdHienThiDanhSach;
    }
}