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
            pictureBox4 = new PictureBox();
            tbUser = new TextBox();
            tbPassword = new TextBox();
            imageList1 = new ImageList(components);
            vbButton1 = new CustomButton.VBButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(144, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(236, 125);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(162, 146);
            label1.Name = "label1";
            label1.Size = new Size(194, 46);
            label1.TabIndex = 3;
            label1.Text = "Đăng nhập";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 89, 253);
            panel1.Location = new Point(81, 275);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 3);
            panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_user_60;
            pictureBox1.Location = new Point(81, 220);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Resources.icons8_password_52;
            pictureBox3.Location = new Point(81, 321);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 89, 253);
            panel3.Location = new Point(81, 374);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 3);
            panel3.TabIndex = 8;
            // 
            // lbQuenMatKhau
            // 
            lbQuenMatKhau.AutoSize = true;
            lbQuenMatKhau.Cursor = Cursors.Hand;
            lbQuenMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbQuenMatKhau.ForeColor = Color.Black;
            lbQuenMatKhau.Location = new Point(351, 393);
            lbQuenMatKhau.Name = "lbQuenMatKhau";
            lbQuenMatKhau.Size = new Size(109, 20);
            lbQuenMatKhau.TabIndex = 10;
            lbQuenMatKhau.Text = "Quên mật khẩu";
            lbQuenMatKhau.TextAlign = ContentAlignment.MiddleCenter;
            lbQuenMatKhau.Click += lbQuenMatKhau_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Resources.icons8_invisible_48;
            pictureBox4.Location = new Point(381, 332);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 33);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // tbUser
            // 
            tbUser.BorderStyle = BorderStyle.None;
            tbUser.Cursor = Cursors.IBeam;
            tbUser.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbUser.Location = new Point(148, 233);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(281, 31);
            tbUser.TabIndex = 12;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Cursor = Cursors.IBeam;
            tbPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbPassword.Location = new Point(139, 334);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(236, 31);
            tbPassword.TabIndex = 13;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // vbButton1
            // 
            vbButton1.BackColor = SystemColors.Highlight;
            vbButton1.BackgroundColor = SystemColors.Highlight;
            vbButton1.BorderColor = Color.PaleVioletRed;
            vbButton1.BorderRadius = 20;
            vbButton1.BorderSize = 0;
            vbButton1.FlatAppearance.BorderSize = 0;
            vbButton1.FlatStyle = FlatStyle.Flat;
            vbButton1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbButton1.ForeColor = Color.White;
            vbButton1.Location = new Point(100, 446);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(299, 53);
            vbButton1.TabIndex = 15;
            vbButton1.Text = "Đăng Nhập";
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(514, 543);
            Controls.Add(vbButton1);
            Controls.Add(tbPassword);
            Controls.Add(tbUser);
            Controls.Add(pictureBox4);
            Controls.Add(lbQuenMatKhau);
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
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
        private PictureBox pictureBox4;
        private TextBox tbUser;
        private TextBox tbPassword;
        private ImageList imageList1;
        private CustomButton.VBButton vbButton1;
    }
}