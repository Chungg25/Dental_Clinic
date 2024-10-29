using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DAO.Admin;
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
    public partial class EditReceptionForm : Form
    {
        private MainForm mainForm;
        private ReceptionistDTO receptionistDTO;
        private ReceptionistBUS receptionistBUS;
        public EditReceptionForm(MainForm _mainForm, ReceptionistDTO receptionistDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            receptionistBUS = new ReceptionistBUS();
            this.receptionistDTO = receptionistDTO;
            LoadForm();
        }

        public void LoadForm()
        {
            Custom();
            tbHoTen.Text = receptionistDTO.HoVaTen;
            tbEmail.Text = receptionistDTO.Email;
            tbSĐT.Text = receptionistDTO.SDT;
            tbCCCD.Text = receptionistDTO.CCCD;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = receptionistDTO.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = receptionistDTO.HeSoLuong.ToString();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = receptionistDTO.NgaySinh;
            tbQueQuan.Text = receptionistDTO.DiaChi;
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
            LoadForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            receptionistDTO.Id = receptionistDTO.Id;
            receptionistDTO.HoVaTen = tbHoTen.Text;
            receptionistDTO.Email = tbEmail.Text;
            receptionistDTO.SDT = tbSĐT.Text;
            receptionistDTO.CCCD = tbCCCD.Text;
            receptionistDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            receptionistDTO.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            receptionistDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            receptionistDTO.DiaChi = tbQueQuan.Text;

            receptionistBUS.CapNhatLeTan(receptionistDTO);
            receptionistDTO = receptionistBUS.LayThongTinLeTan(receptionistDTO.Id);
            LoadForm();
        }
    }
}
