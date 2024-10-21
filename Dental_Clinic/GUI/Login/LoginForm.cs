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


namespace Dental_Clinic.GUI.Login
{
    public partial class LoginForm : Form
    {
        private Dental_Clinic mainForm;
        public LoginForm(Dental_Clinic mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            CustomizeButton(btnDangNhap);

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

        private void CustomizeButton(Button button)
        {
            // Sự kiện Paint cho nút để bo góc
            button.Paint += (s, e) =>
            {
                // Đặt bán kính bo góc
                int borderRadius = 40;

                // Tạo đường viền bo góc
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.StartFigure();
                    path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Góc trên bên trái
                    path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Góc trên bên phải
                    path.AddArc(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Góc dưới bên phải
                    path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Góc dưới bên trái
                    path.CloseFigure();
                    button.Region = new Region(path);
                }

                // Thiết lập màu nền và màu chữ
                button.BackColor = Color.FromArgb(0, 89, 253); // Màu nền theo RGB (0, 89, 253)
                button.ForeColor = Color.White; // Màu chữ
            };
        }

        private void lbQuenMatKhau_Click(object? sender, EventArgs e)
        {
            mainForm.ShowForgotPasswordInPanel(); // Gọi hàm để hiển thị ForgotPassword
        }
    }
}
