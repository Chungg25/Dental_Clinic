using CustomButton;
using Dental_Clinic.BUS.LichLamViec;
using Dental_Clinic.BUS.Luong;
using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.LichLamViec;
using Dental_Clinic.DTO.Luong;
using Dental_Clinic.GUI.QuanTriVien.Luong;
using Dental_Clinic.GUI.QuanTriVien.VatTu;
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
    public partial class FormQuanLyLuong : Form
    {
        private TableLayoutPanel tlpData;
        private MainForm mainForm;
        private LuongBUS luongBUS;
        public FormQuanLyLuong(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            luongBUS = new LuongBUS();
            HienThiLuongBacSi();

            //dtpNgay.Format = DateTimePickerFormat.Custom;
            //dtpNgay.CustomFormat = "MMMM yyyy";  // Hiển thị tháng và năm
            //dtpNgay.AutoSize = false;            // Tắt AutoSize để có thể thay đổi kích thước
            //dtpNgay.Size = new Size(160, 30);

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
        private Label TaoLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                AutoSize = true,
                Padding = new Padding(5, 5, 5, 5), // Tăng khoảng cách bên trái và bên phải
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
        }

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
        private void ThemActionButtonsVaoTableLayoutPanel(TableLayoutPanel tlpUser, int rowIndex, int id, Action<int> a)
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
            btnEdit.Click += (s, e) => { a(id); };

            // Tạo một Panel để chứa 2 nút
            FlowLayoutPanel panelActions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(35, 0, 0, 0),
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
        private void ThemHangVaoTableLayoutPanel(TableLayoutPanel tlpUser, string tenNguoiDung, string tenChuyenNganh, string luongCoDinh, string heSoLuong, string soCa, string tongLuong, int id)
        {
            int currentRow = tlpUser.RowCount++; // Tăng số lượng hàng
            Action<int> a = HienThiChiTietLuongBacSi;
            if (string.IsNullOrWhiteSpace(tenChuyenNganh))
            {
                tenChuyenNganh = "Lễ tân";
                a = HienThiChiTietLuongLeTan;
            }

            Font headerFont = new Font("Segoe UI", 10);
            tlpUser.Controls.Add(TaoLabel(tenNguoiDung, headerFont), 0, currentRow);
            tlpUser.Controls.Add(TaoLabel(tenChuyenNganh, headerFont), 1, currentRow);
            tlpUser.Controls.Add(TaoLabel(luongCoDinh, headerFont), 2, currentRow);
            tlpUser.Controls.Add(TaoLabel(heSoLuong, headerFont), 3, currentRow);
            tlpUser.Controls.Add(TaoLabel(soCa, headerFont), 4, currentRow);
            tlpUser.Controls.Add(TaoLabel(tongLuong, headerFont), 5, currentRow); // Thêm CheckBox
            ThemActionButtonsVaoTableLayoutPanel(tlpUser, currentRow, id, a);
        }

        // Hàm tạo TableLayoutPanel và gọi hàm AddRowToTableLayoutPanel để thêm dữ liệu
        private void TaoTableLayoutPanel(List<LuongDTO> luongs, string tenPanel)
        {
            if (panelDuLieu.Controls.Count > 0)
            {
                // Xóa các control trong panelBacSi, bao gồm TableLayoutPanel cũ
                panelDuLieu.Controls.Clear();
            }
            // Tạo TableLayoutPanel
            TableLayoutPanel tlpData = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            // Thiết lập số cột
            tlpData.ColumnCount = 7;
            tlpData.SuspendLayout();
            for (int i = 0; i < tlpData.ColumnCount; i++)
            {
                tlpData.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Thiết lập số hàng và thêm các Label tiêu đề vào hàng đầu tiên
            tlpData.RowCount = 1;
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            tlpData.Controls.Add(TaoLabel("Tên người dùng", headerFont), 0, 0);
            tlpData.Controls.Add(TaoLabel("Chức vụ", headerFont), 1, 0);
            tlpData.Controls.Add(TaoLabel("Lương cố định", headerFont), 2, 0);
            tlpData.Controls.Add(TaoLabel("Hệ số", headerFont), 3, 0);
            tlpData.Controls.Add(TaoLabel("Số ca", headerFont), 4, 0);
            tlpData.Controls.Add(TaoLabel("Tổng lương", headerFont), 5, 0);
            tlpData.Controls.Add(TaoLabel("Thao tác", headerFont), 6, 0);

            // Tô màu cho hàng tiêu đề
            foreach (Control control in tlpData.Controls)
            {
                control.BackColor = ColorTranslator.FromHtml("#0d6efd");
                control.ForeColor = Color.White;
            }

            // Thêm TableLayoutPanel vào form
            ClearControlsExcept(tlpData);
            Panel scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            scrollablePanel.Controls.Add(tlpData);

            scrollablePanel.Name = tenPanel;
            panelDuLieu.Controls.Add(scrollablePanel);

            int sequenceNumber = 1;
            if (luongs.Count == 0)
            {
                tlpData.Controls.Clear();

                Label lblThongBao = new Label
                {
                    Text = "Tháng hiện tại chưa có tổng lương, bạn vui lòng lui về tháng trước",
                    AutoSize = false,           // Cho phép tùy chỉnh kích thước
                    TextAlign = ContentAlignment.MiddleCenter, // Căn giữa nội dung
                    Dock = DockStyle.Fill,       // Cho label chiếm toàn bộ ô trong TableLayoutPanel
                    Font = new Font("Segoe UI", 10, FontStyle.Bold) // Tăng kích thước và làm đậm chữ
                };

                tlpData.Controls.Add(lblThongBao, 0, 0); // (column, row)

                tlpData.SetColumnSpan(lblThongBao, tlpData.ColumnCount);
                tlpData.SetRowSpan(lblThongBao, tlpData.RowCount);
            }
            else
            {
                foreach (var luong in luongs)
                {
                    string genderText = luong.GioiTinh ? "Nam" : "Nữ";
                    string tongLuong = (luong.SoCa * luong.LuongCoBan * luong.HeSoLuong + (luong.PhuCap + luong.Thuong - luong.Phat)).ToString();
                    ThemHangVaoTableLayoutPanel(tlpData, luong.Ten, luong.TenChuyenNganh, luong.LuongCoBan.ToString(), luong.HeSoLuong.ToString(), luong.SoCa.ToString(), tongLuong, luong.Id);
                }

            }

            tlpData.ResumeLayout();
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
        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            if (panelDuLieu.Controls[0].Name == "Bác sĩ")
            {
                HienThiLuongBacSi();
            }
            else if (panelDuLieu.Controls[0].Name == "Lễ tân")
            {
                HienThiLuongLeTan();
            };
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {

            // Lấy nội dung tìm kiếm từ tbTimKiem
            string searchText = tbTimKiem.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                if (panelDuLieu.Controls[0].Name == "Bác sĩ")
                {
                    HienThiLuongBacSi();
                }
                else if (panelDuLieu.Controls[0].Name == "Lễ tân")
                {
                    HienThiLuongLeTan();
                };
            }

            DateTime lastMonth = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var luong = luongBUS.DanhSachLuongBacSi(firstDayOfMonth, lastDayOfMonth);
            if (panelDuLieu.Controls[0].Name == "Lễ tân")
            {
                luong = luongBUS.DanhSachLuongLeTan(firstDayOfMonth, lastDayOfMonth);
            }

            // Lọc danh sách theo họ tên
            var filteredList = luong
                .Where(d => d.Ten.ToLower().Contains(searchText))
                .ToList();
            if (filteredList.Any())
            {
                if (panelDuLieu.Controls[0].Name == "Bác sĩ")
                {
                    TaoTableLayoutPanel(filteredList, "Bác sĩ");
                }
                else if (panelDuLieu.Controls[0].Name == "Lễ tân")
                {
                    TaoTableLayoutPanel(filteredList, "Lễ tân");
                }
            }
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
            HienThiLuongBacSi();
        }

        public void HienThiLuongBacSi()
        {
            DateTime lastMonth = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            List<LuongDTO> luongBacSi = luongBUS.DanhSachLuongBacSi(firstDayOfMonth, lastDayOfMonth);
            TaoTableLayoutPanel(luongBacSi, "Bác sĩ");
        }

        private void vbLeTan_Click(object sender, EventArgs e)
        {
            HienThiLuongLeTan();
        }

        public void HienThiLuongLeTan()
        {
            DateTime lastMonth = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            List<LuongDTO> luongBacSi = luongBUS.DanhSachLuongLeTan(firstDayOfMonth, lastDayOfMonth);
            TaoTableLayoutPanel(luongBacSi, "Lễ tân");
        }

        private void HienThiChiTietLuongBacSi(int id)
        {
            DateTime lastMonth = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            LuongDTO luongBacSi = luongBUS.LuongBacSi(id, firstDayOfMonth, lastDayOfMonth);

            FormChiTietLuongBacSi formChiTietLuongBacSi = new FormChiTietLuongBacSi(mainForm, luongBacSi);
            formChiTietLuongBacSi.TopLevel = false;
            formChiTietLuongBacSi.FormBorderStyle = FormBorderStyle.None;
            formChiTietLuongBacSi.Dock = DockStyle.Fill;
            mainForm.panelTrangChu.Controls.Add(formChiTietLuongBacSi);
            formChiTietLuongBacSi.BringToFront();
            formChiTietLuongBacSi.Show();
        }

        private void HienThiChiTietLuongLeTan(int id)
        {
            DateTime lastMonth = dtpNgay.Value;
            DateTime firstDayOfMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            LuongDTO luongLeTan = luongBUS.LuongLeTan(id, firstDayOfMonth, lastDayOfMonth);
            FormChiTietLuongLeTan formChiTietLuongLeTan = new FormChiTietLuongLeTan(mainForm, luongLeTan);
            formChiTietLuongLeTan.TopLevel = false;
            formChiTietLuongLeTan.FormBorderStyle = FormBorderStyle.None;
            formChiTietLuongLeTan.Dock = DockStyle.Fill;
            mainForm.panelTrangChu.Controls.Add(formChiTietLuongLeTan);
            formChiTietLuongLeTan.BringToFront();
            formChiTietLuongLeTan.Show();
        }

        private void FormQuanLyLuong_Load(object sender, EventArgs e)
        {

        }

        //Kết thúc
    }
}
