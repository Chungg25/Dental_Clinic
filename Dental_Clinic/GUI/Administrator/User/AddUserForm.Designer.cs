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
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            textBox1 = new TextBox();
            label4 = new Label();
            vbHoTen = new CustomButton.VBButton();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(278, 46);
            label1.TabIndex = 0;
            label1.Text = "Thêm bác sĩ mới";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(-9, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(1031, 502);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(vbHoTen);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(21, 15);
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
            label4.Click += this.label4_Click;
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label4;
        private CustomButton.VBButton vbHoTen;
        private TextBox textBox1;
    }
}