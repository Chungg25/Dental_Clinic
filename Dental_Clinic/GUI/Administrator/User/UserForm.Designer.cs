using Dental_Clinic.Properties;

namespace Dental_Clinic.GUI.Administrator
{
    partial class UserForm
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
            vbButton1 = new CustomButton.VBButton();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 71);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(341, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý người dùng";
            // 
            // vbButton1
            // 
            vbButton1.BackColor = Color.FromArgb(220, 53, 69);
            vbButton1.BackgroundColor = Color.FromArgb(220, 53, 69);
            vbButton1.BorderColor = Color.PaleVioletRed;
            vbButton1.BorderRadius = 8;
            vbButton1.BorderSize = 0;
            vbButton1.FlatAppearance.BorderSize = 0;
            vbButton1.FlatStyle = FlatStyle.Flat;
            vbButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vbButton1.ForeColor = Color.White;
            vbButton1.Location = new Point(46, 95);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new Size(232, 47);
            vbButton1.TabIndex = 2;
            vbButton1.Text = "Thêm người dùng mới";
            vbButton1.TextAlign = ContentAlignment.MiddleLeft;
            vbButton1.TextColor = Color.White;
            vbButton1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Location = new Point(7, 202);
            panel2.Name = "panel2";
            panel2.Size = new Size(1012, 414);
            panel2.TabIndex = 4;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(panel2);
            Controls.Add(vbButton1);
            Controls.Add(panel1);
            Name = "UserForm";
            Text = "UserForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CustomButton.VBButton vbButton1;
        private Panel panel2;
    }
}