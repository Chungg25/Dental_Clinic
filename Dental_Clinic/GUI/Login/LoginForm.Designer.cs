using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Login
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox2 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            lbQuenMatKhau = new Label();
            pbHienMatKhau = new PictureBox();
            tbUser = new TextBox();
            tbPassword = new TextBox();
            imageList1 = new ImageList(components);
            vbDangNhap = new CustomButton.VBButton();
            lbSai = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHienMatKhau).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(211, 15);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(221, 134);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(206, 182);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(230, 54);
            label1.TabIndex = 3;
            label1.Text = "Đăng nhập";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 89, 253);
            panel1.Location = new Point(85, 344);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 4);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_user_60;
            pictureBox1.Location = new Point(85, 275);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Resources.icons8_password_52;
            pictureBox3.Location = new Point(85, 401);
            pictureBox3.Margin = new Padding(4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(56, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 89, 253);
            panel3.Location = new Point(85, 468);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(435, 4);
            panel3.TabIndex = 8;
            // 
            // lbQuenMatKhau
            // 
            lbQuenMatKhau.AutoSize = true;
            lbQuenMatKhau.Cursor = Cursors.Hand;
            lbQuenMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbQuenMatKhau.ForeColor = Color.Black;
            lbQuenMatKhau.Location = new Point(423, 491);
            lbQuenMatKhau.Margin = new Padding(4, 0, 4, 0);
            lbQuenMatKhau.Name = "lbQuenMatKhau";
            lbQuenMatKhau.Size = new Size(134, 25);
            lbQuenMatKhau.TabIndex = 10;
            lbQuenMatKhau.Text = "Quên mật khẩu";
            lbQuenMatKhau.TextAlign = ContentAlignment.MiddleCenter;
            lbQuenMatKhau.Click += lbQuenMatKhau_Click;
            // 
            // pbHienMatKhau
            // 
            pbHienMatKhau.Image = Resources.icons8_invisible_48;
            pbHienMatKhau.Location = new Point(460, 415);
            pbHienMatKhau.Margin = new Padding(4);
            pbHienMatKhau.Name = "pbHienMatKhau";
            pbHienMatKhau.Size = new Size(60, 41);
            pbHienMatKhau.SizeMode = PictureBoxSizeMode.Zoom;
            pbHienMatKhau.TabIndex = 11;
            pbHienMatKhau.TabStop = false;
            pbHienMatKhau.Click += pbHienMatKhau_Click;
            // 
            // tbUser
            // 
            tbUser.BorderStyle = BorderStyle.None;
            tbUser.Cursor = Cursors.IBeam;
            tbUser.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbUser.Location = new Point(169, 291);
            tbUser.Margin = new Padding(4);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(351, 37);
            tbUser.TabIndex = 12;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Cursor = Cursors.IBeam;
            tbPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbPassword.Location = new Point(158, 418);
            tbPassword.Margin = new Padding(4);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(295, 37);
            tbPassword.TabIndex = 13;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // vbDangNhap
            // 
            vbDangNhap.BackColor = SystemColors.Highlight;
            vbDangNhap.BackgroundColor = SystemColors.Highlight;
            vbDangNhap.BorderColor = Color.PaleVioletRed;
            vbDangNhap.BorderRadius = 20;
            vbDangNhap.BorderSize = 0;
            vbDangNhap.FlatAppearance.BorderSize = 0;
            vbDangNhap.FlatStyle = FlatStyle.Flat;
            vbDangNhap.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbDangNhap.ForeColor = Color.White;
            vbDangNhap.Location = new Point(134, 558);
            vbDangNhap.Margin = new Padding(4);
            vbDangNhap.Name = "vbDangNhap";
            vbDangNhap.Size = new Size(374, 66);
            vbDangNhap.TabIndex = 15;
            vbDangNhap.Text = "Đăng Nhập";
            vbDangNhap.TextColor = Color.White;
            vbDangNhap.UseVisualStyleBackColor = false;
            vbDangNhap.Click += vbDangNhap_Click;
            // 
            // lbSai
            // 
            lbSai.AutoSize = true;
            lbSai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSai.Location = new Point(159, 639);
            lbSai.Margin = new Padding(4, 0, 4, 0);
            lbSai.Name = "lbSai";
            lbSai.Size = new Size(325, 30);
            lbSai.TabIndex = 16;
            lbSai.Text = "Sai tài khoản hoặc sai mật khẩu";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(642, 679);
            Controls.Add(lbSai);
            Controls.Add(vbDangNhap);
            Controls.Add(tbPassword);
            Controls.Add(tbUser);
            Controls.Add(pbHienMatKhau);
            Controls.Add(lbQuenMatKhau);
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Margin = new Padding(4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHienMatKhau).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel panel3;
        private Label lbQuenMatKhau;
        private PictureBox pbHienMatKhau;
        private TextBox tbUser;
        private TextBox tbPassword;
        private ImageList imageList1;
        private CustomButton.VBButton vbDangNhap;
        private Label lbSai;
    }
}