using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class UserForm : Form
    {
        private MainForm _mainForm;
        public UserForm(MainForm mainForm)
        {
            InitializeComponent();
            CreateTableLayoutPanel();
            _mainForm = mainForm;

            vbThemBacSi.FlatStyle = FlatStyle.Flat;
            vbThemBacSi.FlatAppearance.BorderSize = 0;
            vbThemBacSi.FlatAppearance.MouseOverBackColor = vbThemBacSi.BackColor;
            vbThemBacSi.FlatAppearance.MouseDownBackColor = vbThemBacSi.BackColor;

            vbButton8.BorderSize = 1;
            vbButton8.BorderColor = Color.Black;
            vbButton8.FlatAppearance.MouseOverBackColor = vbButton8.BackColor;
            vbButton8.FlatAppearance.MouseDownBackColor = vbButton8.BackColor;

            tbTimKiem.Font = new Font("Segoe UI", 12F);
            tbTimKiem.Text = "Tìm kiếm";
            tbTimKiem.ForeColor = Color.Gray;
            tbTimKiem.Enter += tbTimKiem_Enter;
            tbTimKiem.Leave += tbTimKiem_Leave;
        }

        private void tbTimKiem_Enter(object? sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Tìm kiếm")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = Color.Black;
            }
        }

        private void tbTimKiem_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiem.Text))
            {
                tbTimKiem.Text = "Tìm kiếm";
                tbTimKiem.ForeColor = Color.Gray;
            }
        }

        private void CreateTableLayoutPanel()
        {
            // Tạo TableLayoutPanel
            TableLayoutPanel tlpUser = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, // Đặt để TLP lấp đầy form
                AutoSize = false, // Tự động điều chỉnh kích thước
            };

            // Thiết lập số cột
            tlpUser.ColumnCount = 7; // Giả sử bạn có 7 cột
            for (int i = 0; i < tlpUser.ColumnCount; i++)
            {
                tlpUser.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Tự động điều chỉnh kích thước cột
            }

            // Thiết lập số hàng và thêm các Label vào TableLayoutPanel
            tlpUser.RowCount = 2; // Giả sử bạn có 2 hàng

            Font headerFont = new Font("Arial", 12, FontStyle.Bold);

            // Thêm các Label vào hàng đầu tiên với chữ hoa chữ cái đầu và khoảng cách
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("STT"), headerFont), 0, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Tên người dùng"), headerFont), 1, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Giới tính"), headerFont), 2, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Email"), headerFont), 3, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Chuyên ngành"), headerFont), 4, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Khóa"), headerFont), 5, 0);
            tlpUser.Controls.Add(CreateLabel(ToTitleCase("Thao tác"), headerFont), 6, 0);

            // Thêm nội dung cho hàng thứ hai
            tlpUser.Controls.Add(CreateLabel("1", null), 0, 1);
            tlpUser.Controls.Add(CreateLabel("Nguyễn Văn A", null), 1, 1);
            tlpUser.Controls.Add(CreateLabel("Nam", null), 2, 1);
            tlpUser.Controls.Add(CreateLabel("example@example.com", null), 3, 1);
            tlpUser.Controls.Add(CreateLabel("Nha khoa", null), 4, 1);
            tlpUser.Controls.Add(CreateLabel("2024", null), 5, 1);
            tlpUser.Controls.Add(CreateLabel("Xem", null), 6, 1); // Thao tác

            // Thêm TableLayoutPanel vào form
            panel2.Controls.Add(tlpUser);
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        private Label CreateLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Font = font,
                Padding = new Padding(10, 5, 10, 5) // Tăng khoảng cách bên trái và bên phải
            };
        }

        private void vbThemBacSi_Click(object sender, EventArgs e)
        {
            ShowAddUserInPanel();
        }

        public void ShowAddUserInPanel()
        {
            User.AddUserForm addUserForm = new User.AddUserForm(_mainForm);
            addUserForm.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            addUserForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            addUserForm.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(addUserForm); // Thêm userForm vào panel
            addUserForm.BringToFront();
            addUserForm.Show(); // Hiển thị userForm
        }
    }
}
