using Dental_Clinic.DTO.Admin;
using Dental_Clinic.GUI.Administrator.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.GUI.Receptionist;
using Dental_Clinic.BUS.Admin;

namespace Dental_Clinic.GUI.LeTan
{
    public partial class FormThongTinLeTan : Form
    {
        private QuanTriVienDTO user;
        private Receptionist.FormLeTan formLeTan;
        private QuanTriVienBUS quanTriVienBUS;
        public FormThongTinLeTan(Receptionist.FormLeTan formLeTan, QuanTriVienDTO user)
        {
            InitializeComponent();
            this.formLeTan = formLeTan;
            this.user = user;
            this.quanTriVienBUS = new QuanTriVienBUS();
        }

        private void FormThongTinLeTan_Load(object sender, EventArgs e)
        {
            foreach (Control control in pnChinh.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in pnChinh.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.TextAlign = HorizontalAlignment.Center;
                }
            }

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            HienThiThongTin();
        }
        // Hiển thị thông tin người dùng
        public void HienThiThongTin()
        {
            tbHoTen.Text = user.HoVaTen;
            tbEmail.Text = user.Email;
            tbSĐT.Text = user.SDT;
            tbCCCD.Text = user.CCCD;
            cbGioiTinh.SelectedItem = user.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = user.HeSoLuong.ToString();
            dtpNgaySinh.Value = user.NgaySinh;
            tbQueQuan.Text = user.DiaChi;
            tbTenTaiKhoan.Text = user.TenDangNhap;
            tbMatKhau.Text = user.MatKhau;
        }
        private void vbHuy_Click(object sender, EventArgs e)
        {
            formLeTan.HienThiFormLenPanel(new FormTrangChuLeTan());
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            // Câp nhật thông tin
            user.HoVaTen = tbHoTen.Text;
            user.Email = tbEmail.Text;
            user.SDT = tbSĐT.Text;
            user.CCCD = tbCCCD.Text;
            user.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam" ? true : false;
            user.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            user.NgaySinh = dtpNgaySinh.Value;
            user.DiaChi = tbQueQuan.Text;
            user.TenDangNhap = tbTenTaiKhoan.Text;
            user.MatKhau = tbMatKhau.Text;

            quanTriVienBUS.CapNhatQuanTriVien(user);

            formLeTan.HienThiFormLenPanel(new FormTrangChuLeTan());
        }
    }
}
