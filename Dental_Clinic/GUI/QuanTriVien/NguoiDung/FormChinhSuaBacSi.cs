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
using Dental_Clinic.DTO.BacSi;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class FormChinhSuaBacSi : Form
    {
        private MainForm mainForm;
        private BacSiDTO bacSiDTO;
        private BacSiBUS bacSiBUS;
        public FormChinhSuaBacSi(MainForm _mainForm, BacSiDTO bacSiDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            this.bacSiDTO = bacSiDTO;
            bacSiBUS = new BacSiBUS();
            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            tbHoTen.Text = bacSiDTO.HoVaTen;
            tbEmail.Text = bacSiDTO.Email;
            tbSĐT.Text = bacSiDTO.SDT;
            tbCCCD.Text = bacSiDTO.CCCD;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = bacSiDTO.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = bacSiDTO.HeSoLuong.ToString();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = bacSiDTO.NgaySinh;
            tbQueQuan.Text = bacSiDTO.DiaChi;

            cbChuyenNganh.Items.Add("Nha chu");
            cbChuyenNganh.Items.Add("Nhổ răng và tiểu phẫu");
            cbChuyenNganh.Items.Add("Phục hình");
            cbChuyenNganh.Items.Add("Chữa răng và nội nha");
            cbChuyenNganh.Items.Add("Răng trẻ em");
            cbChuyenNganh.Items.Add("Tổng quát");
            cbChuyenNganh.SelectedItem = bacSiDTO.ChuyenNganh;
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
            bacSiDTO = bacSiBUS.LayThongTinBacSi(bacSiDTO.Id);
            TaiForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            bacSiDTO.Id = bacSiDTO.Id;
            bacSiDTO.HoVaTen = tbHoTen.Text;
            bacSiDTO.Email = tbEmail.Text;
            bacSiDTO.SDT = tbSĐT.Text;
            bacSiDTO.CCCD = tbCCCD.Text;
            bacSiDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            bacSiDTO.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            bacSiDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            bacSiDTO.DiaChi = tbQueQuan.Text;
            bacSiDTO.ChuyenNganh = cbChuyenNganh.SelectedItem.ToString();

            bacSiBUS.CapNhatBacSi(bacSiDTO);
            bacSiBUS.LayThongTinBacSi(bacSiDTO.Id);
            TaiForm();
        }
    }
}
