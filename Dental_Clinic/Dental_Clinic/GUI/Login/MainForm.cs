using System;
using System.Windows.Forms;
using Dental_Clinic.GUI.Login;
namespace Dental_Clinic.GUI
{
    public partial class Dental_Clinic : Form
    {

        public Dental_Clinic()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            ShowLoginFormInPanel();
        }

        // Hàm hiển thị LoginForm trong panel
        public void ShowLoginFormInPanel()
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.TopLevel = false; // Đặt LoginForm không phải là form cấp cao nhất (TopLevel)
            loginForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của LoginForm
            loginForm.Dock = DockStyle.Fill; // Đặt LoginForm khớp với kích thước panel
            panel.Controls.Clear(); // Xóa các control cũ trong panel nếu có
            panel.Controls.Add(loginForm); // Thêm LoginForm vào panel
            loginForm.Show(); // Hiển thị LoginForm
        }

        // Hàm hiển thị ForgotPassword trong panel
        public void ShowForgotPasswordInPanel()
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword(this);
            forgotPasswordForm.TopLevel = false; // Đặt ForgotPassword không phải là form cấp cao nhất (TopLevel)
            forgotPasswordForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của ForgotPassword
            forgotPasswordForm.Dock = DockStyle.Fill; // Đặt ForgotPassword khớp với kích thước panel
            panel.Controls.Clear(); // Xóa các control cũ trong panel nếu có
            panel.Controls.Add(forgotPasswordForm); // Thêm ForgotPassword vào panel
            forgotPasswordForm.Show(); // Hiển thị ForgotPassword
        }
    }
}
