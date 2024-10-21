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
        private void lbQuenMatKhau_Click(object? sender, EventArgs e)
        {
            mainForm.ShowForgotPasswordInPanel(); // Gọi hàm để hiển thị ForgotPassword
        }
    }
}
