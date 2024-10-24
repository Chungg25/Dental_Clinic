﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomButton;
using Dental_Clinic.GUI.Administrator.WorkSchedule;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class WorkScheduleForm : Form
    {
        private MainForm _mainForm;
        public WorkScheduleForm(MainForm mainForm)
        {
            InitializeComponent();
            CreateDoctorTableLayoutPanel();
            _mainForm = mainForm;

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

        private void vbBacSi_Click(object sender, EventArgs e)
        {
            CreateDoctorTableLayoutPanel();
        }

        private void vbLeTan_Click(object sender, EventArgs e)
        {
            CreateReceptionTableLayoutPanel();
        }

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

        // Hàm tạo nút hành động (chỉnh sửa và xóa)
        private Button CreateActionButton(Color backgroundColor, Image icon)
        {
            VBButton button = new VBButton
            {
                Width = 40,  // Kích thước nút
                Height = 40,
                BorderRadius = 10, // Chỉnh độ bo góc, nếu không là hình tròn
                FlatStyle = FlatStyle.Flat,  // Loại bỏ viền nút
                BackColor = backgroundColor, // Màu nền của nút
                Image = icon, // Đặt icon cho nút
                ImageAlign = ContentAlignment.MiddleCenter, // Căn giữa icon
                FlatAppearance = { BorderSize = 0 }, // Loại bỏ viền bao quanh
                Cursor = Cursors.Hand // Đặt kiểu chuột khi di qua nút
            };
            return button;
        }


        // Hàm thêm các nút hành động (chỉnh sửa và xóa)
        private void AddActionButtonsToTableLayoutPanel(TableLayoutPanel tlpUser, int index,int rowIndex)
        {
            Image ResizeImage(Image img, int width, int height)
            {
                return new Bitmap(img, new Size(width, height));
            }

            // Đặt icon cho nút chỉnh sửa và xóa từ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);

            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = CreateActionButton(editEditColor, editIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => { ShowEditWorkSchedulInPanel(); };

            // Tạo một Panel để chứa 2 nút
            FlowLayoutPanel panelActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(15, 0, 0, 0),
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight, // Sắp xếp các điều khiển theo chiều ngang
                WrapContents = false
            };

            // Thêm các nút vào panel
            panelActions.Controls.Add(btnEdit);

            // Thêm Panel vào cột thao tác của hàng hiện tại
            tlpUser.Controls.Add(panelActions, index, rowIndex);
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void AddRowToDoctorTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, string chuyenNganh, string soCa)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(CreateLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(CreateLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(CreateLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(CreateLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(CreateLabel(chuyenNganh, headerFont), 4, currentRow);
            tlpUser.Controls.Add(CreateLabel(soCa, headerFont), 5, currentRow); // Thêm CheckBox
            AddActionButtonsToTableLayoutPanel(tlpUser, 6, currentRow);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void CreateDoctorTableLayoutPanel()
        {

            TableLayoutPanel tlpUser = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
            };

            // Thiết lập số cột
            tlpUser.ColumnCount = 7;
            for (int i = 0; i < tlpUser.ColumnCount; i++)
            {
                tlpUser.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpUser.RowCount = 1;
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            tlpUser.Controls.Add(CreateLabel("STT", headerFont), 0, 0);
            tlpUser.Controls.Add(CreateLabel("Tên người dùng", headerFont), 1, 0);
            tlpUser.Controls.Add(CreateLabel("Giới tính", headerFont), 2, 0);
            tlpUser.Controls.Add(CreateLabel("Email", headerFont), 3, 0);
            tlpUser.Controls.Add(CreateLabel("Chuyên ngành", headerFont), 4, 0);
            tlpUser.Controls.Add(CreateLabel("Số ca", headerFont), 5, 0);
            tlpUser.Controls.Add(CreateLabel("Thao tác", headerFont), 6, 0);

            // Xóa các control khác
            ClearControlsExcept(tlpUser);

            // Thêm TableLayoutPanel vào form
            panelDuLieu.Controls.Add(tlpUser);

            // Thêm một hàng mẫu
            AddRowToDoctorTableLayoutPanel(tlpUser, "1", "Nguyễn Văn A", "Nam", "example@example.com", "Nha khoa", "5");
        }

        private void AddRowToReceptionTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, string soCa)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(CreateLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(CreateLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(CreateLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(CreateLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(CreateLabel(soCa, headerFont), 4, currentRow); // Thêm CheckBox
            AddActionButtonsToTableLayoutPanel(tlpUser, 5, currentRow);
        }

        private void CreateReceptionTableLayoutPanel()
        {

            TableLayoutPanel tlpReception = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = false,
            };

            // Thiết lập số cột
            tlpReception.ColumnCount = 7;
            for (int i = 0; i < tlpReception.ColumnCount; i++)
            {
                tlpReception.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpReception.RowCount = 1;
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            tlpReception.Controls.Add(CreateLabel("STT", headerFont), 0, 0);
            tlpReception.Controls.Add(CreateLabel("Tên người dùng", headerFont), 1, 0);
            tlpReception.Controls.Add(CreateLabel("Giới tính", headerFont), 2, 0);
            tlpReception.Controls.Add(CreateLabel("Email", headerFont), 3, 0);
            tlpReception.Controls.Add(CreateLabel("Số ca", headerFont), 4, 0);
            tlpReception.Controls.Add(CreateLabel("Thao tác", headerFont), 5, 0);

            // Xóa các control khác
            ClearControlsExcept(tlpReception);

            // Thêm TableLayoutPanel vào form
            panelDuLieu.Controls.Add(tlpReception);

            // Thêm một hàng mẫu
            AddRowToReceptionTableLayoutPanel(tlpReception, "1", "Nguyễn Văn A", "Nam", "example@example.com", "5");
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        private void ClearControlsExcept(TableLayoutPanel controlToKeep)
        {
            // Duyệt qua danh sách điều khiển theo chiều ngược lại để tránh vấn đề khi xóa
            for (int i = panelDuLieu.Controls.Count - 1; i >= 0; i--)
            {
                Control control = panelDuLieu.Controls[i];
                // Kiểm tra nếu điều khiển không phải là tlpReception
                if (control != controlToKeep)
                {
                    panelDuLieu.Controls.Remove(control);
                }
            }
        }

        //Kết thúc

        //Phần điều hướng
        public void ShowEditWorkSchedulInPanel()
        {
            EditWorkScheduleForm editWorkSchedulForm = new EditWorkScheduleForm(_mainForm);
            editWorkSchedulForm.TopLevel = false; // Đặt editUserForm không phải là form cấp cao nhất (TopLevel)
            editWorkSchedulForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của editUserForm
            editWorkSchedulForm.Dock = DockStyle.Fill; // Đặt editUserForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(editWorkSchedulForm); // Thêm editUserForm vào panel
            editWorkSchedulForm.BringToFront();
            editWorkSchedulForm.Show(); // Hiển thị editUserForm
        }

        //Kết thúc
    }
}
