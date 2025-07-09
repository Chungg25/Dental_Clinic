using Dental_Clinic.BUS.Patient;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator.Patient
{

    public partial class FormThemBenhNhan : Form
    {
        private MainForm mainForm;
        private BenhNhanBUS benhNhanBUS;
        private BenhNhanDTO benhNhanDTO;
        public FormThemBenhNhan(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            benhNhanDTO = new BenhNhanDTO();
            benhNhanBUS = new BenhNhanBUS();
            ChinhSua();
        }

        private void vbThemBenhNhan_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                return;
            }

            benhNhanDTO.HoVaTen = tbHoTen.Text;
            benhNhanDTO.SDT = tbSĐT.Text;
            benhNhanDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            benhNhanDTO.DiaChi = tbQueQuan.Text;
            benhNhanDTO.Tuoi = int.Parse(tbTuoi.Text);

            benhNhanBUS.ThemBenhNhan(benhNhanDTO);

            mainForm.ShowPatientInPanel();
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

            if (string.IsNullOrEmpty(tbSĐT.Text))
            {
                vbSĐT.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSĐT.BorderColor = Color.Black; // Đặt màu viền mặc định
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

            if (string.IsNullOrEmpty(tbTuoi.Text))
            {
                vbTuoi.BorderColor = Color.Red; // Đặt màu viền cho vbTuoi
                isValid = false;
            }
            else
            {
                vbTuoi.BorderColor = Color.Black; // Đặt màu viền mặc định
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
            mainForm.ShowPatientInPanel();
        }

        private void FormThemBenhNhan_Load(object sender, EventArgs e)
        {

        }

        private void panelDuLieu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
