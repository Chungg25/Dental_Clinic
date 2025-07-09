using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.GUI;
using Dental_Clinic.GUI.BacSi;
using Dental_Clinic.GUI.BacSi.BenhNhan;
using Dental_Clinic.GUI.BacSi.ThongTin;
using Dental_Clinic.BUS.Login;

namespace Dental_Clinic.GUI.BacSi
{
    public partial class FormBacSi : Form
    {
        private QuanTriVienDTO user;
        public FormBacSi(DTO.Admin.QuanTriVienDTO user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {
            // Load thông tin người dùng
            panelOption.Visible = false;
            panelChuDe.Visible = false;
            panelNgonNgu.Visible = false;
            string lastName = user.HoVaTen.Substring(user.HoVaTen.LastIndexOf(' ') + 1);
            lbTen.Text = lastName;

            // Hiển thị trang chủ
            ShowFormOnPanel(new FormTrangChuBacSi(this));
        }
        // Hiển thị form lên panel
        public void ShowFormOnPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelTrangChu.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        // Trả về mã bác sĩ 
        public int MaBacSi()
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
        // Lương 
        private void lbLuong_Click(object sender, EventArgs e)
        {
            ShowFormOnPanel(new FormQuanLyLuong_BacSi(user.Id));
        }
        // Trang chủ
        private void lbTrangChu_Click(object sender, EventArgs e)
        {
            ShowFormOnPanel(new FormTrangChuBacSi(this));
        }

        private void lbLichLamViec_Click(object sender, EventArgs e)
        {
            ShowFormOnPanel(new FormLichLamViec(this, user.Id));
        }

        private void lbXemThongTin_Click(object sender, EventArgs e)
        {
            ShowFormOnPanel(new FormThongTinBacSi(this, user));
        }
    }
}
