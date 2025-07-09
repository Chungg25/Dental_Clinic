using Dental_Clinic.GUI.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental_Clinic.GUI.BacSi;
using Dental_Clinic.BUS.Patient;
using CustomButton;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.GUI.Administrator.Patient;
using Dental_Clinic.GUI.Receptionist;
using System.Globalization;
using Dental_Clinic.BUS.LeTan;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.GUI.LeTan;
using Dental_Clinic.BUS.BacSi;
using System.Diagnostics;
using Dental_Clinic.GUI.BacSi.TrangChu;

namespace Dental_Clinic.GUI.BacSi.BenhNhan
{
    public partial class FormTrangChuBacSi : Form
    {
        private FormBacSi _formBacSi;
        private BacSiBUS bacSiBUS;
        private List<BenhNhanDTO> benhNhan;

        private string ngayHienTai;
        private enum DanhSachDangHienThi { BenhNhan }
        private DanhSachDangHienThi danhSachHienTai;
        public FormTrangChuBacSi(FormBacSi formBacSi)
        {
            InitializeComponent();
            this._formBacSi = formBacSi;
            this.bacSiBUS = new BacSiBUS();
            this.benhNhan = new List<BenhNhanDTO>();
            this.benhNhan = new List<BenhNhanDTO>();
            this.ngayHienTai = string.Empty;
        }
        // Hàm khởi tạo nội dung
        private void FormTrangChuBacSi_Load(object sender, EventArgs e)
        {
            DinhDangVBButton(vbBenhNhan);

            vbTimKiem.BorderSize = 1;
            vbTimKiem.BorderColor = Color.Black;
            vbTimKiem.FlatAppearance.MouseOverBackColor = vbTimKiem.BackColor;
            vbTimKiem.FlatAppearance.MouseDownBackColor = vbTimKiem.BackColor;

            tbTimKiem.Font = new Font("Segoe UI", 12F);
            tbTimKiem.Text = "Tìm kiếm";
            tbTimKiem.ForeColor = Color.Gray;
            tbTimKiem.Enter += tbTimKiem_Enter;
            tbTimKiem.Leave += tbTimKiem_Leave;

            dateTimePicker.Value = DateTime.Now;
            this.ngayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");

            HienThiDanhSachBenhNhan();
        }
        // Định dạng VB Button
        private void DinhDangVBButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;
        }
        // Tìm kiếm
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
            string keyword = tbTimKiem.Text;
            if (danhSachHienTai == DanhSachDangHienThi.BenhNhan)
            {
                TimKiemBacSi(keyword);
            }
        }
        // Tìm kiếm cho Bác Sĩ
        private void TimKiemBacSi(string keyword)
        {
            var dsBenhNhan = bacSiBUS.LayDanhSachBenhNhanCuaBacSi(_formBacSi.MaBacSi(), ngayHienTai);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                dsBenhNhan = dsBenhNhan.Where(benhNhan => benhNhan.HoVaTen.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            HienThiDanhSachBenhNhan(dsBenhNhan);
        }

        // --------------------------------- HÀM HỖ TRỢ ---------------------------------
        // Hàm hỗ trợ thêm tiêu đề cột
        private void AddHeaderLabel(TableLayoutPanel panel, string text, int columnIndex)
        {
            Label header = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
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
                Font = new Font("Segoe UI", 10),
                BackColor = (rowIndex % 2 == 0) ? Color.LightGray : Color.White, // Làm nổi bật hàng chẵn
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            panel.Controls.Add(dataLabel, columnIndex, rowIndex);
        }
        // Hiển thị danh sách bác sĩ lên Panel Chính
        public void HienThiDanhSachBenhNhan(List<BenhNhanDTO> dsBenhNhan = null)
        {
            if (dsBenhNhan == null)
            {
                dsBenhNhan = bacSiBUS.LayDanhSachBenhNhanCuaBacSi(_formBacSi.MaBacSi(), ngayHienTai);
            }

            // Xóa tất cả các điều khiển cũ trong panel
            pnChinh.Controls.Clear();

            // Tạo một TableLayoutPanel và cấu hình nó
            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                AutoSize = true,  // Tự động thay đổi kích thước theo nội dung
                ColumnCount = 7,
                Dock = DockStyle.Top,  // Đặt lên trên cùng của Panel
                Cursor = Cursors.Default,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt tỷ lệ chiều rộng cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // STT
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));    // Tên bệnh nhân
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));    // Số điện thoại
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));    // Giới tính
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));    // Tuổi
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));    // Trạng thái
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Nút xem chi tiết

            // Thêm tiêu đề cột
            AddHeaderLabel(tablePanel, "STT", 0);
            AddHeaderLabel(tablePanel, "Tên Bệnh Nhân", 1);
            AddHeaderLabel(tablePanel, "Số Điện Thoại", 2);
            AddHeaderLabel(tablePanel, "Giới Tính", 3);
            AddHeaderLabel(tablePanel, "Tuổi", 4);
            AddHeaderLabel(tablePanel, "Trạng Thái", 5);
            AddHeaderLabel(tablePanel, "", 6);

            // Cấu hình chiều cao của hàng tiêu đề
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Chiều cao hàng tiêu đề

            // Thêm các hàng dữ liệu và tạo khoảng cách
            for (int i = 0; i < dsBenhNhan.Count; i++)
            {
                // Thêm chiều cao của mỗi hàng dữ liệu, tạo khoảng cách giữa các hàng
                tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Thêm dữ liệu vào các cột
                AddDataLabel(tablePanel, (i + 1).ToString(), 0, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].HoVaTen, 1, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].SDT, 2, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].GioiTinh ? "Nam" : "Nữ", 3, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].Tuoi.ToString(), 4, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].TrangThaiKham, 5, i + 1);

                // Tạo nút xem chi tiết
                PictureBox infoPictureBox = new PictureBox
                {
                    Image = Properties.Resources.icons8_edit_64,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    // Căn giữa hình ảnh trong PictureBox
                    Anchor = AnchorStyles.None,
                    Cursor = Cursors.Hand,
                    Tag = dsBenhNhan[i] // Sử dụng Tag để lưu đối tượng LichHenDTO tương ứng
                };
                infoPictureBox.Click += InfoPictureBox_Click; // Gắn sự kiện click cho PictureBox
                tablePanel.Controls.Add(infoPictureBox, 6, i + 1);
            }

            // Thêm TableLayoutPanel vào Panel chính
            pnChinh.Controls.Add(tablePanel);
        }
        // Hàm sự kiện khi bấm vào biểu tượng chỉnh sửa
        private void InfoPictureBox_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is BenhNhanDTO benhNhan)
            {
                HienThiForm(new FormThemHoSoBenhAn(this, benhNhan, _formBacSi.MaBacSi()));
            }
        }
        // Hiển thị form lên Panel Chính
        public void HienThiForm(Form form)
        {
            form.TopLevel = false;
            form.AutoScroll = true;
            pnChinh.Controls.Clear();
            pnChinh.Controls.Add(form);
            form.Show();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.ngayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
            HienThiDanhSachBenhNhan();
        }

        private void vbBenhNhan_Click(object sender, EventArgs e)
        {
            HienThiDanhSachBenhNhan();
        }
    }
}
