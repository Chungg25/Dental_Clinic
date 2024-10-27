using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.BUS.Admin;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class DashboardForm : Form
    {
        private AdminBUS _adminBUS;
        public DashboardForm(MainForm mainForm)
        {
            InitializeComponent();
            _adminBUS = new AdminBUS();

            lbBacSi.Text = _adminBUS.DoctorCount().ToString();
            lbBenhNhan.Text = _adminBUS.PatientCount().ToString();
            lbDoanhThu.Text = _adminBUS.RevenueCount().ToString();
        }
    }
}
