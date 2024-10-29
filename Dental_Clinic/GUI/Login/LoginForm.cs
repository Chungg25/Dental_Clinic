﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomButton;
using Dental_Clinic.BUS.Login;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.Login;
using Dental_Clinic.GUI.Administrator;


namespace Dental_Clinic.GUI.Login
{
    public partial class LoginForm : Form
    {
        private Dental_Clinic mainForm;
        private LoginBUS loginBUS;
        public LoginForm(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.loginBUS = new LoginBUS();

            lbSai.Visible = false;

            // Thiết lập tbUser với placeholder "User Name"
            tbUser.Font = new Font("Calibri", 12);
            tbUser.Text = "User Name";
            tbUser.ForeColor = Color.Gray;
            tbUser.Enter += TbUser_Enter;
            tbUser.Leave += TbUser_Leave;

            // Thiết lập tbPassword với placeholder "Password"
            tbPassword.Font = new Font("Calibri", 12);
            tbPassword.Text = "Password";
            tbPassword.ForeColor = Color.Gray;
            tbPassword.UseSystemPasswordChar = false; // Không ẩn ký tự khi đang hiển thị placeholder
            tbPassword.Enter += TbPassword_Enter;
            tbPassword.Leave += TbPassword_Leave;
        }
        private void TbUser_Enter(object? sender, EventArgs e)
        {
            if (tbUser.Text == "User Name")
            {
                tbUser.Text = "";
                tbUser.ForeColor = Color.Black;
            }
        }
        private void TbUser_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text))
            {
                tbUser.Text = "User Name";
                tbUser.ForeColor = Color.Gray;
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbUser.Focus();

        }
        // Hiển thị label thông báo lỗi
        private void ShowErrorLabel(string text)
        {
            lbSai.Visible = true;
            lbSai.Text = text;
        }

        // Sự kiện cho tbPassword
        private void TbPassword_Enter(object? sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
                tbPassword.UseSystemPasswordChar = true; // Ẩn ký tự khi người dùng nhập
            }
        }

        private void TbPassword_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.Gray;
                tbPassword.UseSystemPasswordChar = false; // Hiển thị lại placeholder không ẩn ký tự
            }
        }
        // Sự kiện cho lbQuenMatKhau
        private void lbQuenMatKhau_Click(object? sender, EventArgs e)
        {
            mainForm.ShowForgotPasswordInPanel(); // Gọi hàm để hiển thị ForgotPassword
        }
        // Sự kiện cho vbDangNhap
        private void vbDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void DangNhap()
        {
            if (!KiemTraDauVao())
            {
                return;
            }
            // Tạo đối tượng LoginDTO từ dữ liệu người dùng nhập vào
            LoginDTO loginDTO = new LoginDTO
            {
                TenDangNhap = tbUser.Text,
                Matkhau = tbPassword.Text
            };

            DataRow userInfo = loginBUS.KiemTraDangNhap(loginDTO);

            if (userInfo != null) // Nếu không null tức là đăng nhập thành công
            {
                // Lấy userId và userRole từ DataRow
                int userId = (int)userInfo["id"]; // Giả sử cột id tồn tại trong bảng users
                string userRole = userInfo["role"].ToString(); // Giả sử cột role tồn tại

                UserDTO userDTO = new UserDTO
                {
                    Id = (int)userInfo["id"],
                    HoVaTen = userInfo["full_name"].ToString(),
                    CCCD = userInfo["citizen_id"].ToString(),
                    SDT = userInfo["phone_number"].ToString(),
                    DiaChi = userInfo["address"].ToString(),
                    GioiTinh = (bool)userInfo["gender"],
                    NgaySinh = (DateTime)userInfo["dob"],
                    ChucVu = userInfo["role"].ToString(),
                    TenDangNhap = userInfo["username"].ToString(),
                    MatKhau = userInfo["PASSWORD"].ToString(),
                    Email = userInfo["email"].ToString(),
                    HeSoLuong = Convert.ToSingle(userInfo["salary_coefficient"]),
                };

                //Điều hướng người dùng dựa vào role
                if (userRole == "Admin")
                {
                    // Mở giao diện cho admin
                    GUI.Administrator.MainForm adminForm = new GUI.Administrator.MainForm(userDTO);
                    adminForm.Show();
                    this.Close();

                }
                else if (userRole == "Doctor")
                {
                    // Mở giao diện cho bác sĩ
                    GUI.Doctor.MainForm doctorForm = new GUI.Doctor.MainForm(userDTO);
                    doctorForm.Show();
                    this.Close();
                }
                else
                {
                    // Mở giao diện cho các vai trò khác
                    GUI.Receptionist.MainForm receptionist = new GUI.Receptionist.MainForm(userDTO);
                    receptionist.Show();
                    this.Close();
                }
            }
            else
            {
                lbSai.Text = "Sai tài khoản hoặc sai mật khẩu"; // Hiển thị thông báo lỗi
            }
        }
        // Kiểm tra dữ liệu đầu vào
        private bool KiemTraDauVao()
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text) || tbUser.Text == "User Name")
            {
                ShowErrorLabel("Vui lòng nhập tên đăng nhập");
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text) || tbPassword.Text == "Password")
            {
                ShowErrorLabel("Vui lòng nhập mật khẩu");
                return false;
            }
            return true;
        }
        private void pbHienMatKhau_Click(object sender, EventArgs e)
        {
            if (tbPassword.UseSystemPasswordChar)
            {
                // Hiển thị mật khẩu
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                tbPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
