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
using Dental_Clinic.BUS.Patient;
using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.Patient;


namespace Dental_Clinic.GUI.Administrator.Patient
{
    public partial class FormChinhSuaBenhNhan : Form
    {
        private MainForm mainForm;
        private BenhNhanDTO benhNhanDTO;
        private BenhNhanBUS benhNhanBUS;
        public FormChinhSuaBenhNhan(MainForm _mainForm, BenhNhanDTO _benhNhanDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            benhNhanBUS = new BenhNhanBUS();
            benhNhanDTO = _benhNhanDTO;
            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            tbHoTen.Text = benhNhanDTO.HoVaTen;
            tbSĐT.Text = benhNhanDTO.SDT;
            tbTuoi.Text = benhNhanDTO.Tuoi.ToString();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = benhNhanDTO.GioiTinh ? "Nam" : "Nữ";
            tbQueQuan.Text = benhNhanDTO.DiaChi;
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
            mainForm.ShowPatientInPanel();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            benhNhanDTO.Id = benhNhanDTO.Id;
            benhNhanDTO.HoVaTen = tbHoTen.Text;
            benhNhanDTO.SDT = tbSĐT.Text;
            benhNhanDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            benhNhanDTO.Tuoi = Convert.ToInt32(tbTuoi.Text);
            benhNhanDTO.DiaChi = tbQueQuan.Text;

            benhNhanBUS.CapNhatBenhNhan(benhNhanDTO);
            benhNhanBUS.LayThongTinBenhNhan(benhNhanDTO.Id);
            ChinhSua();

            // Quay về form danh sách bệnh nhân
            mainForm.ShowPatientInPanel();
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            mainForm.ShowPatientInPanel();
        }
    }
}
