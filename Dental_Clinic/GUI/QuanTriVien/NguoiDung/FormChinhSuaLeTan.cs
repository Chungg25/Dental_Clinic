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
    public partial class FormChinhSuaLeTan : Form
    {
        private MainForm mainForm;
        private LeTanDTO leTanDTO;
        private LeTanBUS leTanBUS;
        public FormChinhSuaLeTan(MainForm _mainForm, LeTanDTO leTanDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            leTanBUS = new LeTanBUS();
            this.leTanDTO = leTanDTO;
            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            tbHoTen.Text = leTanDTO.HoVaTen;
            tbEmail.Text = leTanDTO.Email;
            tbSĐT.Text = leTanDTO.SDT;
            tbCCCD.Text = leTanDTO.CCCD;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = leTanDTO.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = leTanDTO.HeSoLuong.ToString();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = leTanDTO.NgaySinh;
            tbQueQuan.Text = leTanDTO.DiaChi;
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
            leTanDTO.Id = leTanDTO.Id;
            leTanDTO.HoVaTen = tbHoTen.Text;
            leTanDTO.Email = tbEmail.Text;
            leTanDTO.SDT = tbSĐT.Text;
            leTanDTO.CCCD = tbCCCD.Text;
            leTanDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            leTanDTO.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            leTanDTO.NgaySinh = dtpNgaySinh.Value; // Ngày sinh
            leTanDTO.DiaChi = tbQueQuan.Text;

            leTanBUS.CapNhatLeTan(leTanDTO);
            leTanBUS.LayThongTinLeTan(leTanDTO.Id);
            TaiForm();
        }
    }
}
