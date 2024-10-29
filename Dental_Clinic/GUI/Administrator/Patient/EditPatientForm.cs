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
    public partial class EditPatientForm : Form
    {
        private MainForm mainForm;
        private PatientDTO patientDTO;
        private PatientBUS patientBUS;
        public EditPatientForm(MainForm _mainForm, PatientDTO _patientDTO)
        {
            InitializeComponent();
            mainForm = _mainForm;
            patientBUS = new PatientBUS();
            patientDTO = _patientDTO;
            LoadForm();
        }

        public void LoadForm()
        {
            Custom();
            tbHoTen.Text = patientDTO.HoVaTen;
            tbSĐT.Text = patientDTO.SDT;
            tbTuoi.Text = patientDTO.Tuoi.ToString();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = patientDTO.GioiTinh ? "Nam" : "Nữ";
            tbQueQuan.Text = patientDTO.DiaChi;
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
            patientDTO.Id = patientDTO.Id;
            patientDTO.HoVaTen = tbHoTen.Text;
            patientDTO.SDT = tbSĐT.Text;
            patientDTO.GioiTinh = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            patientDTO.Tuoi = Convert.ToInt32(tbTuoi.Text);
            patientDTO.DiaChi = tbQueQuan.Text;

            patientBUS.CapNhatBenhNhan(patientDTO);
            patientBUS.LayThongTinBenhNhan(patientDTO.Id);
            LoadForm();
        }
    }
}
