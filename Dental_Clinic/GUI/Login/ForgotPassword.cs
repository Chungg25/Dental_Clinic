using System;
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

namespace Dental_Clinic.GUI.Login
{
    public partial class ForgotPassword : Form
    {
        private Dental_Clinic mainForm;
        private ForgotPasswordBUS forgotPasswordBUS;
        private bool checkSendCode = false;
        private string tempCode = "";
        public ForgotPassword(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.forgotPasswordBUS = new ForgotPasswordBUS();
        }
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            tbUsername.Focus();
        }
        // Sự kiện Enter để xác nhận
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXacNhan_Click(sender, e);
            }
        }
        // Sự kiện click vào nút Xác nhận
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao()) return;
            // Kiểm tra đã nhấn nút Gửi mã chưa
            if (!checkSendCode)
            {
                MessageBox.Show("Vui lòng nhấn nút Gửi mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra mã code nhập vào có đúng không
            if (tbCode.Text != tempCode)
            {
                MessageBox.Show("Mã xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DangNhap();
        }
        // Sự kiện click vào nút Gửi mã
        private void vbSendCode_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao()) return;
            checkSendCode = true;

            tempCode = forgotPasswordBUS.TaoCode();
            if (forgotPasswordBUS.GuiXacThucDenMail(tbEmail.Text, tempCode))
            {
                vbSendCode.Enabled = true;
                MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                vbSendCode.Enabled = false;
                MessageBox.Show("Gửi mã xác nhận thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // Hàm kiểm tra đầu vào 
        public bool KiemTraDauVao()
        {
            // Hiển thị lỗi nếu username hoặc email rỗng 
            if (tbUsername.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra username có tồn tại trong database không
            if (!forgotPasswordBUS.KiemTraTenDangNhap(tbUsername.Text))
            {
                MessageBox.Show("Username không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra email có tồn tại trong database không
            if (!forgotPasswordBUS.KiemTraMail(tbEmail.Text))
            {
                MessageBox.Show("Email không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        // Hàm đăng nhập 
        public void DangNhap()
        {
            string password = forgotPasswordBUS.LayMatKhau(tbEmail.Text, tbUsername.Text);
            LoginDTO loginDTO = new LoginDTO
            {
                TenDangNhap = tbUsername.Text,
                Matkhau = password,
            };

            LoginBUS loginBUS = new LoginBUS();

            DataRow userInfo = loginBUS.KiemTraDangNhap(loginDTO);

            if (userInfo != null) // Nếu không null tức là đăng nhập thành công
            {
                // Lấy userId và userRole từ DataRow
                int userId = (int)userInfo["user_id"]; // Giả sử cột id tồn tại trong bảng users
                string userRole = userInfo["role"].ToString(); // Giả sử cột role tồn tại
                UserDTO userDTO = new UserDTO
                {
                    Id = (int)userInfo["user_id"],
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
                    this.Hide();
                    GUI.Administrator.MainForm adminForm = new GUI.Administrator.MainForm(userDTO);
                    adminForm.ShowDialog();
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

                // Nếu tắt form main thì cả ứng dụng sẽ tắt
                Environment.Exit(0);
            }
        }
        // Sự kiện click vào nút Quay lại
        private void picBack_Click(object sender, EventArgs e)
        {
            mainForm.ShowLoginFormInPanel();
        }
    }
}
