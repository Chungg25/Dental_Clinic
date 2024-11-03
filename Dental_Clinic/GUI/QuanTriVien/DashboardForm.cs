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
        private QuanTriVienBUS quanTriVienBUS;
        public DashboardForm(MainForm mainForm)
        {
            InitializeComponent();
            quanTriVienBUS = new QuanTriVienBUS();

            lbBacSi.Text = quanTriVienBUS.SoLuongBacSi().ToString();
            lbBenhNhan.Text = quanTriVienBUS.SoLuongBenhNhan().ToString();
            lbDoanhThu.Text = quanTriVienBUS.TongLuong().ToString();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
