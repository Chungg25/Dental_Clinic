﻿namespace Dental_Clinic.GUI.Administrator.WorkSchedule
{
    partial class EditWorkScheduleForm
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
            panelLichLamViec = new Panel();
            dtpLichLamViec = new DateTimePicker();
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
            panel1.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(54, 13);
            label1.Name = "label1";
            label1.Size = new Size(404, 46);
            label1.TabIndex = 0;
            label1.Text = "Chỉnh Sửa Lịch Làm Việc";
            // 
            // panelLichLamViec
            // 
            panelLichLamViec.Location = new Point(7, 166);
            panelLichLamViec.Name = "panelLichLamViec";
            panelLichLamViec.Size = new Size(1012, 502);
            panelLichLamViec.TabIndex = 45;
            // 
            // dtpLichLamViec
            // 
            dtpLichLamViec.Location = new Point(693, 99);
            dtpLichLamViec.Name = "dtpLichLamViec";
            dtpLichLamViec.Size = new Size(250, 27);
            dtpLichLamViec.TabIndex = 46;
            // 
            // EditWorkScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1016, 644);
            Controls.Add(dtpLichLamViec);
            Controls.Add(panelLichLamViec);
            Controls.Add(panel1);
            Name = "EditWorkScheduleForm";
            Text = "EditWorkScheduleForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panelLichLamViec;
        private DateTimePicker dtpLichLamViec;
    }
}