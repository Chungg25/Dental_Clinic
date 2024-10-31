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

namespace Dental_Clinic.GUI.BacSi
{
    public partial class FormBacSi : Form
    {
        private QuanTriVienDTO _user;
        public FormBacSi(DTO.Admin.QuanTriVienDTO user)
        {
            InitializeComponent();
            this._user = user;
        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {
            // Load thông tin người dùng
            panelOption.Visible = false;
            panelChuDe.Visible = false;
            panelNgonNgu.Visible = false;
            string lastName = _user.HoVaTen.Substring(_user.HoVaTen.LastIndexOf(' ') + 1);
            lbTen.Text = lastName;

            // Hiển thị trang chủ
            ShowFormOnPanel(new FormTrangChuBacSi());
        }
        // Hiển thị form lên panel
        public void ShowFormOnPanel(Form form)
        {
            form.TopLevel = false; // Đặt dashForm không phải là form cấp cao nhất (TopLevel)
            form.FormBorderStyle = FormBorderStyle.None; // Xóa viền của dashForm
            form.Dock = DockStyle.Fill; // Đặt dashForm khớp với kích thước panel
            panelTrangChu.Controls.Add(form); // Thêm dashForm vào panel
            form.BringToFront();
            form.Show(); // Hiển thị dashForm
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
        // Quản lý bệnh nhân click
        private void QuanLyBenhNhan_Click(object sender, EventArgs e)
        {
            ShowFormOnPanel(new BacSi.BenhNhan.FormBenhNhan_BacSi(this));
        }
        // Đăng xuất
        private void DangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị form đăng nhập
            this.Hide();
            GUI.Dental_Clinic mainForm = new GUI.Dental_Clinic();
            mainForm.ShowDialog();
            if (mainForm.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
