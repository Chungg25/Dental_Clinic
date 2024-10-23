﻿using CustomButton;
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

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class ReceptionistForm : Form
    {
        private MainForm _mainForm;
        public ReceptionistForm(MainForm mainForm)
        {
            InitializeComponent();
            CreateTableLayoutPanel();
            _mainForm = mainForm;

            vbBacSi.FlatStyle = FlatStyle.Flat;
            vbBacSi.FlatAppearance.BorderSize = 0;
            vbBacSi.FlatAppearance.MouseOverBackColor = vbBacSi.BackColor;
            vbBacSi.FlatAppearance.MouseDownBackColor = vbBacSi.BackColor;

            vbLeTan.FlatStyle = FlatStyle.Flat;
            vbLeTan.FlatAppearance.BorderSize = 0;
            vbLeTan.FlatAppearance.MouseOverBackColor = vbLeTan.BackColor;
            vbLeTan.FlatAppearance.MouseDownBackColor = vbLeTan.BackColor;

            vbThemLeTan.FlatStyle = FlatStyle.Flat;
            vbThemLeTan.FlatAppearance.BorderSize = 0;
            vbThemLeTan.FlatAppearance.MouseOverBackColor = vbThemLeTan.BackColor;
            vbThemLeTan.FlatAppearance.MouseDownBackColor = vbThemLeTan.BackColor;

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

        //Phần này để tạo hiển thị danh sách lễ tân
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

        // Hàm để tạo CheckBox
        private CheckBox CreateCheckBox(bool isChecked)
        {
            return new CheckBox
            {
                Checked = isChecked,
                AutoSize = true,
                Padding = new Padding(15, 0, 0, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
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
        private void AddActionButtonsToTableLayoutPanel(TableLayoutPanel tlpUser, int rowIndex)
        {
            Image ResizeImage(Image img, int width, int height)
            {
                return new Bitmap(img, new Size(width, height));
            }

            // Đặt icon cho nút chỉnh sửa và xóa từ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);
            Image deleteIcon = ResizeImage(Properties.Resources.trash_bin, 25, 25);

            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = CreateActionButton(editEditColor, editIcon);
            Color editDeleteColor = ColorTranslator.FromHtml("#dc3545");
            Button btnDelete = CreateActionButton(editDeleteColor, deleteIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => { ShowEditReceptionInPanel(); };
            btnDelete.Click += (s, e) => { MessageBox.Show("Xóa"); };

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
            panelActions.Controls.Add(btnDelete);

            // Thêm Panel vào cột thao tác của hàng hiện tại
            tlpUser.Controls.Add(panelActions, 5, rowIndex);
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void AddRowToTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, bool khoa)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(CreateLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(CreateLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(CreateLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(CreateLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(CreateCheckBox(khoa), 4, currentRow); // Thêm CheckBox
            AddActionButtonsToTableLayoutPanel(tlpUser, currentRow);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void CreateTableLayoutPanel()
        {
            // Tạo TableLayoutPanel
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
            tlpUser.Controls.Add(CreateLabel("Khóa", headerFont), 4, 0);
            tlpUser.Controls.Add(CreateLabel("Thao tác", headerFont), 5, 0);

            // Thêm TableLayoutPanel vào form
            panelLeTan.Controls.Add(tlpUser);

            // Thêm một hàng mẫu
            AddRowToTableLayoutPanel(tlpUser, "1", "Nguyễn Văn A", "Nam", "example@example.com", false);
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }


        //Phần này để chuyển trang

        private void vbThemLeTan_Click(object sender, EventArgs e)
        {
            ShowAddReceptionInPanel();
        }

        public void ShowAddReceptionInPanel()
        {
            AddReceptionForm addReceptionForm = new AddReceptionForm(_mainForm);
            addReceptionForm.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            addReceptionForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            addReceptionForm.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(addReceptionForm); // Thêm userForm vào panel
            addReceptionForm.BringToFront();
            addReceptionForm.Show(); // Hiển thị userForm
        }

        private void vbBacSi_Click(object sender, EventArgs e)
        {
            ShowUserInPanel();
        }
        public void ShowUserInPanel()
        {
            UserForm userForm = new UserForm(_mainForm);
            userForm.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            userForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            userForm.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(userForm); // Thêm userForm vào panel
            userForm.BringToFront();
            userForm.Show(); // Hiển thị userForm
        }
        public void ShowEditReceptionInPanel()
        {
            EditReceptionForm editReceptionForm = new EditReceptionForm(_mainForm);
            editReceptionForm.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            editReceptionForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            editReceptionForm.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(editReceptionForm); // Thêm userForm vào panel
            editReceptionForm.BringToFront();
            editReceptionForm.Show(); // Hiển thị userForm
        }

        //Kết thúc
    }
}