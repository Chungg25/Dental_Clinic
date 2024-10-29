using System.Globalization;
using CustomButton;
using Dental_Clinic.GUI.Administrator.User;
using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DTO.Admin;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class UserForm : Form
    {
        private DoctorBUS doctorBUS;
        private MainForm _mainForm;
        public UserForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            doctorBUS = new DoctorBUS();
            List<DoctorDTO> doctors = doctorBUS.LayDanhSachBacSi();
            CreateTableLayoutPanel(doctors);

            vbThemBacSi.FlatStyle = FlatStyle.Flat;
            vbThemBacSi.FlatAppearance.BorderSize = 0;
            vbThemBacSi.FlatAppearance.MouseOverBackColor = vbThemBacSi.BackColor;
            vbThemBacSi.FlatAppearance.MouseDownBackColor = vbThemBacSi.BackColor;

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

        // Hàm để tạo CheckBox
        private CheckBox CreateCheckBox(int status, int id)
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

                    doctorBUS.CapNhatTrangThai(userId);
                }
            };

            return checkBox;
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
        private void AddActionButtonsToTableLayoutPanel(TableLayoutPanel tlpUser, int rowIndex, int id)
        {
            Image ResizeImage(Image img, int width, int height)
            {
                return new Bitmap(img, new Size(width, height));
            }

            // Đặt icon cho nút chỉnh sửatừ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);
            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = CreateActionButton(editEditColor, editIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => { ShowEditUserInPanel(id); };
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
            tlpUser.Controls.Add(panelActions, 6, rowIndex);
        }

        // Hàm để thêm hàng mới vào TableLayoutPanel
        private void AddRowToTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, string chuyenNganh, int status, int id)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(CreateLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(CreateLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(CreateLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(CreateLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(CreateLabel(chuyenNganh, headerFont), 4, currentRow);
            tlpUser.Controls.Add(CreateCheckBox(status, id), 5, currentRow); // Thêm CheckBox
            AddActionButtonsToTableLayoutPanel(tlpUser, currentRow, id);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void CreateTableLayoutPanel(List<DoctorDTO> doctors)
        {
            if (panelBacSi.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelBacSi.Controls.Clear();
            }

            // Tạo TableLayoutPanel
            TableLayoutPanel tlpUser = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
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
            tlpUser.Controls.Add(CreateLabel("Khóa", headerFont), 5, 0);
            tlpUser.Controls.Add(CreateLabel("Thao tác", headerFont), 6, 0);

            // Tạo Panel chứa TableLayoutPanel và bật AutoScroll
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpUser);

            // Thêm Panel vào form
            panelBacSi.Controls.Add(scrollablePanel);

            // Thêm một hàng mẫu
            int sequenceNumber = 1;
            foreach (var doctor in doctors)
            {
                string genderText = doctor.GioiTinh ? "Nam" : "Nữ";
                int status = doctor.TrangThai;
                AddRowToTableLayoutPanel(tlpUser, sequenceNumber.ToString(), doctor.HoVaTen, genderText, doctor.Email, doctor.ChuyenNganh, status, doctor.Id);
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
            var doctorList = doctorBUS.LayDanhSachBacSi();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Nếu ô tìm kiếm trống, không tạo bảng mới
                return;
            }

            // Lọc danh sách theo họ tên
            var filteredList = doctorList
                .Where(d => d.HoVaTen.ToLower().Contains(searchText))
                .ToList();
            if (filteredList.Any())
            {
                CreateTableLayoutPanel(filteredList);
            }
        }

        //Kết thúc


        //Phần này để chuyển trang
        private void vbThemBacSi_Click(object sender, EventArgs e)
        {
            ShowAddUserInPanel();
        }

        public void ShowAddUserInPanel()
        {
            AddUserForm addUserForm = new AddUserForm(_mainForm);
            addUserForm.TopLevel = false; // Đặt addUserForm không phải là form cấp cao nhất (TopLevel)
            addUserForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của addUserForm
            addUserForm.Dock = DockStyle.Fill; // Đặt addUserForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(addUserForm); // Thêm addUserForm vào panel
            addUserForm.BringToFront();
            addUserForm.Show(); // Hiển thị addUserForm
        }

        private void vbLeTan_Click(object sender, EventArgs e)
        {
            ShowReceptionistInPanel();
        }

        public void ShowReceptionistInPanel()
        {
            User.ReceptionistForm receptionistForm = new User.ReceptionistForm(_mainForm);
            receptionistForm.TopLevel = false; // Đặt receptionistForm không phải là form cấp cao nhất (TopLevel)
            receptionistForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của receptionistForm
            receptionistForm.Dock = DockStyle.Fill; // Đặt receptionistForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(receptionistForm); // Thêm receptionistForm vào panel
            receptionistForm.BringToFront();
            receptionistForm.Show(); // Hiển thị receptionistForm
        }

        public void ShowEditUserInPanel(int id)
        {
            EditUserForm editUserForm = new EditUserForm(_mainForm, doctorBUS.LayThongTinBacSi(id));
            editUserForm.TopLevel = false; // Đặt editUserForm không phải là form cấp cao nhất (TopLevel)
            editUserForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền của editUserForm
            editUserForm.Dock = DockStyle.Fill; // Đặt editUserForm khớp với kích thước panel
            _mainForm.panelTrangChu.Controls.Add(editUserForm); // Thêm editUserForm vào panel
            editUserForm.BringToFront();
            editUserForm.Show(); // Hiển thị editUserForm
        }
        //Kết thúc
    }
}
