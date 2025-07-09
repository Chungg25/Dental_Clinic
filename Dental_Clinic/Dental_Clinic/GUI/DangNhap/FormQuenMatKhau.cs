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
using Microsoft.VisualBasic.ApplicationServices;

namespace Dental_Clinic.GUI.Login
{
    public partial class FormQuenMatKhau : Form
    {
        private Dental_Clinic mainForm;
        private QuenMatKhauBUS quenMatKhauBUS;
        private bool checkSendCode = false;
        private string tempCode = "";
        public FormQuenMatKhau(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.quenMatKhauBUS = new QuenMatKhauBUS();
        }
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            AnLoi();

            // Thiết lập Placeholder cho các textbox
            SetPlaceholder(tbUsername, "Tên đăng nhập");
            SetPlaceholder(tbEmail, "Email");
            SetPlaceholder(tbCode, "Mã xác nhận");

            tbUsername.Enter += tbUsername_Enter;
            tbUsername.Leave += tbUsername_Leave;
            tbEmail.Enter += tbEmail_Enter;
            tbEmail.Leave += tbEmail_Leave;
            tbCode.Enter += tbCode_Enter;
            tbCode.Leave += tbCode_Leave;

            tbUsername.Focus();

        }
        // Thiết lập Placeholder cho textbox
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Font = new Font("Segoe UI", 12);
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
        }
        // 1. Sự kiện click vào textbox Username
        private void tbUsername_Enter(object? sender, EventArgs e)
        {
            if (tbUsername.Text == "Tên đăng nhập")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }
        // 1. Sự kiện rời khỏi textbox Username
        private void tbUsername_Leave(object? sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Tên đăng nhập";
                tbUsername.ForeColor = Color.Gray;
            }
        }
        // 2. Sự kiện click vào textbox Email
        private void tbEmail_Enter(object? sender, EventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }
        // 2. Sự kiện rời khỏi textbox Email
        private void tbEmail_Leave(object? sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Email";
                tbEmail.ForeColor = Color.Gray;
            }
        }
        // 3. Sự kiện click vào textbox Code
        private void tbCode_Enter(object? sender, EventArgs e)
        {
            if (tbCode.Text == "Mã xác nhận")
            {
                tbCode.Text = "";
                tbCode.ForeColor = Color.Black;
            }
        }
        // 3. Sự kiện rời khỏi textbox Code
        private void tbCode_Leave(object? sender, EventArgs e)
        {
            if (tbCode.Text == "")
            {
                tbCode.Text = "Mã xác nhận";
                tbCode.ForeColor = Color.Gray;
            }
        }
        // Chỉ cho phép nhập số vào textbox Code, 6 ký tự
        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || tbCode.Text.Length >= 6)
            {
                e.Handled = true;
            }
        }
        // Hiển thị lỗi 
        private void HienThiLoi(string error)
        {
            lbSai.Text = error;
            lbSai.Visible = true;
        }
        // Ẩn lỗi
        private void AnLoi()
        {
            lbSai.Visible = false;
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
            AnLoi();
            if (!KiemTraDauVao()) return;
            // Kiểm tra đã nhấn nút Gửi mã chưa
            if (!checkSendCode)
            {
                //MessageBox.Show("Vui lòng nhấn nút Gửi mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThiLoi("Vui lòng nhấn nút Gửi mã");
                return;
            }
            // Kiểm tra mã code nhập vào có đúng không
            if (tbCode.Text != tempCode)
            {
                //MessageBox.Show("Mã xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThiLoi("Mã xác nhận không đúng");
                return;
            }

            //MessageBox.Show("Xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AnLoi();
            DangNhap();
        }
        // Sự kiện click vào nút Gửi mã
        private void vbSendCode_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao()) return;
            checkSendCode = true;

            tempCode = quenMatKhauBUS.TaoCode();
            if (quenMatKhauBUS.GuiXacThucDenMail(tbEmail.Text, tempCode))
            {
                vbSendCode.Enabled = true;
                //MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiLoi("Mã xác nhận đã được gửi đến email của bạn");
            }
            else
            {
                vbSendCode.Enabled = false;
                //MessageBox.Show("Gửi mã xác nhận thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HienThiLoi("Gửi mã xác nhận thất bại");
            }

        }
        // Hàm kiểm tra đầu vào 
        public bool KiemTraDauVao()
        {
            // Hiển thị lỗi nếu username hoặc email rỗng 
            if (tbUsername.Text == "" || tbEmail.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThiLoi("Vui lòng nhập đầy đủ thông tin");
                return false;
            }
            // Kiểm tra username có tồn tại trong database không
            if (!quenMatKhauBUS.KiemTraTenDangNhap(tbUsername.Text))
            {
                //MessageBox.Show("Username không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThiLoi("Tên đăng nhập không tồn tại");
                return false;
            }
            // Kiểm tra email có tồn tại trong database không
            if (!quenMatKhauBUS.KiemTraMail(tbEmail.Text))
            {
                //MessageBox.Show("Email không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThiLoi("Email không tồn tại");
                return false;
            }
            return true;
        }
        // Hàm đăng nhập 
        public void DangNhap()
        {
            string password = quenMatKhauBUS.LayMatKhau(tbEmail.Text, tbUsername.Text);
            DangNhapDTO loginDTO = new DangNhapDTO
            {
                TenDangNhap = tbUsername.Text,
                Matkhau = password,
            };

            DangNhapBUS loginBUS = new DangNhapBUS();

            DataRow thongTinNguoiDung = loginBUS.KiemTraDangNhap(loginDTO);

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
        }
        // Sự kiện click vào nút Quay lại
        private void picBack_Click(object sender, EventArgs e)
        {
            mainForm.HienThiFormDangNhap();
        }
    }
}
