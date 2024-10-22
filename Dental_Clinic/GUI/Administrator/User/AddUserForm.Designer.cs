namespace Dental_Clinic.GUI.Administrator.User
{
    partial class AddUserForm
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
            panel2 = new Panel();
            panel4 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            vbEmail = new CustomButton.VBButton();
            label5 = new Label();
            panel3 = new Panel();
            textBox1 = new TextBox();
            label4 = new Label();
            vbHoTen = new CustomButton.VBButton();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
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
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(46, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(935, 580);
            panel2.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(vbEmail);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(475, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(239, 125);
            panel4.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(18, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(166, 20);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(46, 23);
            label3.Name = "label3";
            label3.Size = new Size(15, 20);
            label3.TabIndex = 2;
            label3.Text = "*";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // vbEmail
            // 
            vbEmail.BackColor = SystemColors.Highlight;
            vbEmail.BackgroundColor = SystemColors.Highlight;
            vbEmail.BorderColor = Color.PaleVioletRed;
            vbEmail.BorderRadius = 10;
            vbEmail.BorderSize = 0;
            vbEmail.FlatAppearance.BorderSize = 0;
            vbEmail.FlatStyle = FlatStyle.Flat;
            vbEmail.ForeColor = Color.White;
            vbEmail.Location = new Point(1, 59);
            vbEmail.Name = "vbEmail";
            vbEmail.Size = new Size(192, 50);
            vbEmail.TabIndex = 2;
            vbEmail.TextColor = Color.White;
            vbEmail.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 23);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 0;
            label5.Text = "Email";
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(vbHoTen);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(175, 34);
            panel3.Name = "panel3";
            panel3.Size = new Size(239, 125);
            panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(18, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 20);
            textBox1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(72, 23);
            label4.Name = "label4";
            label4.Size = new Size(15, 20);
            label4.TabIndex = 2;
            label4.Text = "*";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // vbHoTen
            // 
            vbHoTen.BackColor = SystemColors.Highlight;
            vbHoTen.BackgroundColor = SystemColors.Highlight;
            vbHoTen.BorderColor = Color.PaleVioletRed;
            vbHoTen.BorderRadius = 10;
            vbHoTen.BorderSize = 0;
            vbHoTen.FlatAppearance.BorderSize = 0;
            vbHoTen.FlatStyle = FlatStyle.Flat;
            vbHoTen.ForeColor = Color.White;
            vbHoTen.Location = new Point(1, 59);
            vbHoTen.Name = "vbHoTen";
            vbHoTen.Size = new Size(192, 50);
            vbHoTen.TabIndex = 2;
            vbHoTen.TextColor = Color.White;
            vbHoTen.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 23);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Họ và tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(212, 46);
            label1.TabIndex = 0;
            label1.Text = "Thêm Bác Sĩ";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddUserForm";
            Text = "AddUser";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label4;
        private CustomButton.VBButton vbHoTen;
        private TextBox textBox1;
        private Panel panel4;
        private TextBox textBox2;
        private Label label3;
        private CustomButton.VBButton vbEmail;
        private Label label5;
        private Label label1;
    }
}