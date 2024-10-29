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
            pictureBox2.Location = new Point(169, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(177, 107);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(132, 140);
            label1.Name = "label1";
            label1.Size = new Size(264, 46);
            label1.TabIndex = 4;
            label1.Text = "Quên mật khẩu";
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Cursor = Cursors.IBeam;
            tbEmail.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbEmail.Location = new Point(141, 310);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(290, 31);
            tbEmail.TabIndex = 20;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Cursor = Cursors.IBeam;
            tbUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbUsername.Location = new Point(150, 210);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(281, 31);
            tbUsername.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 89, 253);
            panel3.Location = new Point(83, 354);
            panel3.Name = "panel3";
            panel3.Size = new Size(348, 3);
            panel3.TabIndex = 17;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Resources.icons8_email_50;
            pictureBox3.Location = new Point(83, 301);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_user_60;
            pictureBox1.Location = new Point(83, 200);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 89, 253);
            panel1.Location = new Point(83, 255);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 3);
            panel1.TabIndex = 14;
            // 
            // tbCode
            // 
            tbCode.BorderStyle = BorderStyle.None;
            tbCode.Cursor = Cursors.IBeam;
            tbCode.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            tbCode.Location = new Point(150, 411);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(158, 31);
            tbCode.TabIndex = 23;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Resources.icons8_authentication_60;
            pictureBox4.Location = new Point(83, 401);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(45, 44);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 89, 253);
            panel2.Location = new Point(83, 449);
            panel2.Name = "panel2";
            panel2.Size = new Size(226, 3);
            panel2.TabIndex = 21;
            // 
            // picBack
            // 
            picBack.Image = Resources.icons8_back_50;
            picBack.Location = new Point(12, 12);
            picBack.Name = "picBack";
            picBack.Size = new Size(49, 39);
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
            vbSendCode.Location = new Point(315, 405);
            vbSendCode.Name = "vbSendCode";
            vbSendCode.Size = new Size(116, 46);
            vbSendCode.TabIndex = 27;
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
            vbButton2.FlatAppearance.BorderSize = 0;
            vbButton2.FlatStyle = FlatStyle.Flat;
            vbButton2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbButton2.ForeColor = Color.White;
            vbButton2.Location = new Point(126, 486);
            vbButton2.Name = "vbButton2";
            vbButton2.Size = new Size(262, 47);
            vbButton2.TabIndex = 28;
            vbButton2.Text = "Xác Nhận";
            vbButton2.TextColor = Color.White;
            vbButton2.UseVisualStyleBackColor = false;
            vbButton2.Click += btnXacNhan_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(514, 543);
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
            Name = "ForgotPassword";
            Text = "ForgotPassword";
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
    }
}