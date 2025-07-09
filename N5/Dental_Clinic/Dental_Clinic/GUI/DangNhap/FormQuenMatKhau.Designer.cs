using Dental_Clinic.Properties;
namespace Dental_Clinic.GUI.Login
{
    partial class FormQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuenMatKhau));
            pictureBox2 = new PictureBox();
            label1 = new Label();
            tbEmail = new TextBox();
            tbUsername = new TextBox();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tbCode = new TextBox();
            pictureBox4 = new PictureBox();
            panel2 = new Panel();
            picBack = new PictureBox();
            vbSendCode = new CustomButton.VBButton();
            vbButton2 = new CustomButton.VBButton();
            lbSai = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBack).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(206, 15);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 124);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(165, 143);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(312, 54);
            label1.TabIndex = 4;
            label1.Text = "Quên mật khẩu";
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Cursor = Cursors.IBeam;
            tbEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbEmail.Location = new Point(176, 316);
            tbEmail.Margin = new Padding(4);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(362, 37);
            tbEmail.TabIndex = 2;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Cursor = Cursors.IBeam;
            tbUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbUsername.Location = new Point(176, 222);
            tbUsername.Margin = new Padding(4);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(363, 37);
            tbUsername.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 89, 253);
            panel3.Location = new Point(104, 370);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(435, 4);
            panel3.TabIndex = 17;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Resources.icons8_email_50;
            pictureBox3.Location = new Point(104, 307);
            pictureBox3.Margin = new Padding(4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(56, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_user_60;
            pictureBox1.Location = new Point(104, 213);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 89, 253);
            panel1.Location = new Point(104, 276);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 4);
            panel1.TabIndex = 14;
            // 
            // tbCode
            // 
            tbCode.BorderStyle = BorderStyle.None;
            tbCode.Cursor = Cursors.IBeam;
            tbCode.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbCode.Location = new Point(176, 416);
            tbCode.Margin = new Padding(4);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(241, 37);
            tbCode.TabIndex = 4;
            tbCode.KeyPress += tbCode_KeyPress;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Resources.icons8_authentication_60;
            pictureBox4.Location = new Point(104, 407);
            pictureBox4.Margin = new Padding(4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(56, 55);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 89, 253);
            panel2.Location = new Point(104, 470);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(320, 4);
            panel2.TabIndex = 21;
            // 
            // picBack
            // 
            picBack.Cursor = Cursors.Hand;
            picBack.Image = Resources.icons8_back_50;
            picBack.Location = new Point(15, 15);
            picBack.Margin = new Padding(4);
            picBack.Name = "picBack";
            picBack.Size = new Size(70, 45);
            picBack.SizeMode = PictureBoxSizeMode.Zoom;
            picBack.TabIndex = 26;
            picBack.TabStop = false;
            picBack.Click += picBack_Click;
            // 
            // vbSendCode
            // 
            vbSendCode.BackColor = SystemColors.Window;
            vbSendCode.BackgroundColor = SystemColors.Window;
            vbSendCode.BorderColor = Color.Black;
            vbSendCode.BorderRadius = 10;
            vbSendCode.BorderSize = 1;
            vbSendCode.Cursor = Cursors.Hand;
            vbSendCode.FlatAppearance.BorderSize = 0;
            vbSendCode.FlatStyle = FlatStyle.Flat;
            vbSendCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbSendCode.ForeColor = Color.Black;
            vbSendCode.Location = new Point(432, 416);
            vbSendCode.Margin = new Padding(4);
            vbSendCode.Name = "vbSendCode";
            vbSendCode.Size = new Size(106, 55);
            vbSendCode.TabIndex = 3;
            vbSendCode.Text = "Gửi Mã";
            vbSendCode.TextColor = Color.Black;
            vbSendCode.UseVisualStyleBackColor = false;
            vbSendCode.Click += vbSendCode_Click;
            // 
            // vbButton2
            // 
            vbButton2.BackColor = SystemColors.Highlight;
            vbButton2.BackgroundColor = SystemColors.Highlight;
            vbButton2.BorderColor = Color.PaleVioletRed;
            vbButton2.BorderRadius = 10;
            vbButton2.BorderSize = 0;
            vbButton2.Cursor = Cursors.Hand;
            vbButton2.FlatAppearance.BorderSize = 0;
            vbButton2.FlatStyle = FlatStyle.Flat;
            vbButton2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbButton2.ForeColor = Color.White;
            vbButton2.Location = new Point(104, 508);
            vbButton2.Margin = new Padding(4);
            vbButton2.Name = "vbButton2";
            vbButton2.Size = new Size(434, 59);
            vbButton2.TabIndex = 5;
            vbButton2.Text = "Xác Nhận";
            vbButton2.TextColor = Color.White;
            vbButton2.UseVisualStyleBackColor = false;
            vbButton2.Click += btnXacNhan_Click;
            // 
            // lbSai
            // 
            lbSai.Anchor = AnchorStyles.Top;
            lbSai.AutoSize = true;
            lbSai.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbSai.ForeColor = Color.FromArgb(192, 0, 0);
            lbSai.Location = new Point(171, 581);
            lbSai.Margin = new Padding(4, 0, 4, 0);
            lbSai.Name = "lbSai";
            lbSai.Size = new Size(300, 28);
            lbSai.TabIndex = 29;
            lbSai.Text = "Sai tài khoản hoặc sai mật khẩu";
            lbSai.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormQuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(642, 679);
            Controls.Add(lbSai);
            Controls.Add(vbButton2);
            Controls.Add(vbSendCode);
            Controls.Add(picBack);
            Controls.Add(tbCode);
            Controls.Add(pictureBox4);
            Controls.Add(panel2);
            Controls.Add(tbEmail);
            Controls.Add(tbUsername);
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Margin = new Padding(4);
            Name = "FormQuenMatKhau";
            Text = "ForgotPassword";
            Load += ForgotPassword_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label1;
        private TextBox tbEmail;
        private TextBox tbUsername;
        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox tbCode;
        private PictureBox pictureBox4;
        private Panel panel2;
        private PictureBox picBack;
        private CustomButton.VBButton vbSendCode;
        private CustomButton.VBButton vbButton2;
        private Label lbSai;
    }
}