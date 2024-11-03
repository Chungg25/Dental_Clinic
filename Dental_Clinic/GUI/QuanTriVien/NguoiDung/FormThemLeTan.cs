using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.LeTan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class FormThemLeTan : Form
    {
        private MainForm mainForm;
        private LeTanDTO leTanDTO;
        private QuanTriVienBUS quanTriVienBUS;
        public FormThemLeTan(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            quanTriVienBUS = new QuanTriVienBUS();
            this.leTanDTO = new LeTanDTO();
            ChinhSua();
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

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        }

        private void vbThemLetan_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                return;
            }

            leTanDTO.HoVaTen = tbHoTen.Text;
            leTanDTO.Email = tbEmail.Text;
            leTanDTO.SDT = tbSĐT.Text;
            leTanDTO.CCCD = tbCCCD.Text;
            leTanDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            leTanDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            leTanDTO.DiaChi = tbQueQuan.Text;

            quanTriVienBUS.ThemLeTan(leTanDTO);

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

            return isValid;
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            mainForm.panelTrangChu.Controls.RemoveAt(0);
            Control control = mainForm.panelTrangChu.Controls[0];
            control.Visible = true;
            if (control is Form form)
            {
                if (form is FormLeTan formLeTan)
                {
                    formLeTan.HienLeTan();
                }
            }
        }
    }
}
