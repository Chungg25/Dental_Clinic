using CustomButton;
using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DTO.Admin;
using System.Globalization;
using System.Numerics;

namespace Dental_Clinic.GUI.Administrator.User
{
    public partial class FormLeTan : Form
    {
        private MainForm _mainForm;
        private LeTanBUS leTanBUS;
        public FormLeTan(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            leTanBUS = new LeTanBUS();
            List<LeTanDTO> leTan = leTanBUS.LayDanhSachLeTan();
            TaoTableLayoutPanel(leTan);
            
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
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
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
        private Label TaoLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                AutoSize = true,
                Padding = new Padding(10, 5, 10, 5), // Tăng khoảng cách bên trái và bên phải
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
            };
        }

        // Hàm để tạo CheckBox
        private CheckBox TaoCheckBox(int status, int id)
        {
            CheckBox checkBox = new CheckBox
            {
                Checked = (status == 0),
                AutoSize = true,
                Padding = new Padding(15, 0, 0, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Tag = id
            };

            // Bắt sự kiện CheckedChanged để cập nhật vào database
            checkBox.CheckedChanged += (sender, e) =>
            {
                CheckBox cb = sender as CheckBox;
                if (cb != null)
                {
                    int userId = (int)cb.Tag;
                    int isChecked = cb.Checked ? 0 : 1;

                    leTanBUS.CapNhatTrangThai(userId);
                }
            };
            return checkBox;
        }

        // Hàm tạo nút hành động (chỉnh sửa và xóa)
        private Button TaoActionButton(Color backgroundColor, Image icon)
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
        private void ThemActionButtonsVaoTableLayoutPanel(TableLayoutPanel tlpUser, int rowIndex, int id)
        {
            Image ResizeImage(Image img, int width, int height)
            {
                return new Bitmap(img, new Size(width, height));
            }

            // Đặt icon cho nút chỉnh sửa từ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);

            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = TaoActionButton(editEditColor, editIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => { HienThiChinhSuaLeTan(id); };

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
            tlpUser.Controls.Add(panelActions, 5, rowIndex);
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void ThemHangVaoTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, int status, int id)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(TaoLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(TaoLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(TaoLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(TaoLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(TaoCheckBox(status, id), 4, currentRow); // Thêm CheckBox
            ThemActionButtonsVaoTableLayoutPanel(tlpUser, currentRow, id);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void TaoTableLayoutPanel(List<LeTanDTO> leTans)
        {
            if (panelLeTan.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelLeTan.Controls.Clear();
            }

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
            tlpUser.Controls.Add(TaoLabel("STT", headerFont), 0, 0);
            tlpUser.Controls.Add(TaoLabel("Tên người dùng", headerFont), 1, 0);
            tlpUser.Controls.Add(TaoLabel("Giới tính", headerFont), 2, 0);
            tlpUser.Controls.Add(TaoLabel("Email", headerFont), 3, 0);
            tlpUser.Controls.Add(TaoLabel("Khóa", headerFont), 4, 0);
            tlpUser.Controls.Add(TaoLabel("Thao tác", headerFont), 5, 0);

            // Tạo Panel chứa TableLayoutPanel và bật AutoScroll
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };

            scrollablePanel.Controls.Add(tlpUser);
            // Thêm TableLayoutPanel vào form
            panelLeTan.Controls.Add(scrollablePanel);

            int sequenceNumber = 1;
            foreach (var leTan in leTans)
            {
                string genderText = leTan.GioiTinh ? "Nam" : "Nữ";
                int status = leTan.TrangThai;
                ThemHangVaoTableLayoutPanel(tlpUser, sequenceNumber.ToString(), leTan.HoVaTen, genderText, leTan.Email, status, leTan.Id);
                sequenceNumber++;
            }
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Lấy nội dung tìm kiếm từ tbTimKiem
            string searchText = tbTimKiem.Text.ToLower();

            // Lấy danh sách bác sĩ từ doctorBUS
            var receptionistList = leTanBUS.LayDanhSachLeTan();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Nếu ô tìm kiếm trống, không tạo bảng mới
                return;
            }

            // Lọc danh sách theo họ tên
            var filteredList = receptionistList
                .Where(d => d.HoVaTen.ToLower().Contains(searchText))
                .ToList();
            if (filteredList.Any())
            {
                TaoTableLayoutPanel(filteredList);
            }
        }


        //Phần này để chuyển trang

        private void vbThemLeTan_Click(object sender, EventArgs e)
        {
            HienThiThemLeTan();
        }

        public void HienThiThemLeTan()
        {
            FormThemLeTan formThemLeTan = new FormThemLeTan(_mainForm);
            formThemLeTan.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            formThemLeTan.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            formThemLeTan.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(formThemLeTan); // Thêm userForm vào panel
            formThemLeTan.BringToFront();
            formThemLeTan.Show(); // Hiển thị userForm
        }

        private void vbBacSi_Click(object sender, EventArgs e)
        {
            HienThiBacSI();
        }
        public void HienThiBacSI()
        {
            FormBacSi formBacSi = new FormBacSi(_mainForm);
            formBacSi.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            formBacSi.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            formBacSi.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(formBacSi); // Thêm userForm vào panel
            formBacSi.BringToFront();
            formBacSi.Show(); // Hiển thị userForm
        }
        public void HienThiChinhSuaLeTan(int id)
        {
            FormChinhSuaLeTan formChinhSuaLeTan = new FormChinhSuaLeTan(_mainForm, leTanBUS.LayThongTinLeTan(id));
            formChinhSuaLeTan.TopLevel = false; // Đặt userForm không phải là form cấp cao nhất (TopLevel)
            formChinhSuaLeTan.FormBorderStyle = FormBorderStyle.None; // Xóa viền của userForm
            formChinhSuaLeTan.Dock = DockStyle.Fill; // Đặt userForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(formChinhSuaLeTan); // Thêm userForm vào panel
            formChinhSuaLeTan.BringToFront();
            formChinhSuaLeTan.Show(); // Hiển thị userForm
        }

        //Kết thúc
    }
}
