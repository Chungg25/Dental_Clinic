using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.BacSi
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
            label8 = new Label();
            panel8 = new Panel();
            label9 = new Label();
            label1 = new Label();
            pnTop = new Panel();
            pnLine = new Panel();
            panel8.SuspendLayout();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(26, 24);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(294, 41);
            label8.TabIndex = 0;
            label8.Text = "Thống kê doanh thu";
            // 
            // panel8
            // 
            panel8.Controls.Add(label9);
            panel8.Controls.Add(label8);
            panel8.Location = new Point(64, 88);
            panel8.Margin = new Padding(4);
            panel8.Name = "panel8";
            panel8.Size = new Size(1137, 704);
            panel8.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(431, 242);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(393, 25);
            label9.TabIndex = 1;
            label9.Text = "Làm được thì mừng không thì copy hình dán vô";
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
            pnTop.Controls.Add(pnLine);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 9;
            // 
            // pnLine
            // 
            pnLine.BackColor = Color.Black;
            pnLine.Location = new Point(60, 70);
            pnLine.Name = "pnLine";
            pnLine.Size = new Size(1210, 2);
            pnLine.TabIndex = 1;
            // 
            // FormTrangChuBacSi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1270, 805);
            Controls.Add(panel8);
            Controls.Add(pnTop);
            Name = "FormTrangChuBacSi";
            Text = "FormTrangChuBacSi";
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label8;
        private Panel panel8;
        private Label label9;
        private Label label1;
        private Panel pnTop;
        private Panel pnLine;
    }
}