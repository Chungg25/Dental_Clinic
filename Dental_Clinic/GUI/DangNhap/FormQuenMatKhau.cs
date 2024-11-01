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

            tempCode = quenMatKhauBUS.TaoCode();
            if (quenMatKhauBUS.GuiXacThucDenMail(tbEmail.Text, tempCode))
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
            if (!quenMatKhauBUS.KiemTraTenDangNhap(tbUsername.Text))
            {
                MessageBox.Show("Username không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra email có tồn tại trong database không
            if (!quenMatKhauBUS.KiemTraMail(tbEmail.Text))
            {
                MessageBox.Show("Email không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
