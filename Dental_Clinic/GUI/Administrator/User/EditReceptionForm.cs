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
            tbHoTen.Text = receptionistDTO.Full_name;
            tbEmail.Text = receptionistDTO.Email;
            tbSĐT.Text = receptionistDTO.Phone;
            tbCCCD.Text = receptionistDTO.Citizen_id;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = receptionistDTO.Gender ? "Nam" : "Nữ";
            tbHeSoLuong.Text = receptionistDTO.Salary_coefficient.ToString();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = receptionistDTO.Dob;
            tbQueQuan.Text = receptionistDTO.Address;
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
            receptionistDTO.Full_name = tbHoTen.Text;
            receptionistDTO.Email = tbEmail.Text;
            receptionistDTO.Phone = tbSĐT.Text;
            receptionistDTO.Citizen_id = tbCCCD.Text;
            receptionistDTO.Gender = cbGioiTinh.SelectedItem.ToString() == "Nam"; // Cập nhật giới tính
            receptionistDTO.Salary_coefficient = float.Parse(tbHeSoLuong.Text);
            receptionistDTO.Dob = dtpNgaySinh.Value; // Ngày sinh
            receptionistDTO.Address = tbQueQuan.Text;

            receptionistBUS.UpdateReceptionist(receptionistDTO);
            receptionistDTO = receptionistBUS.GetReceptionistInfo(receptionistDTO.Id);
            LoadForm();
        }
    }
}
