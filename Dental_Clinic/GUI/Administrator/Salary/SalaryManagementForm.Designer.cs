using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class SalaryManagementForm
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
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            vbLeTan = new CustomButton.VBButton();
            vbBacSi = new CustomButton.VBButton();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            panelDuLieu = new Panel();
            dateTimePicker1 = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(261, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Lương";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox3.Image = Resources.icons8_reception_30;
            pictureBox3.Location = new Point(332, 116);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 32);
            pictureBox3.TabIndex = 35;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox1.Image = Resources.icons8_doctor_50__2_;
            pictureBox1.Location = new Point(130, 115);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 34;
            pictureBox1.TabStop = false;
            // 
            // vbLeTan
            // 
            vbLeTan.BackColor = Color.FromArgb(163, 211, 229);
            vbLeTan.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbLeTan.BorderColor = Color.PaleVioletRed;
            vbLeTan.BorderRadius = 10;
            vbLeTan.BorderSize = 0;
            vbLeTan.Cursor = Cursors.Hand;
            vbLeTan.FlatAppearance.BorderSize = 0;
            vbLeTan.FlatStyle = FlatStyle.Flat;
            vbLeTan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbLeTan.ForeColor = Color.White;
            vbLeTan.Location = new Point(236, 103);
            vbLeTan.Name = "vbLeTan";
            vbLeTan.Size = new Size(149, 57);
            vbLeTan.TabIndex = 37;
            vbLeTan.Text = "Lễ tân";
            vbLeTan.TextAlign = ContentAlignment.MiddleLeft;
            vbLeTan.TextColor = Color.White;
            vbLeTan.UseVisualStyleBackColor = false;
            vbLeTan.Click += vbLeTan_Click;
            // 
            // vbBacSi
            // 
            vbBacSi.BackColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbBacSi.BorderColor = Color.PaleVioletRed;
            vbBacSi.BorderRadius = 12;
            vbBacSi.BorderSize = 0;
            vbBacSi.Cursor = Cursors.Hand;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbBacSi.ForeColor = Color.White;
            vbBacSi.Location = new Point(34, 103);
            vbBacSi.Name = "vbBacSi";
            vbBacSi.Size = new Size(154, 57);
            vbBacSi.TabIndex = 36;
            vbBacSi.Text = "Bác sĩ";
            vbBacSi.TextAlign = ContentAlignment.MiddleLeft;
            vbBacSi.TextColor = Color.White;
            vbBacSi.UseVisualStyleBackColor = false;
            vbBacSi.Click += vbBacSi_Click;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(772, 116);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(183, 20);
            tbTimKiem.TabIndex = 38;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(715, 110);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(44, 45);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 39;
            pictureBox8.TabStop = false;
            // 
            // vbTimKiem
            // 
            vbTimKiem.BackColor = SystemColors.ButtonFace;
            vbTimKiem.BackgroundColor = SystemColors.ButtonFace;
            vbTimKiem.BorderColor = Color.PaleVioletRed;
            vbTimKiem.BorderRadius = 15;
            vbTimKiem.BorderSize = 0;
            vbTimKiem.FlatAppearance.BorderSize = 0;
            vbTimKiem.FlatStyle = FlatStyle.Flat;
            vbTimKiem.ForeColor = Color.White;
            vbTimKiem.Location = new Point(701, 103);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(278, 57);
            vbTimKiem.TabIndex = 40;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Location = new Point(7, 202);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(1012, 454);
            panelDuLieu.TabIndex = 41;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(527, 111);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 42;
            // 
            // SalaryManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(dateTimePicker1);
            Controls.Add(panelDuLieu);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(vbLeTan);
            Controls.Add(vbBacSi);
            Controls.Add(panel1);
            Name = "SalaryManagementForm";
            Text = "SalaryManagementForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbLeTan;
        private CustomButton.VBButton vbBacSi;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private Panel panelDuLieu;
        private DateTimePicker dateTimePicker1;
    }
}