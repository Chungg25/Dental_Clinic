using Dental_Clinic.DTO.Admin;
using Dental_Clinic.GUI.BacSi;
using Dental_Clinic.GUI.LeTan;
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
        private QuanTriVienDTO _user;

        public FormLeTan(DTO.Admin.QuanTriVienDTO userDTO)
        {
            InitializeComponent();
            this._user = userDTO;
        }

        private void FormLeTan_Load(object sender, EventArgs e)
        {
            // Load thông tin người dùng
            panelOption.Visible = false;
            panelChuDe.Visible = false;
            panelNgonNgu.Visible = false;
            string lastName = _user.HoVaTen.Substring(_user.HoVaTen.LastIndexOf(' ') + 1);
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
            return _user.Id;
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
            //ShowFormOnPanel(new BacSi.BenhNhan.FormBenhNhan_BacSi(this));
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

        private void picLogo_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
