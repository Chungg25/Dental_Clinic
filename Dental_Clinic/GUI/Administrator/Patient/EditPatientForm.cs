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
            tbHoTen.Text = patientDTO.Full_name;
            tbSĐT.Text = patientDTO.Phone;
            tbTuoi.Text = patientDTO.Age.ToString();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = patientDTO.Gender ? "Nam" : "Nữ";
            tbQueQuan.Text = patientDTO.Address;
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
            patientDTO.Full_name = tbHoTen.Text;
            patientDTO.Phone = tbSĐT.Text;
            patientDTO.Gender = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            patientDTO.Age = Convert.ToInt32(tbTuoi.Text);
            patientDTO.Address = tbQueQuan.Text;

            patientBUS.UpdatePatient(patientDTO);
            patientBUS.GetPatientInfo(patientDTO.Id);
            LoadForm();
        }
    }
}
