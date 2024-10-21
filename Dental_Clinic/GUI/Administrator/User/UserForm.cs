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
        public UserForm(MainForm mainForm)
        {
            InitializeComponent();
            CreateTableLayoutPanel();
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
    }
}
