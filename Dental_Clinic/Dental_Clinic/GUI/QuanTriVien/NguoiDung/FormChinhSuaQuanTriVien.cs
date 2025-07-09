using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DAO.LeTan;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.LeTan;
using Dental_Clinic.GUI.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.QuanTriVien.NguoiDung
{
    public partial class FormChinhSuaQuanTriVien : Form
    {
        private MainForm mainForm;
        private QuanTriVienBUS quanTriVienBUS;
        private QuanTriVienDTO quanTriVienDTO;
        public FormChinhSuaQuanTriVien(MainForm mainForm, QuanTriVienDTO userDTO)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            quanTriVienBUS = new QuanTriVienBUS();
            quanTriVienDTO = userDTO;

            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            tbHoTen.Text = quanTriVienDTO.HoVaTen;
            tbEmail.Text = quanTriVienDTO.Email;
            tbSĐT.Text = quanTriVienDTO.SDT;
            tbCCCD.Text = quanTriVienDTO.CCCD;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = quanTriVienDTO.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = quanTriVienDTO.HeSoLuong.ToString();
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = quanTriVienDTO.NgaySinh;
            tbQueQuan.Text = quanTriVienDTO.DiaChi;
            tbTenTaiKhoan.Text = quanTriVienDTO.TenDangNhap;
            tbMatKhau.Text = quanTriVienDTO.MatKhau;
        }

        public void ChinhSua()
        {
            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            TaiForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            quanTriVienDTO.Id = quanTriVienDTO.Id;
            quanTriVienDTO.HoVaTen = tbHoTen.Text;
            quanTriVienDTO.Email = tbEmail.Text;
            quanTriVienDTO.SDT = tbSĐT.Text;
            quanTriVienDTO.CCCD = tbCCCD.Text;
            quanTriVienDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            quanTriVienDTO.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            quanTriVienDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            quanTriVienDTO.DiaChi = tbQueQuan.Text;
            quanTriVienDTO.TenDangNhap = tbTenTaiKhoan.Text;
            quanTriVienDTO.MatKhau = tbMatKhau.Text;

            quanTriVienBUS.CapNhatQuanTriVien(quanTriVienDTO);
            quanTriVienBUS.LayThongTinQuanTriVien(quanTriVienDTO.Id);
            TaiForm();

            mainForm.ShowDashboardInPanel();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            // Quay về trang chủ
            mainForm.ShowDashboardInPanel();
        }
    }
}
