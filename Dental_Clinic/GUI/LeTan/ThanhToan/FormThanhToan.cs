using Dental_Clinic.BUS.LeTan;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    public partial class FormThanhToan : Form
    {
        private LeTanBUS leTanBUS;
        private string ngayHienTai;
        public FormThanhToan()
        {
            InitializeComponent();
            this.leTanBUS = new LeTanBUS();
            this.ngayHienTai = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            // Ngày hiện tại
            dateTimePicker.Value = DateTime.Now;

            HienThiDanhSachBenhNhanChuaThanhToan();
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

        // Định dạng VB Button
        private void DinhDangVBButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;
        }
        // --------------------------------- HÀM HỖ TRỢ ---------------------------------
        // Hiển thị form lên Panel Chính
        private void HienThiForm(Form form)
        {
            form.TopLevel = false;
            form.AutoScroll = true;
            pnChinh.Controls.Clear();
            pnChinh.Controls.Add(form);
            form.Show();
        }
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
        // ----------------------- THANH TOÁN -----------------------
        // Hiển thị danh sách bệnh nhân cần thanh toán trong ngày
        public void HienThiDanhSachBenhNhanChuaThanhToan(List<BenhNhanDTO> dsBenhNhan = null)
        {
            // Lấy danh sách lịch hẹn trong ngày
            dsBenhNhan ??= leTanBUS.LayDanhSachBenhNhanChuaThanhToan(ngayHienTai);

            // Xóa tất cả các điều khiển cũ trong panel
            pnChinh.Controls.Clear();

            // Tạo một TableLayoutPanel và cấu hình nó
            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                AutoSize = true,  // Tự động thay đổi kích thước theo nội dung
                ColumnCount = 7,  // Thêm cột Chỉnh sửa
                Dock = DockStyle.Top,  // Đặt lên trên cùng của Panel   
                Cursor = Cursors.Default,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt tỷ lệ chiều rộng cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // STT
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Tên Bệnh Nhân
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Số Điện Thoại
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Tên Bác Sĩ
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));  // Trạng thái khám
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));  // Trạng thái thanh toán
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));  // Thanh toán

            // Thêm tiêu đề cột
            AddHeaderLabel(tablePanel, "STT", 0);
            AddHeaderLabel(tablePanel, "Tên bệnh nhân", 1);
            AddHeaderLabel(tablePanel, "Số điện thoại", 2);
            AddHeaderLabel(tablePanel, "Tên bác sĩ", 3);
            AddHeaderLabel(tablePanel, "Trạng thái khám", 4);
            AddHeaderLabel(tablePanel, "Trạng thái thanh toán", 5);
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
                AddDataLabel(tablePanel, dsBenhNhan[i].TenBacSi, 3, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].TrangThaiKham, 4, i + 1);
                AddDataLabel(tablePanel, dsBenhNhan[i].TrangThaiThanhToan, 5, i + 1);


                // Tạo nút chỉnh sửa và thêm vào cột cuối cùng
                PictureBox thanhToanPictureBox = new PictureBox
                {
                    Image = Resources.icons8_money_transfer_96,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    // Căn giữa hình ảnh trong PictureBox
                    Anchor = AnchorStyles.None,
                    Cursor = Cursors.Hand,
                    Tag = dsBenhNhan[i] //
                };
                // Sự kiện khi bấm vào biểu thanh toán kèm theo mã bệnh nhân
                thanhToanPictureBox.Click += ThanhToanPictureBox_Click;
                tablePanel.Controls.Add(thanhToanPictureBox, 7, i + 1);
            }

            // Thêm TableLayoutPanel vào Panel chính
            pnChinh.Controls.Add(tablePanel);
        }

        // Hàm sự kiện khi bấm vào biểu tượng chỉnh sửa của bệnh nhân kèm theo mã bệnh nhân
        private void ThanhToanPictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is BenhNhanDTO benhNhan)
            {
                FormChiTietHoaDon formChiTietHoaDon = new FormChiTietHoaDon(this, benhNhan.Id, benhNhan.MaHoaDon, ngayHienTai);
                HienThiForm(formChiTietHoaDon);
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ngayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
            HienThiDanhSachBenhNhanChuaThanhToan();
        }
    }
}
