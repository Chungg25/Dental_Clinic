using Dental_Clinic.BUS.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Dental_Clinic.BUS.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.DTO.BacSi;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class FormThemBacSi : Form
    {
        private MainForm mainForm;
        private BacSiDTO bacSiDTO;
        private QuanTriVienBUS quanTriVienBUS;
        public FormThemBacSi(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            this.bacSiDTO = new BacSiDTO();
            this.quanTriVienBUS = new QuanTriVienBUS();
            TaiForm();
        }

        public void TaiForm()
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

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            cbChuyenNganh.Items.Add("Nha chu");
            cbChuyenNganh.Items.Add("Nhổ răng và tiểu phẫu");
            cbChuyenNganh.Items.Add("Phục hình");
            cbChuyenNganh.Items.Add("Chữa răng và nội nha");
            cbChuyenNganh.Items.Add("Răng trẻ em");
            cbChuyenNganh.Items.Add("Tổng quát");
        }

        private void vbThemBacSi_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                return;
            }

            bacSiDTO.HoVaTen = tbHoTen.Text;
            bacSiDTO.Email = tbEmail.Text;
            bacSiDTO.SDT = tbSĐT.Text;
            bacSiDTO.CCCD = tbCCCD.Text;
            bacSiDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            bacSiDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            bacSiDTO.DiaChi = tbQueQuan.Text;
            bacSiDTO.ChuyenNganh = cbChuyenNganh.SelectedIndex.ToString();

            quanTriVienBUS.ThemBacSi(bacSiDTO);

            mainForm.ShowUserInPanel();
        }

        public bool KiemTraThem()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                vbHoTen.BorderColor = Color.Red; // Đặt màu viền cho tbHoTen
                isValid = false;
            }
            else
            {
                vbHoTen.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                vbEmail.BorderColor = Color.Red; // Đặt màu viền cho tbEmail
                isValid = false;
            }
            else
            {
                vbEmail.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbSĐT.Text))
            {
                vbSĐT.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSĐT.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbCCCD.Text))
            {
                vbCCCD.BorderColor = Color.Red; // Đặt màu viền cho tbCCCD
                isValid = false;
            }
            else
            {
                vbCCCD.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbHeSoLuong.Text))
            {
                vbHeSoLuong.BorderColor = Color.Red; // Đặt màu viền cho tbHeSoLuong
                isValid = false;
            }
            else
            {
                vbHeSoLuong.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbQueQuan.Text))
            {
                vbQueQuan.BorderColor = Color.Red; // Đặt màu viền cho tbQueQuan
                isValid = false;
            }
            else
            {
                vbQueQuan.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (cbGioiTinh.SelectedItem == null)
            {
                vbGioiTinh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbGioiTinh.BorderColor = Color.White; // Đặt màu nền mặc định
            }

            if (cbChuyenNganh.SelectedItem == null)
            {
                vbChuyenNganh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbChuyenNganh.BorderColor = Color.Black; // Đặt màu nền mặc định
            }
            return isValid;
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            mainForm.ShowUserInPanel();
        }
    }
}
