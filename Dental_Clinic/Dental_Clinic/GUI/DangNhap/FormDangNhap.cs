using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Microsoft.VisualBasic.ApplicationServices;


namespace Dental_Clinic.GUI.Login
{
    public partial class FormDangNhap : Form
    {
        private Dental_Clinic mainForm;
        private DangNhapBUS dangNhapBUS;
        private Process process;
        private StreamWriter pythonInput;
        public FormDangNhap(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.dangNhapBUS = new DangNhapBUS();

            lbSai.Visible = false;

            // Thiết lập tbUser với placeholder "Tên đăng nhập"
            tbTenDangNhap.Font = new Font("Segoe UI", 12);
            tbTenDangNhap.Text = "Tên đăng nhập";
            tbTenDangNhap.ForeColor = Color.Gray;
            tbTenDangNhap.Enter += TbUser_Enter;
            tbTenDangNhap.Leave += TbUser_Leave;

            // Thiết lập tbPassword với placeholder "Mật khẩu"
            tbMatKhau.Font = new Font("Segoe UI", 12);
            tbMatKhau.Text = "Mật khẩu";
            tbMatKhau.ForeColor = Color.Gray;
            tbMatKhau.UseSystemPasswordChar = false; // Không ẩn ký tự khi đang hiển thị placeholder
            tbMatKhau.Enter += TbPassword_Enter;
            tbMatKhau.Leave += TbPassword_Leave;

            // ENTER ĐĂNG NHẬP
            tbTenDangNhap.KeyDown += tbEnter_KeyDown;
            tbMatKhau.KeyDown += tbEnter_KeyDown;

            //StartPythonProcess();
        }

        private void StartPythonProcess()
        {
            AnLoi();
            HienThiLoi("Đang quét Face ID...");
            if (process == null || process.HasExited)  // Kiểm tra nếu process chưa được khởi tạo hoặc đã dừng
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "python";  // Đảm bảo đường dẫn "python" đúng hoặc thay bằng đường dẫn đầy đủ đến python.exe

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Directory.GetParent(basePath).Parent.Parent.Parent.Parent.FullName;
                string scriptPath = Path.Combine(projectRoot, "real-time-face-recognition", "face_recognizer.py");

                //string basePath = AppDomain.CurrentDomain.BaseDirectory;
                //string scriptPath = Path.Combine(basePath, "real-time-face-recognition", "face_recognizer.py");


                //MessageBox.Show("Đường dẫn tính toán: " + scriptPath);

                psi.Arguments = $"\"{scriptPath}\"";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                process = Process.Start(psi);
                pythonInput = process.StandardInput;  // Giữ stream input để gửi dữ liệu đến Python
            }
        }
        private void pbFaceID_Click(object sender, EventArgs e)
        {
            if (process == null || process.HasExited)
            {
                StartPythonProcess();  // Khởi động lại nếu process đã bị tắt
            }

            pythonInput.WriteLine("detect");  // Gửi tín hiệu nhận diện
            string result = process.StandardOutput.ReadLine();
            if (!string.IsNullOrEmpty(result))
            {
                //MessageBox.Show(result);
                result = result.Replace("[", "").Replace("]", "").Replace("'", "").Trim();
                //MessageBox.Show(result);
                ProcessRecognitionResult(result);
            }
            else
            {
                HienThiLoi("Không thể nhận diện được");
            }
        }

        private void ProcessRecognitionResult(string result)
        {
            // Phân tích để lấy ID

            string idLine = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).
                            FirstOrDefault(line => line.StartsWith("ID:"));

