using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class FormVatTu
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
            vbThuoc = new CustomButton.VBButton();
            pictureBox7 = new PictureBox();
            tbTimKiem = new TextBox();
            pictureBox8 = new PictureBox();
            vbTimKiem = new CustomButton.VBButton();
            vbThem = new CustomButton.VBButton();
            panelDuLieu = new Panel();
            pictureBox2 = new PictureBox();
            vbDichVu = new CustomButton.VBButton();
            vbVatTu = new CustomButton.VBButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(264, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Vật Tư";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox3.Image = Resources.icons8_supplies_50;
            pictureBox3.Location = new Point(244, 116);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 40;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox1.Image = Resources.icons8_medicine_50;
            pictureBox1.Location = new Point(94, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // vbThuoc
            // 
            vbThuoc.BackColor = Color.FromArgb(163, 211, 229);
            vbThuoc.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThuoc.BorderColor = Color.PaleVioletRed;
            vbThuoc.BorderRadius = 12;
            vbThuoc.BorderSize = 0;
            vbThuoc.Cursor = Cursors.Hand;
            vbThuoc.FlatAppearance.BorderSize = 0;
            vbThuoc.FlatStyle = FlatStyle.Flat;
            vbThuoc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThuoc.ForeColor = Color.White;
            vbThuoc.Location = new Point(9, 103);
            vbThuoc.Name = "vbThuoc";
            vbThuoc.Size = new Size(140, 57);
            vbThuoc.TabIndex = 41;
            vbThuoc.Text = "Thuốc";
            vbThuoc.TextAlign = ContentAlignment.MiddleLeft;
            vbThuoc.TextColor = Color.White;
            vbThuoc.UseVisualStyleBackColor = false;
            vbThuoc.Click += vbThuoc_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox7.Image = Resources.icons8_plus_50;
            pictureBox7.Location = new Point(644, 108);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(47, 47);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 34;
            pictureBox7.TabStop = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.BackColor = SystemColors.ButtonFace;
            tbTimKiem.BorderStyle = BorderStyle.None;
            tbTimKiem.Location = new Point(793, 116);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(183, 20);
            tbTimKiem.TabIndex = 35;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = SystemColors.ButtonFace;
            pictureBox8.Image = Resources.icons8_find_50;
            pictureBox8.Location = new Point(736, 110);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(44, 45);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 36;
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
            vbTimKiem.Location = new Point(722, 103);
            vbTimKiem.Name = "vbTimKiem";
            vbTimKiem.Size = new Size(278, 57);
            vbTimKiem.TabIndex = 38;
            vbTimKiem.TextColor = Color.White;
            vbTimKiem.UseVisualStyleBackColor = false;
            // 
            // vbThem
            // 
            vbThem.BackColor = Color.FromArgb(163, 211, 229);
            vbThem.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbThem.BorderColor = Color.PaleVioletRed;
            vbThem.BorderRadius = 8;
            vbThem.BorderSize = 0;
            vbThem.Cursor = Cursors.Hand;
            vbThem.FlatAppearance.BorderSize = 0;
            vbThem.FlatStyle = FlatStyle.Flat;
            vbThem.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbThem.ForeColor = Color.White;
            vbThem.Location = new Point(574, 103);
            vbThem.Name = "vbThem";
            vbThem.Size = new Size(130, 57);
            vbThem.TabIndex = 37;
            vbThem.Text = "Thêm";
            vbThem.TextAlign = ContentAlignment.MiddleLeft;
            vbThem.TextColor = Color.White;
            vbThem.UseVisualStyleBackColor = false;
            vbThem.Click += vbThem_Click;
            // 
            // panelDuLieu
            // 
            panelDuLieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDuLieu.Location = new Point(7, 202);
            panelDuLieu.Name = "panelDuLieu";
            panelDuLieu.Size = new Size(1209, 454);
            panelDuLieu.TabIndex = 43;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(163, 211, 229);
            pictureBox2.Image = Resources.icons8_service_50;
            pictureBox2.Location = new Point(400, 117);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 43;
            pictureBox2.TabStop = false;
            // 
            // vbDichVu
            // 
            vbDichVu.BackColor = Color.FromArgb(163, 211, 229);
            vbDichVu.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbDichVu.BorderColor = Color.PaleVioletRed;
            vbDichVu.BorderRadius = 10;
            vbDichVu.BorderSize = 0;
            vbDichVu.Cursor = Cursors.Hand;
            vbDichVu.FlatAppearance.BorderSize = 0;
            vbDichVu.FlatStyle = FlatStyle.Flat;
            vbDichVu.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbDichVu.ForeColor = Color.White;
            vbDichVu.Location = new Point(304, 103);
            vbDichVu.Name = "vbDichVu";
            vbDichVu.Size = new Size(143, 57);
            vbDichVu.TabIndex = 44;
            vbDichVu.Text = "Dịch vụ";
            vbDichVu.TextAlign = ContentAlignment.MiddleLeft;
            vbDichVu.TextColor = Color.White;
            vbDichVu.UseVisualStyleBackColor = false;
            vbDichVu.Click += vbDichVu_Click;
            // 
            // vbVatTu
            // 
            vbVatTu.BackColor = Color.FromArgb(163, 211, 229);
            vbVatTu.BackgroundColor = Color.FromArgb(163, 211, 229);
            vbVatTu.BorderColor = Color.PaleVioletRed;
            vbVatTu.BorderRadius = 10;
            vbVatTu.BorderSize = 0;
            vbVatTu.Cursor = Cursors.Hand;
            vbVatTu.FlatAppearance.BorderSize = 0;
            vbVatTu.FlatStyle = FlatStyle.Flat;
            vbVatTu.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbVatTu.ForeColor = Color.White;
            vbVatTu.Location = new Point(159, 103);
            vbVatTu.Name = "vbVatTu";
            vbVatTu.Size = new Size(133, 57);
            vbVatTu.TabIndex = 42;
            vbVatTu.Text = "Vật tư";
            vbVatTu.TextAlign = ContentAlignment.MiddleLeft;
            vbVatTu.TextColor = Color.White;
            vbVatTu.UseVisualStyleBackColor = false;
            vbVatTu.Click += vbVatTu_Click;
            // 
            // FormVatTu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(pictureBox2);
            Controls.Add(panelDuLieu);
            Controls.Add(vbDichVu);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(vbVatTu);
            Controls.Add(vbThuoc);
            Controls.Add(pictureBox7);
            Controls.Add(tbTimKiem);
            Controls.Add(pictureBox8);
            Controls.Add(vbTimKiem);
            Controls.Add(vbThem);
            Controls.Add(panel1);
            Name = "FormVatTu";
            Text = "SuppliesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private CustomButton.VBButton vbThuoc;
        private PictureBox pictureBox7;
        private TextBox tbTimKiem;
        private PictureBox pictureBox8;
        private CustomButton.VBButton vbTimKiem;
        private CustomButton.VBButton vbThem;
        private Panel panelDuLieu;
        private PictureBox pictureBox2;
        private CustomButton.VBButton vbDichVu;
        private CustomButton.VBButton vbVatTu;
    }
}