namespace Dental_Clinic.GUI.QuanTriVien.NguoiDung
{
    partial class FormFaceID
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
            panelFaceID = new Panel();
            pnTop = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelFaceID
            // 
            panelFaceID.Location = new Point(142, 175);
            panelFaceID.Margin = new Padding(4, 4, 4, 4);
            panelFaceID.Name = "panelFaceID";
            panelFaceID.Size = new Size(990, 534);
            panelFaceID.TabIndex = 3;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(panel1);
            pnTop.Controls.Add(label1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(4);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1270, 80);
            pnTop.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(40, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(1278, 2);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(40, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 54);
            label1.TabIndex = 0;
            label1.Text = "Face ID";
            // 
            // FormFaceID
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1270, 805);
            Controls.Add(pnTop);
            Controls.Add(panelFaceID);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormFaceID";
            Text = "FormFaceID";
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelFaceID;
        private Panel pnTop;
        private Panel panel1;
        private Label label1;
    }
}