            if (result != null)
            {
                //string idString = idLine.Split(':')[1].Trim();  // Lấy giá trị ID
                if (result == "0")
                {
                    HienThiLoi("Không thể nhận diện được");
                    return;
                }
                //MessageBox.Show("1");
                QuanTriVienDTO user = dangNhapBUS.ThongTinTheoId(Convert.ToInt32(result));
                Form form;
                StopPythonProcess();
                if (user.ChucVu == "Admin")
                {
                    dangNhapBUS.CapNhatPhien(user.Id);
                    form = new GUI.Administrator.MainForm(user);
                }
                else if (user.ChucVu == "Doctor")
                {
                    dangNhapBUS.CapNhatPhien(user.Id);
                    form = new GUI.BacSi.FormBacSi(user);
                }
                else
                {
                    dangNhapBUS.CapNhatPhien(user.Id);
                    form = new GUI.Receptionist.FormLeTan(user);
                }

                this.Hide();
                mainForm.Hide();
                form.FormClosed += (s, args) => Application.Exit();
                form.Show();
            }
        }
        private void StopPythonProcess()
        {
            if (process != null && !process.HasExited)
            {
                process.Kill();
                process.Dispose();
                process = null;
            }
        }

        private void HienThiFaceID()
        {

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "python";  // Đảm bảo đường dẫn "python" đúng hoặc thay bằng đường dẫn đầy đủ đến python.exe

            psi.Arguments = $"C:/Users/Nguyen/Desktop/Dental_Clinic/real-time-face-recognition/face_recognizer.py";

            //string currentPath = Application.StartupPath;
            //string projectRoot = Directory.GetParent(currentPath).Parent.Parent.Parent.FullName;
            //string scriptPath = Path.Combine(projectRoot, "real-time-face-recognition", "face_recognizer.py");
            //psi.Arguments = scriptPath;

            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true; // Thêm dòng này

            // Chạy script và đọc output
            using (Process process = Process.Start(psi))
            {
                string errorResult = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(errorResult))
                {
                    MessageBox.Show("Lỗi từ Python: " + errorResult);
                }
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();

                    // Phân tích để lấy ID
                    string idLine = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                           .FirstOrDefault(line => line.StartsWith("ID:"));
                    MessageBox.Show(idLine);
                    if (idLine != null)
                    {
                        string idString = idLine.Split(':')[1].Trim();  // Lấy giá trị ID
                        MessageBox.Show("ID nhận diện được: " + idString);
                        //Console.WriteLine("Python output: " + idString);
                    }
                }
            }
        }
        private void TbUser_Enter(object sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "Tên đăng nhập")
            {
                tbTenDangNhap.Text = "";
                tbTenDangNhap.ForeColor = Color.Black;
            }
        }
        private void TbUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTenDangNhap.Text))
            {
                tbTenDangNhap.Text = "Tên đăng nhập";
                tbTenDangNhap.ForeColor = Color.Gray;
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbTenDangNhap.Focus();

            // Ẩn pbHienMatKhau
            pbHienMatKhau.Visible = true;
            pbAnMatKhau.Visible = false;
            tbMatKhau.UseSystemPasswordChar = true;
        }
        // Hiển thị label thông báo lỗi
        private void HienThiLoi(string text)
        {
            lbSai.Visible = true;
            lbSai.Text = text;
        }
        // Ẩn label thông báo lỗi
        private void AnLoi()
        {
            lbSai.Visible = false;
            lbSai.Text = "";
        }

        // Sự kiện cho tbPassword
        private void TbPassword_Enter(object? sender, EventArgs e)
        {
            if (tbMatKhau.Text == "Mật khẩu")
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
                tbMatKhau.Text = "Mật khẩu";
                tbMatKhau.ForeColor = Color.Gray;
                tbMatKhau.UseSystemPasswordChar = false; // Hiển thị lại placeholder không ẩn ký tự
            }
        }
        private void DangNhap()
        {
            AnLoi();
            if (!KiemTraDauVao())
            {
                return;
            }

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
                HienThiLoi("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
        // Kiểm tra dữ liệu đầu vào
        private bool KiemTraDauVao()
        {
            if (string.IsNullOrWhiteSpace(tbTenDangNhap.Text) || tbTenDangNhap.Text == "Tên đăng nhập")
            {
                HienThiLoi("Vui lòng nhập tên đăng nhập");
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbMatKhau.Text) || tbMatKhau.Text == "Mật khẩu")
            {
                HienThiLoi("Vui lòng nhập mật khẩu");
                return false;
            }
            return true;
        }
        // SỰ KIỆN ENTER ĐĂNG NHẬP
        private void tbEnter_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }
        private void pbHienMatKhau_Click(object sender, EventArgs e)
        {
            pbHienMatKhau.Visible = false;
            pbAnMatKhau.Visible = true;
            tbMatKhau.UseSystemPasswordChar = false;
        }
        private void pbAnMatKhau_Click(object sender, EventArgs e)
        {
            pbHienMatKhau.Visible = true;
            pbAnMatKhau.Visible = false;
            tbMatKhau.UseSystemPasswordChar = true;
        }
        // Sự kiện cho lbQuenMatKhau
        private void lbQuenMatKhau_Click(object? sender, EventArgs e)
        {
            mainForm.HienThiFormQuenMatkhau();
        }
        // Sự kiện cho vbDangNhap
        private void vbDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
    }
}
