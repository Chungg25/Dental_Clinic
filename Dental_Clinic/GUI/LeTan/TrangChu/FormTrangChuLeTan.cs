using Dental_Clinic.BUS.Admin;
using Dental_Clinic.BUS.LeTan;
using Dental_Clinic.BUS.Patient;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LichHen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.LeTan
{
    public partial class FormTrangChuLeTan : Form
    {
        private LeTanBUS _leTanBUS;
        private string NgayHienTai;
        private enum DanhSachDangHienThi { BacSi, LichHen }
        private DanhSachDangHienThi danhSachHienTai;    

        public FormTrangChuLeTan()
        {
            InitializeComponent();

            this._leTanBUS = new LeTanBUS();
            this.NgayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
        }
        private void FormTrangChuLeTan_Load(object sender, EventArgs e)
        {
            DinhDangVBButton(vbBacSi);
            DinhDangVBButton(vbLichHen);
            DinhDangVBButton(vbThemLichHen);

            vbTimKiem.BorderSize = 1;
            vbTimKiem.BorderColor = Color.Black;
            vbTimKiem.FlatAppearance.MouseOverBackColor = vbTimKiem.BackColor;
            vbTimKiem.FlatAppearance.MouseDownBackColor = vbTimKiem.BackColor;

            tbTimKiem.Font = new Font("Segoe UI", 12F);
            tbTimKiem.Text = "Tìm kiếm";
            tbTimKiem.ForeColor = Color.Gray;
            tbTimKiem.Enter += tbTimKiem_Enter;
            tbTimKiem.Leave += tbTimKiem_Leave;

            // Ngày hiện tại
            dateTimePicker.Value = DateTime.Now;

            HienThiDanhSachBacSi();
        }
        // Xử lý sự kiện click vào button Tìm kiếm
        private void tbTimKiem_Enter(object? sender, EventArgs e)
        {
            if (tbTimKiem.Text == "Tìm kiếm")
            {
                tbTimKiem.Text = "";
                tbTimKiem.ForeColor = Color.Black;
            }
        }
        // Xử lý sự kiện bỏ click ra khỏi textbox Tìm kiếm
        private void tbTimKiem_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTimKiem.Text))
            {
                tbTimKiem.Text = "Tìm kiếm";
                tbTimKiem.ForeColor = Color.Gray;
            }
        }
        // Xử lý sự kiện thay đổi nội dung trong textbox Tìm kiếm
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();
            if (danhSachHienTai == DanhSachDangHienThi.BacSi)
            {
                TimKiemBacSi(keyword);
            }
            else if (danhSachHienTai == DanhSachDangHienThi.LichHen)
            {
                TimKiemLichHen(keyword);
            }
        }
        // Tìm kiếm cho Bác Sĩ
        private void TimKiemBacSi(string keyword)
        {
            var dsBacSi = _leTanBUS.LayThongTinBacSiTrongNgay(NgayHienTai);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                dsBacSi = dsBacSi.Where(bacSi => bacSi.HoVaTen.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            HienThiDanhSachBacSi(dsBacSi);
        }
        // Tìm kiếm cho Lịch Hẹn
        private void TimKiemLichHen(string keyword)
        {
            var dsLichHen = _leTanBUS.LayDanhSachLichHenTheoNgay(NgayHienTai);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                dsLichHen = dsLichHen.Where(lichHen => lichHen.TenBenhNhan.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            HienThiDanhSachLichHen(dsLichHen);
        }
        // Xử lý sự kiện chọn ngày trên DateTimePicker
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.NgayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
            // Tải lại trang hiện tại
            if (danhSachHienTai == DanhSachDangHienThi.BacSi)
            {
                HienThiDanhSachBacSi();
            }
            else if (danhSachHienTai == DanhSachDangHienThi.LichHen)
            {
                HienThiDanhSachLichHen();
            }
        }
        // Định dạng VB Button
        private void DinhDangVBButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;
        }
        // --------------------------------- HÀM HỖ TRỢ ---------------------------------
        // Hàm hỗ trợ thêm tiêu đề cột
        private void AddHeaderLabel(TableLayoutPanel panel, string text, int columnIndex)
        {
            Label header = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 122, 204), // Màu xanh dương làm nền cho tiêu đề
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(header, columnIndex, 0);
        }

        // Hàm hỗ trợ thêm dữ liệu vào bảng
        private void AddDataLabel(TableLayoutPanel panel, string text, int columnIndex, int rowIndex)
        {
            Label dataLabel = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 12),
                BackColor = (rowIndex % 2 == 0) ? Color.LightGray : Color.White, // Làm nổi bật hàng chẵn
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            panel.Controls.Add(dataLabel, columnIndex, rowIndex);
        }

        // ----------------------- BÁC SĨ -----------------------
        // Hiển thị danh sách bác sĩ lên Panel Chính
        private void HienThiDanhSachBacSi(List<BacSiDTO> dsBacSi = null)
        {
            dsBacSi ??= _leTanBUS.LayThongTinBacSiTrongNgay(NgayHienTai);

            // Xóa tất cả các điều khiển cũ trong panel
            pnChinh.Controls.Clear();

            // Tạo một TableLayoutPanel và cấu hình nó
            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                AutoSize = true,  // Tự động thay đổi kích thước theo nội dung
                ColumnCount = 6,  // STT, Tên Bác Sĩ, Chuyên Ngành, Ca, Số Lượng Bệnh Nhân, Trạng Thái Làm Việc
                Dock = DockStyle.Top,  // Đặt lên trên cùng của Panel
                Cursor = Cursors.Default,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt tỷ lệ chiều rộng cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // STT
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));    // Tên Bác Sĩ
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));    // Chuyên Ngành
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));   // Ca
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));  // Số Lượng Bệnh Nhân
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280));  // Trạng Thái Làm Việc

            // Thêm tiêu đề cột
            AddHeaderLabel(tablePanel, "STT", 0);
            AddHeaderLabel(tablePanel, "Tên bác sĩ", 1);
            AddHeaderLabel(tablePanel, "Chuyên ngành", 2);
            AddHeaderLabel(tablePanel, "Ca làm việc", 3);
            AddHeaderLabel(tablePanel, "Bệnh nhân", 4);
            AddHeaderLabel(tablePanel, "Trạng thái làm việc", 5);

            // Cấu hình chiều cao của hàng tiêu đề
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Chiều cao hàng tiêu đề

            // Thêm các hàng dữ liệu và tạo khoảng cách
            for (int i = 0; i < dsBacSi.Count; i++)
            {
                // Thêm chiều cao của mỗi hàng dữ liệu, tạo khoảng cách giữa các hàng
                tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Thêm dữ liệu vào các cột
                AddDataLabel(tablePanel, (i + 1).ToString(), 0, i + 1);
                AddDataLabel(tablePanel, dsBacSi[i].HoVaTen, 1, i + 1);
                AddDataLabel(tablePanel, dsBacSi[i].ChuyenNganh, 2, i + 1);
                AddDataLabel(tablePanel, dsBacSi[i].Ca.ToString(), 3, i + 1);
                AddDataLabel(tablePanel, dsBacSi[i].SoLuongBenhNhan.ToString(), 4, i + 1);
                AddDataLabel(tablePanel, dsBacSi[i].TrangThaiLamViec, 5, i + 1);
            }

            // Thêm TableLayoutPanel vào Panel chính
            pnChinh.Controls.Add(tablePanel);
        }
        // Sự kiện click vào button Bác Sĩ
        public void vbBacSi_Click(object sender, EventArgs e)
        {
            danhSachHienTai = DanhSachDangHienThi.BacSi;
            HienThiDanhSachBacSi();
        }

        // ----------------------- LỊCH HẸN -----------------------
        // Hiển thị danh sách lịch hẹn trong ngày
        private void HienThiDanhSachLichHen(List<LichHenDTO> dsLichHen = null)
        {
            // Lấy danh sách lịch hẹn trong ngày
            dsLichHen ??= _leTanBUS.LayDanhSachLichHenTheoNgay(NgayHienTai);

            // Xóa tất cả các điều khiển cũ trong panel
            pnChinh.Controls.Clear();

            // Tạo một TableLayoutPanel và cấu hình nó
            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                AutoSize = true,  // Tự động thay đổi kích thước theo nội dung
                ColumnCount = 8,  // Thêm cột Chỉnh sửa
                Dock = DockStyle.Top,  // Đặt lên trên cùng của Panel   
                Cursor = Cursors.Default,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt tỷ lệ chiều rộng cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // STT
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Tên Bệnh Nhân
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Số Điện Thoại
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Tên Bác Sĩ
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));  // Ca
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));  // Ghi Chú
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));  // Trạng Thái
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));  // Chỉnh sửa

            // Thêm tiêu đề cột
            AddHeaderLabel(tablePanel, "STT", 0);
            AddHeaderLabel(tablePanel, "Tên bệnh nhân", 1);
            AddHeaderLabel(tablePanel, "Số điện thoại", 2);
            AddHeaderLabel(tablePanel, "Tên bác sĩ", 3);
            AddHeaderLabel(tablePanel, "Ca", 4);
            AddHeaderLabel(tablePanel, "Ghi chú", 5);
            AddHeaderLabel(tablePanel, "Trạng thái", 6);
            AddHeaderLabel(tablePanel, "", 7);

            // Cấu hình chiều cao của hàng tiêu đề
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Chiều cao hàng tiêu đề

            // Thêm các hàng dữ liệu và tạo khoảng cách
            for (int i = 0; i < dsLichHen.Count; i++)
            {
                // Thêm chiều cao của mỗi hàng dữ liệu, tạo khoảng cách giữa các hàng
                tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Thêm dữ liệu vào các cột
                AddDataLabel(tablePanel, (i + 1).ToString(), 0, i + 1);
                AddDataLabel(tablePanel, dsLichHen[i].TenBenhNhan, 1, i + 1);
                AddDataLabel(tablePanel, dsLichHen[i].SoDienThoai, 2, i + 1);
                AddDataLabel(tablePanel, dsLichHen[i].TenBacSi, 3, i + 1);
                AddDataLabel(tablePanel, dsLichHen[i].Ca.ToString(), 4, i + 1);
                AddDataLabel(tablePanel, dsLichHen[i].GhiChu, 5, i + 1); // Ghi chú
                AddDataLabel(tablePanel, dsLichHen[i].TrangThai, 6, i + 1); // Trạng thái

                // Tạo nút chỉnh sửa và thêm vào cột cuối cùng
                PictureBox editPictureBox = new PictureBox
                {
                    Image = Properties.Resources.icons8_edit_64,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    // Căn giữa hình ảnh trong PictureBox
                    Anchor = AnchorStyles.None,
                    Cursor = Cursors.Hand,
                    Tag = dsLichHen[i] // Sử dụng Tag để lưu đối tượng LichHenDTO tương ứng
                };
                editPictureBox.Click += EditPictureBox_Click; // Gắn sự kiện click cho PictureBox
                tablePanel.Controls.Add(editPictureBox, 7, i + 1);
            }

            // Thêm TableLayoutPanel vào Panel chính
            pnChinh.Controls.Add(tablePanel);
        }

        // Hàm sự kiện khi bấm vào biểu tượng chỉnh sửa
        private void EditPictureBox_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is LichHenDTO lichHen)
            {
                var thongTinBenhNhan = _leTanBUS.LayThongTinBenhNhanVaBenhAnTheoMa(lichHen.MaBenhNhan);
                HienThiForm(new FormChinhSuaThongTinBenhNhan(this, thongTinBenhNhan));
            }
        }

        // Sự kiện click vào button Lịch Hẹn
        public void vbLichHen_Click(object sender, EventArgs e)
        {
            danhSachHienTai = DanhSachDangHienThi.LichHen;
            HienThiDanhSachLichHen();
        }
        // Sự kiện click vào button Thêm Lịch Hẹn
        private void vbThemLichHen_Click(object sender, EventArgs e)
        {
            var dsBacSi = _leTanBUS.LayThongTinBacSiTrongNgay(NgayHienTai);

            // Chỉ lấy những bác sĩ trạng thái làm việc là "Đủ điều kiện"
            dsBacSi = dsBacSi.Where(bacSi => bacSi.TrangThaiLamViec == "Đủ điều kiện").ToList();

            HienThiForm(new FormThemLichHen(this, dsBacSi, NgayHienTai));
        }
        // Hiển thị form lên Panel Chính
        private void HienThiForm(Form form)
        {
            form.TopLevel = false;
            form.AutoScroll = true;
            pnChinh.Controls.Clear();
            pnChinh.Controls.Add(form);
            form.Show();
        }
    }
}