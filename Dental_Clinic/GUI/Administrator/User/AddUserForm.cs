using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Dental_Clinic.BUS.Admin;
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

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class AddUserForm : Form
    {
        private MainForm mainForm;
        private DoctorDTO doctorDTO;
        private DoctorBUS doctorBUS;
        public AddUserForm(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            this.doctorDTO = new DoctorDTO();
            this.doctorBUS = new DoctorBUS();
            Custom();
        }

        public void Custom()
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

            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            cbChucVu.Items.Add("Doctor");
            cbChucVu.Items.Add("Reception");
            cbChucVu.Items.Add("Admin");

            cbChuyenNganh.Items.Add("Chữa răng và nội nha");
            cbChuyenNganh.Items.Add("Nha chu");
            cbChuyenNganh.Items.Add("Nhổ răng và tiểu phẫu");
            cbChuyenNganh.Items.Add("Phục hình");
            cbChuyenNganh.Items.Add("Răng trẻ em");
            cbChuyenNganh.Items.Add("Tổng quát");
        }

        private void vbThemBacSi_Click(object sender, EventArgs e)
        {
            if (!CheckAdd())
            {
                return;
            }

            doctorDTO.Full_name = tbHoTen.Text;
            doctorDTO.Email = tbEmail.Text;
            doctorDTO.Phone = tbSĐT.Text;
            doctorDTO.Citizen_id = tbCCCD.Text;
            doctorDTO.Gender = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            doctorDTO.Dob = dtpNgaySinh.Value; // Ngày sinh
            doctorDTO.Address = tbQueQuan.Text;
            doctorDTO.Role = cbChucVu.SelectedItem.ToString();
            doctorDTO.Specialization_name = cbChuyenNganh.SelectedIndex.ToString();

            doctorBUS.AddDoctor(doctorDTO);
        }

        public bool CheckAdd()
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

            if (cbChucVu.SelectedItem == null)
            {
                vbChucVu.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbChucVu.BorderColor = Color.Black; // Đặt màu nền mặc định
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
    }
}
