using CustomButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class SalaryManagementForm : Form
    {
        private TableLayoutPanel tlpData;
        public SalaryManagementForm(MainForm mainForm)
        {
            InitializeComponent();
            showDataDoctor();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";  // Hiển thị tháng và năm
            dateTimePicker1.AutoSize = false;            // Tắt AutoSize để có thể thay đổi kích thước
            dateTimePicker1.Size = new Size(160, 30);

            vbLeTan.FlatStyle = FlatStyle.Flat;
            vbLeTan.FlatAppearance.BorderSize = 0;
            vbLeTan.FlatAppearance.MouseOverBackColor = vbLeTan.BackColor;
            vbLeTan.FlatAppearance.MouseDownBackColor = vbLeTan.BackColor;

            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatAppearance.MouseOverBackColor = vbBacSi.BackColor;
            vbBacSi.FlatAppearance.MouseDownBackColor = vbBacSi.BackColor;

            vbTimKiem.BorderSize = 1;
            vbTimKiem.BorderColor = Color.Black;
            vbTimKiem.FlatAppearance.MouseOverBackColor = vbTimKiem.BackColor;
            vbTimKiem.FlatAppearance.MouseDownBackColor = vbTimKiem.BackColor;

            tbTimKiem.Font = new Font("Segoe UI", 12F);
            tbTimKiem.Text = "Tìm kiếm";
            tbTimKiem.ForeColor = Color.Gray;
            tbTimKiem.Enter += tbTimKiem_Enter;
            tbTimKiem.Leave += tbTimKiem_Leave;
        }

        //Phần này để chỉnh sửa các control
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

        //Kết thúc


        //Phần này để tạo hiển thị danh sách bác sĩ
        //Hàm CreateTableLayoutPanel() được gọi trên đầu để tạo panel hiển thị
        //Hàm AddRowToTableLayoutPanel để thêm dữ liệu vào
        //Xem hàm CreateTableLayoutPanel() để biết thêm chi tiết

        // Hàm để tạo Label
        private Label CreateLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                AutoSize = true,
                Padding = new Padding(10, 5, 10, 5), // Tăng khoảng cách bên trái và bên phải
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void AddRowToTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string luongCoDinh, string heSoLuong, string soCa, string tongLuong)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(CreateLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(CreateLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(CreateLabel(luongCoDinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(CreateLabel(heSoLuong, headerFont), 3, currentRow);
            tlpUser.Controls.Add(CreateLabel(soCa, headerFont), 4, currentRow);
            tlpUser.Controls.Add(CreateLabel(tongLuong, headerFont), 5, currentRow); // Thêm CheckBox
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private TableLayoutPanel CreateTableLayoutPanel()
        {
            // Tạo TableLayoutPanel
            TableLayoutPanel tlpData = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
            };

            // Thiết lập số cột
            tlpData.ColumnCount = 6;
            for (int i = 0; i < tlpData.ColumnCount; i++)
            {
                tlpData.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpData.RowCount = 1;
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            tlpData.Controls.Add(CreateLabel("STT", headerFont), 0, 0);
            tlpData.Controls.Add(CreateLabel("Tên người dùng", headerFont), 1, 0);
            tlpData.Controls.Add(CreateLabel("Lương cố định", headerFont), 2, 0);
            tlpData.Controls.Add(CreateLabel("Hệ số lương", headerFont), 3, 0);
            tlpData.Controls.Add(CreateLabel("Số ca", headerFont), 4, 0);
            tlpData.Controls.Add(CreateLabel("Tổng lương", headerFont), 5, 0);

            // Thêm TableLayoutPanel vào form
            //panelDuLieu.Controls.Add(tlpDoctor);

            //AddRowToTableLayoutPanel(tlpDoctor, "1", "Nguyễn Văn A", "1000", "2", "5", "10000");
            return tlpData;
        }

        private void CreateDataPanel()
        {
            tlpData = CreateTableLayoutPanel();
            panelDuLieu.Controls.Clear();
            panelDuLieu.Controls.Add(tlpData);
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
        //Kết thúc


        //Phần điều hướng


        //Kết thúc

        //Phần hiển thị dữ liệu
        private void vbBacSi_Click(object sender, EventArgs e)
        {
            showDataDoctor();

        }

        private void showDataDoctor()
        {
            CreateDataPanel();
            AddRowToTableLayoutPanel(tlpData, "1", "Nguyễn Văn A", "1000", "2", "5", "10000");

        }

        private void vbLeTan_Click(object sender, EventArgs e)
        {
            showDataReception();
        }

        private void showDataReception()
        {
            CreateDataPanel();
            AddRowToTableLayoutPanel(tlpData, "1", "Nguyễn Văn B", "1000", "2", "5", "10000");

        }

        //Kết thúc
    }
}
