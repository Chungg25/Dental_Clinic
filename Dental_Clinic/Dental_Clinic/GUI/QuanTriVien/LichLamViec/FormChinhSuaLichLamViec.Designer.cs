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
            panelLichLamViec = new Panel();
            pbQuayVe = new PictureBox();
            dtpLichLamViec = new DateTimePicker();
            pnTop = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).BeginInit();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelLichLamViec
            // 
            panelLichLamViec.Location = new Point(40, 156);
            panelLichLamViec.Margin = new Padding(4);
            panelLichLamViec.Name = "panelLichLamViec";
            panelLichLamViec.Size = new Size(1197, 585);
            panelLichLamViec.TabIndex = 45;
            // 
            // pbQuayVe
            // 
            pbQuayVe.Image = Resources.icons8_back_50;
            pbQuayVe.Location = new Point(13, 88);
            pbQuayVe.Margin = new Padding(4);
            pbQuayVe.Name = "pbQuayVe";
            pbQuayVe.Size = new Size(88, 49);
            pbQuayVe.SizeMode = PictureBoxSizeMode.Zoom;
            pbQuayVe.TabIndex = 47;
            pbQuayVe.TabStop = false;
            pbQuayVe.Click += pbQuayVe_Click;
            // 
            // dtpLichLamViec
            // 
            dtpLichLamViec.CustomFormat = "";
            dtpLichLamViec.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpLichLamViec.Location = new Point(901, 88);
            dtpLichLamViec.Margin = new Padding(4);
            dtpLichLamViec.Name = "dtpLichLamViec";
            dtpLichLamViec.Size = new Size(336, 37);
            dtpLichLamViec.TabIndex = 48;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(panel1);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 49;
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
            label1.Size = new Size(478, 54);
            label1.TabIndex = 0;
            label1.Text = "Chỉnh Sửa Lịch Làm Việc";
            // 
            // FormChinhSuaLichLamViec
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(dtpLichLamViec);
            Controls.Add(pbQuayVe);
            Controls.Add(panelLichLamViec);
            Margin = new Padding(4);
            Name = "FormChinhSuaLichLamViec";
            Text = "EditWorkScheduleForm";
            ((System.ComponentModel.ISupportInitialize)pbQuayVe).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelLichLamViec;
        private PictureBox pbQuayVe;
        private DateTimePicker dtpLichLamViec;
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}