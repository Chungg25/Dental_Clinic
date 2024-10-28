using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Doctor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            picDash = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            lbLuong = new Label();
            lbLichLamViec = new Label();
            lbUser = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            lbNgonNgu = new Label();
            pictureBox13 = new PictureBox();
            label8 = new Label();
            picUser = new PictureBox();
            lbChuDe = new Label();
            pictureBox8 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picDash).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // picDash
            // 
            picDash.BackColor = SystemColors.Window;
            picDash.Image = (Image)resources.GetObject("picDash.Image");
            picDash.Location = new Point(45, 4);
            picDash.Margin = new Padding(4, 4, 4, 4);
            picDash.Name = "picDash";
            picDash.Size = new Size(295, 156);
            picDash.TabIndex = 4;
            picDash.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lbLuong);
            panel1.Controls.Add(lbLichLamViec);
            panel1.Controls.Add(lbUser);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(-15, -12);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 983);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Location = new Point(382, 4);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(611, 156);
            panel2.TabIndex = 5;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Resources.icons8_sales_performance_50;
            pictureBox6.Location = new Point(28, 439);
            pictureBox6.Margin = new Padding(4, 4, 4, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(68, 65);
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Resources.icons8_schedule_50;
            pictureBox4.Location = new Point(28, 330);
            pictureBox4.Margin = new Padding(4, 4, 4, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(68, 60);
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.icons8_recovery_50;
            pictureBox1.Location = new Point(24, 226);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lbLuong
            // 
            lbLuong.AutoSize = true;
            lbLuong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLuong.Location = new Point(106, 458);
            lbLuong.Margin = new Padding(4, 0, 4, 0);
            lbLuong.Name = "lbLuong";
            lbLuong.Size = new Size(184, 32);
            lbLuong.TabIndex = 10;
            lbLuong.Text = "Quản lý lương ";
            // 
            // lbLichLamViec
            // 
            lbLichLamViec.AutoSize = true;
            lbLichLamViec.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLichLamViec.Location = new Point(106, 346);
            lbLichLamViec.Margin = new Padding(4, 0, 4, 0);
            lbLichLamViec.Name = "lbLichLamViec";
            lbLichLamViec.Size = new Size(250, 32);
            lbLichLamViec.TabIndex = 7;
            lbLichLamViec.Text = "Quản lý lịch làm việc";
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUser.Location = new Point(106, 244);
            lbUser.Margin = new Padding(4, 0, 4, 0);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(230, 32);
            lbUser.TabIndex = 5;
            lbUser.Text = "Quản lý bệnh nhân";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(45, 4);
            pictureBox2.Margin = new Padding(4, 4, 4, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(291, 156);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(32, 155, 220);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lbNgonNgu);
            panel3.Controls.Add(pictureBox13);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(picUser);
            panel3.Controls.Add(lbChuDe);
            panel3.Controls.Add(pictureBox8);
            panel3.Location = new Point(358, -4);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1337, 103);
            panel3.TabIndex = 6;
            // 
            // lbNgonNgu
            // 
            lbNgonNgu.AutoSize = true;
            lbNgonNgu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNgonNgu.ForeColor = SystemColors.ButtonHighlight;
            lbNgonNgu.Location = new Point(634, 42);
            lbNgonNgu.Margin = new Padding(4, 0, 4, 0);
            lbNgonNgu.Name = "lbNgonNgu";
            lbNgonNgu.Size = new Size(131, 32);
            lbNgonNgu.TabIndex = 9;
            lbNgonNgu.Text = "Ngôn ngữ";
            // 
            // pictureBox13
            // 
            pictureBox13.Image = Resources.icons8_language_50;
            pictureBox13.Location = new Point(570, 29);
            pictureBox13.Margin = new Padding(4, 4, 4, 4);
            pictureBox13.Name = "pictureBox13";
            pictureBox13.Size = new Size(56, 60);
            pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox13.TabIndex = 8;
            pictureBox13.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(1188, 44);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(59, 29);
            label8.TabIndex = 6;
            label8.Text = "Kiệt";
            // 
            // picUser
            // 
            picUser.Image = Resources.icons8_admin_40;
            picUser.Location = new Point(1124, 29);
            picUser.Margin = new Padding(4, 4, 4, 4);
            picUser.Name = "picUser";
            picUser.Size = new Size(56, 60);
            picUser.SizeMode = PictureBoxSizeMode.Zoom;
            picUser.TabIndex = 6;
            picUser.TabStop = false;
            // 
            // lbChuDe
            // 
            lbChuDe.AutoSize = true;
            lbChuDe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChuDe.ForeColor = SystemColors.ButtonHighlight;
            lbChuDe.Location = new Point(906, 44);
            lbChuDe.Margin = new Padding(4, 0, 4, 0);
            lbChuDe.Name = "lbChuDe";
            lbChuDe.Size = new Size(93, 32);
            lbChuDe.TabIndex = 7;
            lbChuDe.Text = "Chủ đề";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Resources.icons8_draw_50;
            pictureBox8.Location = new Point(842, 29);
            pictureBox8.Margin = new Padding(4, 4, 4, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(56, 60);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 6;
            pictureBox8.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1671, 966);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(picDash);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)picDash).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picDash;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private Label lbLuong;
        private Label lbLichLamViec;
        private Label lbUser;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Label lbNgonNgu;
        private PictureBox pictureBox13;
        private Label label8;
        private PictureBox picUser;
        private Label lbChuDe;
        private PictureBox pictureBox8;
    }
}