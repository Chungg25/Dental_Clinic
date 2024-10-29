using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DTO.Admin;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class EditUserForm : Form
    {
        private MainForm mainForm;
        private DoctorDTO doctorDTO;
        private DoctorBUS doctorBUS;
        public EditUserForm(MainForm _mainForm, DoctorDTO doctorDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            this.doctorDTO = doctorDTO;
            doctorBUS = new DoctorBUS();
            LoadForm();
        }

        public void LoadForm()
        {
            Custom();
            tbHoTen.Text = doctorDTO.HoVaTen;
            tbEmail.Text = doctorDTO.Email;
            tbSĐT.Text = doctorDTO.SDT;
            tbCCCD.Text = doctorDTO.CCCD;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = doctorDTO.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = doctorDTO.HeSoLuong.ToString();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = doctorDTO.NgaySinh;
            tbQueQuan.Text = doctorDTO.DiaChi;

            cbChuyenNganh.Items.Add("Nha chu");
            cbChuyenNganh.Items.Add("Nhổ răng và tiểu phẫu");
            cbChuyenNganh.Items.Add("Phục hình");
            cbChuyenNganh.Items.Add("Chữa răng và nội nha");
            cbChuyenNganh.Items.Add("Răng trẻ em");
            cbChuyenNganh.Items.Add("Tổng quát");
            cbChuyenNganh.SelectedItem = doctorDTO.ChuyenNganh;
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
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            doctorDTO = doctorBUS.LayThongTinBacSi(doctorDTO.Id);
            LoadForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            doctorDTO.Id = doctorDTO.Id;
            doctorDTO.HoVaTen = tbHoTen.Text;
            doctorDTO.Email = tbEmail.Text;
            doctorDTO.SDT = tbSĐT.Text;
            doctorDTO.CCCD = tbCCCD.Text;
            doctorDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            doctorDTO.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            doctorDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            doctorDTO.DiaChi = tbQueQuan.Text;
            doctorDTO.ChuyenNganh = cbChuyenNganh.SelectedItem.ToString();

            doctorBUS.CapNhatBacSi(doctorDTO);
            doctorBUS.LayThongTinBacSi(doctorDTO.Id);
            LoadForm();
        }
    }
}
