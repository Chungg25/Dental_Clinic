﻿using Dental_Clinic.DTO.Admin;
using Dental_Clinic.GUI.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class MainForm : Form
    {
        private UserDTO _userDTO;
        public MainForm(UserDTO userDTO)
        {
            InitializeComponent();
            _userDTO = userDTO;
            Initialize();
            this.Load += MainForm_Load;
            //PrintUserInfo();
        }

        private void PrintUserInfo()
        {
            StringBuilder userInfo = new StringBuilder();
            userInfo.AppendLine($"ID: {_userDTO.Id}");
            userInfo.AppendLine($"Tên: {_userDTO.Full_name}");
            userInfo.AppendLine($"CMND: {_userDTO.Citizen_id}");
            userInfo.AppendLine($"Điện thoại: {_userDTO.Phone}");
            userInfo.AppendLine($"Địa chỉ: {_userDTO.Address}");
            userInfo.AppendLine($"Giới tính: {(_userDTO.Gender ? "Nam" : "Nữ")}");
            userInfo.AppendLine($"Ngày sinh: {_userDTO.Dob.ToShortDateString()}");
            userInfo.AppendLine($"Vai trò: {_userDTO.Role}");
            userInfo.AppendLine($"Tên đăng nhập: {_userDTO.Username}");
            userInfo.AppendLine($"Mật khẩu: {_userDTO.Password}"); // Nếu cần thiết
            userInfo.AppendLine($"Email: {_userDTO.Email}");
            userInfo.AppendLine($"Hệ số lương: {_userDTO.Salary_coefficient}");
            userInfo.AppendLine($"ID lương: {_userDTO.Salary_id}");

            // Hiển thị thông tin trong một MessageBox
            MessageBox.Show(userInfo.ToString(), "Thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Initialize()
        {
            panelOption.Visible = false;
            panelNgonNgu1.Visible = false;
            panelChuDe.Visible = false;
            string lastName = _userDTO.Full_name.Substring(_userDTO.Full_name.LastIndexOf(' ') + 1);
            lbTen.Text = lastName;
        }

        private void picUser_Click(object sender, EventArgs e)
        {
            panelOption.Visible = !panelOption.Visible;
            if (panelOption.Visible)
            {
                panelOption.BringToFront(); // Đưa panel lên trên
            }
        }
        private void lbNgonNgu_Click(object sender, EventArgs e)
        {
            panelNgonNgu1.Visible = !panelNgonNgu1.Visible;
            if (panelNgonNgu1.Visible)
            {
                panelNgonNgu1.BringToFront(); // Đưa panel lên trên
            }
        }

        private void lbChuDe_Click(object sender, EventArgs e)
        {
            panelChuDe.Visible = !panelChuDe.Visible;
            if (panelChuDe.Visible)
            {
                panelChuDe.BringToFront(); // Đưa panel lên trên
            }
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            ShowDashboardInPanel();
        }

        public void ShowDashboardInPanel()
        {
            DashboardForm dashForm = new DashboardForm(this);
            dashForm.TopLevel = false; // Đặt dashForm không phải là form cấp cao nhất (TopLevel)
            dashForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của dashForm
            dashForm.Dock = DockStyle.Fill; // Đặt dashForm khớp với kích thước panel
            panelTrangChu.Controls.Add(dashForm); // Thêm dashForm vào panel
            dashForm.BringToFront();
            dashForm.Show(); // Hiển thị dashForm
        }

        private void lbUser_Click(object sender, EventArgs e)
        {
            ShowUserInPanel();
        }

        public void ShowUserInPanel()
        {
            UserForm userForm = new UserForm(this);
            userForm.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            userForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            userForm.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            panelTrangChu.Controls.Add(userForm); // Thêm userForm vào panel
            userForm.BringToFront();
            userForm.Show(); // Hiển thị userForm
        }

        private void lbBenhNhan_Click(object sender, EventArgs e)
        {
            ShowPatientInPanel();
        }

        public void ShowPatientInPanel()
        {
            PatientForm patientForm = new PatientForm(this);
            patientForm.TopLevel = false; // Đặt patientForm không phải là form cấp cao nhất (TopLevel)
            patientForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của patientForm
            patientForm.Dock = DockStyle.Fill; // Đặt patientForm khớp với kích thước panel
            panelTrangChu.Controls.Add(patientForm); // Thêm patientForm vào panel
            patientForm.BringToFront();
            patientForm.Show(); // Hiển thị patientForm
        }

        private void lbLichLamViec_Click(object sender, EventArgs e)
        {
            ShowWorkScheduleInPanel();
        }

        public void ShowWorkScheduleInPanel()
        {
            WorkScheduleForm workScheduleForm = new WorkScheduleForm(this);
            workScheduleForm.TopLevel = false; // Đặt workScheduleForm không phải là form cấp cao nhất (TopLevel)
            workScheduleForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của workScheduleForm
            workScheduleForm.Dock = DockStyle.Fill; // Đặt workScheduleForm khớp với kích thước panel
            panelTrangChu.Controls.Add(workScheduleForm); // Thêm workScheduleForm vào panel
            workScheduleForm.BringToFront();
            workScheduleForm.Show(); // Hiển thị workScheduleForm
        }

        private void lbVatTu_Click(object sender, EventArgs e)
        {
            ShowSuppliesInPanel();
        }

        public void ShowSuppliesInPanel()
        {
            SuppliesForm suppliesForm = new SuppliesForm(this);
            suppliesForm.TopLevel = false; // Đặt suppliesForm không phải là form cấp cao nhất (TopLevel)
            suppliesForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của suppliesForm
            suppliesForm.Dock = DockStyle.Fill; // Đặt suppliesForm khớp với kích thước panel
            panelTrangChu.Controls.Add(suppliesForm); // Thêm suppliesForm vào panel
            suppliesForm.BringToFront();
            suppliesForm.Show(); // Hiển thị suppliesForm
        }

        private void lbDoanhThu_Click(object sender, EventArgs e)
        {
            ShowBusinessStatisticsInPanel();
        }

        public void ShowBusinessStatisticsInPanel()
        {
            BusinessStatisticsForm businessStatisticsForm = new BusinessStatisticsForm(this);
            businessStatisticsForm.TopLevel = false; // Đặt businessStatisticsForm không phải là form cấp cao nhất (TopLevel)
            businessStatisticsForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của suppliebusinessStatisticsFormsForm
            businessStatisticsForm.Dock = DockStyle.Fill; // Đặt businessStatisticsForm khớp với kích thước panel
            panelTrangChu.Controls.Add(businessStatisticsForm); // Thêm businessStatisticsForm vào panel
            businessStatisticsForm.BringToFront();
            businessStatisticsForm.Show(); // Hiển thị businessStatisticsForm
        }

        private void lbLuong_Click(object sender, EventArgs e)
        {
            ShowSalaryManagementInPanel();
        }

        public void ShowSalaryManagementInPanel()
        {
            SalaryManagementForm salaryManagementForm = new SalaryManagementForm(this);
            salaryManagementForm.TopLevel = false; // Đặt salaryManagementForm không phải là form cấp cao nhất (TopLevel)
            salaryManagementForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của salaryManagementForm
            salaryManagementForm.Dock = DockStyle.Fill; // Đặt salaryManagementForm khớp với kích thước panel
            panelTrangChu.Controls.Add(salaryManagementForm); // Thêm salaryManagementForm vào panel
            salaryManagementForm.BringToFront();
            salaryManagementForm.Show(); // Hiển thị salaryManagementForm
        }

        private void picDash_Click(object sender, EventArgs e)
        {
            ShowDashboardInPanel();
        }

        private void panelTrangChu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
