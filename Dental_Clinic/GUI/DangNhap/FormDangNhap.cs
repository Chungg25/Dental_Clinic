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

            // ENTER ĐĂNG NHẬP
            tbTenDangNhap.KeyDown += tbEnter_KeyDown;
            tbMatKhau.KeyDown += tbEnter_KeyDown;
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
                int userId = (int)thongTinNguoiDung["ma_nguoi_dung"]; // Giả sử cột id tồn tại trong bảng users
                string userRole = thongTinNguoiDung["vai_tro"].ToString() ?? ""; // Giả sử cột role tồn tại trong bảng users

                QuanTriVienDTO user = new QuanTriVienDTO
                {
                    Id = (int)thongTinNguoiDung["ma"],
                    HoVaTen = thongTinNguoiDung["ho_ten"].ToString() ?? "",
                    CCCD = thongTinNguoiDung["cccd"].ToString() ?? "",
                    SDT = thongTinNguoiDung["so_dien_thoai"].ToString() ?? "",
                    DiaChi = thongTinNguoiDung["dia_chi"].ToString() ?? "",
                    GioiTinh = (bool)thongTinNguoiDung["gioi_tinh"],
                    NgaySinh = (DateTime)thongTinNguoiDung["ngay_sinh"],
                    ChucVu = thongTinNguoiDung["vai_tro"].ToString() ?? "",
                    TenDangNhap = thongTinNguoiDung["ten_dang_nhap"].ToString() ?? "",
                    MatKhau = thongTinNguoiDung["mat_khau"].ToString() ?? "",
                    Email = thongTinNguoiDung["email"].ToString() ?? "",
                    HeSoLuong = Convert.ToSingle(thongTinNguoiDung["he_so_luong"]),
                };

                //Điều hướng người dùng dựa vào role
                Form form;
                if (userRole == "Admin")
                {
                    form = new GUI.Administrator.MainForm(user);
                }
                else if (userRole == "Doctor")
                {
                    form = new GUI.BacSi.FormBacSi(user);
                }
                else
                {
                    form = new GUI.Receptionist.FormLeTan(user);
                }

                this.Hide();
                mainForm.Hide();
                form.FormClosed += (s, args) => Application.Exit();
                form.Show();
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
        // SỰ KIỆN ENTER ĐĂNG NHẬP
        private void tbEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }
    }
}
