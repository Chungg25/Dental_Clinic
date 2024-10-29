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
using Dental_Clinic.GUI.Administrator;


namespace Dental_Clinic.GUI.Login
{
    public partial class FormDangNhap : Form
    {
        private Dental_Clinic mainForm;
        private DangNhapBUS dangNhapBUS;
        public FormDangNhap(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.dangNhapBUS = new DangNhapBUS();

            lbSai.Visible = false;

            // Thiết lập tbUser với placeholder "User Name"
            tbTenDangNhap.Font = new Font("Calibri", 12);
            tbTenDangNhap.Text = "User Name";
            tbTenDangNhap.ForeColor = Color.Gray;
            tbTenDangNhap.Enter += TbUser_Enter;
            tbTenDangNhap.Leave += TbUser_Leave;

            // Thiết lập tbPassword với placeholder "Password"
            tbMatKhau.Font = new Font("Calibri", 12);
            tbMatKhau.Text = "Password";
            tbMatKhau.ForeColor = Color.Gray;
            tbMatKhau.UseSystemPasswordChar = false; // Không ẩn ký tự khi đang hiển thị placeholder
            tbMatKhau.Enter += TbPassword_Enter;
            tbMatKhau.Leave += TbPassword_Leave;
        }
        private void TbUser_Enter(object? sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "User Name")
            {
                tbTenDangNhap.Text = "";
                tbTenDangNhap.ForeColor = Color.Black;
            }
        }
        private void TbUser_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTenDangNhap.Text))
            {
                tbTenDangNhap.Text = "User Name";
                tbTenDangNhap.ForeColor = Color.Gray;
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbTenDangNhap.Focus();

        }
        // Hiển thị label thông báo lỗi
        private void HienThiLoi(string text)
        {
            lbSai.Visible = true;
            lbSai.Text = text;
        }

        // Sự kiện cho tbPassword
        private void TbPassword_Enter(object? sender, EventArgs e)
        {
            if (tbMatKhau.Text == "Password")
            {
                tbMatKhau.Text = "";
                tbMatKhau.ForeColor = Color.Black;
                tbMatKhau.UseSystemPasswordChar = true; // Ẩn ký tự khi người dùng nhập
            }
        }

        private void TbPassword_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMatKhau.Text))
            {
                tbMatKhau.Text = "Password";
                tbMatKhau.ForeColor = Color.Gray;
                tbMatKhau.UseSystemPasswordChar = false; // Hiển thị lại placeholder không ẩn ký tự
            }
        }
        // Sự kiện cho lbQuenMatKhau
        private void lbQuenMatKhau_Click(object? sender, EventArgs e)
        {
            mainForm.HienThiFormQuenMatkhau(); // Gọi hàm để hiển thị ForgotPassword
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
            DangNhapDTO dangNhapDTO = new DangNhapDTO
            {
                TenDangNhap = tbTenDangNhap.Text,
                Matkhau = tbMatKhau.Text
            };

            DataRow thongTinNguoiDung = dangNhapBUS.KiemTraDangNhap(dangNhapDTO);

            if (thongTinNguoiDung != null) // Nếu không null tức là đăng nhập thành công
            {
                // Lấy userId và userRole từ DataRow
                int userId = (int)thongTinNguoiDung["id"]; // Giả sử cột id tồn tại trong bảng users
                string userRole = thongTinNguoiDung["role"].ToString(); // Giả sử cột role tồn tại

                QuanTriVienDTO QuanTriVienDTO = new QuanTriVienDTO
                {
                    Id = (int)thongTinNguoiDung["id"],
                    HoVaTen = thongTinNguoiDung["full_name"].ToString(),
                    CCCD = thongTinNguoiDung["citizen_id"].ToString(),
                    SDT = thongTinNguoiDung["phone_number"].ToString(),
                    DiaChi = thongTinNguoiDung["address"].ToString(),
                    GioiTinh = (bool)thongTinNguoiDung["gender"],
                    NgaySinh = (DateTime)thongTinNguoiDung["dob"],
                    ChucVu = thongTinNguoiDung["role"].ToString(),
                    TenDangNhap = thongTinNguoiDung["username"].ToString(),
                    MatKhau = thongTinNguoiDung["PASSWORD"].ToString(),
                    Email = thongTinNguoiDung["email"].ToString(),
                    HeSoLuong = Convert.ToSingle(thongTinNguoiDung["salary_coefficient"]),
                };

                //Điều hướng người dùng dựa vào role
                if (userRole == "Admin")
                {
                    // Mở giao diện cho admin
                    GUI.Administrator.MainForm adminForm = new GUI.Administrator.MainForm(QuanTriVienDTO);
                    adminForm.Show();
                    this.Close();

                }
                else if (userRole == "Doctor")
                {
                    // Mở giao diện cho bác sĩ
                    GUI.Doctor.MainForm doctorForm = new GUI.Doctor.MainForm(QuanTriVienDTO);
                    doctorForm.Show();
                    this.Close();
                }
                else
                {
                    // Mở giao diện cho các vai trò khác
                    GUI.Receptionist.MainForm receptionist = new GUI.Receptionist.MainForm(QuanTriVienDTO);
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
            if (string.IsNullOrWhiteSpace(tbTenDangNhap.Text) || tbTenDangNhap.Text == "User Name")
            {
                HienThiLoi("Vui lòng nhập tên đăng nhập");
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbMatKhau.Text) || tbMatKhau.Text == "Password")
            {
                HienThiLoi("Vui lòng nhập mật khẩu");
                return false;
            }
            return true;
        }
        private void pbHienMatKhau_Click(object sender, EventArgs e)
        {
            if (tbMatKhau.UseSystemPasswordChar)
            {
                // Hiển thị mật khẩu
                tbMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                tbMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
