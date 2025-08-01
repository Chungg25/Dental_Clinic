﻿using Dental_Clinic.BUS.Login;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.GUI.BacSi;
using Dental_Clinic.GUI.LeTan;
using Dental_Clinic.GUI.LeTan.ThanhToan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Receptionist
{
    public partial class FormLeTan : Form
    {
        private QuanTriVienDTO user;

        public FormLeTan(QuanTriVienDTO userDTO)
        {
            InitializeComponent();
            this.user = userDTO;
        }

        private void FormLeTan_Load(object sender, EventArgs e)
        {
            // Load thông tin người dùng
            panelOption.Visible = false;
            panelChuDe.Visible = false;
            panelNgonNgu.Visible = false;
            string lastName = user.HoVaTen.Substring(user.HoVaTen.LastIndexOf(' ') + 1);
            lbTen.Text = lastName;

            // Hiển thị trang chủ
            HienThiFormLenPanel(new FormTrangChuLeTan());
        }
        // Hiển thị form lên panel
        public void HienThiFormLenPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelTrangChu.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        // Trả về mã bác sĩ 
        public int MaLeTan()
        {
            return user.Id;
        }
        private void pnUser_Click(object sender, EventArgs e)
        {
            panelOption.Visible = !panelOption.Visible;
            if (panelOption.Visible)
            {
                panelOption.BringToFront(); // Đưa panel lên trên
            }
        }
        private void pnChuDe_Click(object sender, EventArgs e)
        {
            panelChuDe.Visible = !panelChuDe.Visible;
            if (panelChuDe.Visible)
            {
                panelChuDe.BringToFront(); // Đưa panel lên trên
            }
        }
        private void pnNgonNgu_Click(object sender, EventArgs e)
        {
            panelNgonNgu.Visible = !panelNgonNgu.Visible;
            if (panelNgonNgu.Visible)
            {
                panelNgonNgu.BringToFront(); // Đưa panel lên trên
            }
        }
        // Đăng xuất
        private void DangXuat_Click(object sender, EventArgs e)
        {
            DangNhapBUS dangNhapBUS = new DangNhapBUS();
            dangNhapBUS.CapNhatPhien(user.Id);

            // Hiển thị form đăng nhập
            this.Hide();
            GUI.Dental_Clinic mainForm = new GUI.Dental_Clinic();
            mainForm.ShowDialog();
            if (mainForm.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void lbTrangChu_Click(object sender, EventArgs e)
        {
            HienThiFormLenPanel(new FormTrangChuLeTan());
        }

        private void lbThanhToan_Click(object sender, EventArgs e)
        {
            HienThiFormLenPanel(new FormThanhToan());
        }

        private void lbLuong_Click(object sender, EventArgs e)
        {
            HienThiFormLenPanel(new FormQuanLyLuong_LeTan(user.Id));
        }

        private void lbXemThongTin_Click(object sender, EventArgs e)
        {
            HienThiFormLenPanel(new FormThongTinLeTan(this, user));
        }

        private void lbLichLamViec_Click(object sender, EventArgs e)
        {
            HienThiFormLenPanel(new LeTan.ThongTin.FormLichlamViec(this, user.Id));
        }
    }
}
