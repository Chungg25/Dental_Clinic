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
using CustomButton;
using Dental_Clinic.BUS.Admin;
using Dental_Clinic.BUS.LichLamViec;
using Dental_Clinic.DTO.LichLamViec;
using Dental_Clinic.GUI.Administrator.WorkSchedule;

namespace Dental_Clinic.GUI.Administrator
{
    public partial class FormLichLamViec : Form
    {
        private MainForm _mainForm;
        private LichLamViecBUS lichLamViecBUS;
        public FormLichLamViec(MainForm mainForm)
        {
            InitializeComponent();
            lichLamViecBUS = new LichLamViecBUS();
            _mainForm = mainForm;
            ChinhSua();
            HienThiBacSi();
        }

        public void ChinhSua()
        {
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
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
        }

        public void HienThiBacSi()
        {
            DateTime selectedDate = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime lastDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));
            List<LichLamViecDTO> lichLamViecBacSi = lichLamViecBUS.DanhSachLichLamViecBacSi(firstDayOfMonth, lastDayOfMonth);
            TaoDoctorTableLayoutPanel(lichLamViecBacSi);
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
            HienThiBacSi();
        }

        private void vbLeTan_Click(object sender, EventArgs e)
        {
            TaoReceptionTableLayoutPanel();
        }

        //Phần này để tạo hiển thị danh sách bác sĩ
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
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
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

            // Đặt icon cho nút chỉnh sửa và xóa từ Resources
            Image editIcon = ResizeImage(Properties.Resources.icons8_edit_64__2_, 30, 30);

            // Tạo các nút
            Color editEditColor = ColorTranslator.FromHtml("#0d6efd");
            Button btnEdit = TaoActionButton(editEditColor, editIcon);

            // Thêm sự kiện Click
            btnEdit.Click += (s, e) => { HienThiChinhSuaLichLamViec(id); };

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
        private void ThemHangVaoDoctorTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, string chuyenNganh, string soCa, int id)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(TaoLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(TaoLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(TaoLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(TaoLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(TaoLabel(chuyenNganh, headerFont), 4, currentRow);
            tlpUser.Controls.Add(TaoLabel(soCa, headerFont), 5, currentRow); // Thêm CheckBox
            ThemActionButtonsVaoTableLayoutPanel(tlpUser, currentRow, id);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void TaoDoctorTableLayoutPanel(List<LichLamViecDTO> lichLamViecBacSis)
        {
            if (panelDuLieu.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelDuLieu.Controls.Clear();
            }
            TableLayoutPanel tlpUser = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
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
            tlpUser.Controls.Add(TaoLabel("Chuyên ngành", headerFont), 4, 0);
            tlpUser.Controls.Add(TaoLabel("Số ca", headerFont), 5, 0);
            tlpUser.Controls.Add(TaoLabel("Thao tác", headerFont), 6, 0);

            // Xóa các control khác
            ClearControlsExcept(tlpUser);

            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpUser);

            // Thêm TableLayoutPanel vào form
            panelDuLieu.Controls.Add(scrollablePanel);

            // Thêm một hàng mẫu
            int sequenceNumber = 1;
            foreach (var lichLamViecBacSi in lichLamViecBacSis)
            {
                string genderText = lichLamViecBacSi.GioiTinh ? "Nam" : "Nữ";
                ThemHangVaoDoctorTableLayoutPanel(tlpUser, sequenceNumber.ToString(), lichLamViecBacSi.HoTen, genderText, lichLamViecBacSi.Email, lichLamViecBacSi.ChuyenNganh, lichLamViecBacSi.SoCa.ToString(), lichLamViecBacSi.MaNguoiDung);
                sequenceNumber++;
            }
        }

        private void ThemHangVaoReceptionTableLayoutPanel(TableLayoutPanel tlpUser, string stt, string tenNguoiDung, string gioiTinh, string email, string soCa)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(TaoLabel(stt, headerFont), 0, currentRow);
            tlpUser.Controls.Add(TaoLabel(tenNguoiDung, headerFont), 1, currentRow);
            tlpUser.Controls.Add(TaoLabel(gioiTinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(TaoLabel(email, headerFont), 3, currentRow);
            tlpUser.Controls.Add(TaoLabel(soCa, headerFont), 4, currentRow); // Thêm CheckBox
            ThemActionButtonsVaoTableLayoutPanel(tlpUser, 5, currentRow);
        }

        private void TaoReceptionTableLayoutPanel()
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
            tlpReception.Controls.Add(TaoLabel("STT", headerFont), 0, 0);
            tlpReception.Controls.Add(TaoLabel("Tên người dùng", headerFont), 1, 0);
            tlpReception.Controls.Add(TaoLabel("Giới tính", headerFont), 2, 0);
            tlpReception.Controls.Add(TaoLabel("Email", headerFont), 3, 0);
            tlpReception.Controls.Add(TaoLabel("Số ca", headerFont), 4, 0);
            tlpReception.Controls.Add(TaoLabel("Thao tác", headerFont), 5, 0);

            // Xóa các control khác
            ClearControlsExcept(tlpReception);

            // Thêm TableLayoutPanel vào form
            panelDuLieu.Controls.Add(tlpReception);

            // Thêm một hàng mẫu
            ThemHangVaoReceptionTableLayoutPanel(tlpReception, "1", "Nguyễn Văn A", "Nam", "example@example.com", "5");
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

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Lấy nội dung tìm kiếm từ tbTimKiem
            string searchText = tbTimKiem.Text.ToLower();

            DateTime selectedDate = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime lastDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month));

            // Lấy danh sách bác sĩ từ doctorBUS
            var lichLamViecBacSi = lichLamViecBUS.DanhSachLichLamViecBacSi(firstDayOfMonth, lastDayOfMonth);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Nếu ô tìm kiếm trống, không tạo bảng mới
                return;
            }

            // Lọc danh sách theo họ tên
            var filteredList = lichLamViecBacSi
                .Where(d => d.HoTen.ToLower().Contains(searchText))
                .ToList();
            if (filteredList.Any())
            {
                TaoDoctorTableLayoutPanel(filteredList);
            }
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            HienThiBacSi();
        }

        //Kết thúc

        //Phần điều hướng
        public void HienThiChinhSuaLichLamViec(int id)
        {
            FormChinhSuaLichLamViec editWorkSchedulForm = new FormChinhSuaLichLamViec(_mainForm, id, dtpNgay.Value);
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