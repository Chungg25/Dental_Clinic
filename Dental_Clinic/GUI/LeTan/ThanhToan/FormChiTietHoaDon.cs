using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dental_Clinic.BUS.LeTan;
using Dental_Clinic.Properties;
using Dental_Clinic.DTO.HoaDon;

namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    public partial class FormChiTietHoaDon : Form
    {
        private FormThanhToan formThanhToan;
        private int maBenhNhan;
        private int maHoaDon;
        private string ngayHienTai;
        private LeTanBUS leTanBUS;
        private float tongTien = 0;
        private bool thanhToanThanhCong = false;

        public FormChiTietHoaDon(FormThanhToan formThanhToan, int maBenhNhan, int maHoaDon, string ngayHienTai)
        {
            InitializeComponent();
            this.formThanhToan = formThanhToan;
            this.maBenhNhan = maBenhNhan;
            this.maHoaDon = maHoaDon;
            this.ngayHienTai = ngayHienTai;
            this.leTanBUS = new LeTanBUS();
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
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

            foreach (Control control in pnTienKhachDua.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in pnTienKhachDua.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in pnTienKhachDua.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            // Cấu hình TableLayoutPanel cho các nhãn thanh toán
            InitializeTableLayoutPanel();
            DinhDangLabel();
            HienThiChiTietHoaDon();

            // Ẩn toàn bộ label Phương thức thanh toán
            pnTienKhachDua.Visible = false;

            // Ẩn tablePanel ban đầu
            tablePanel.Visible = false;
        }
        public void CapNhatThanhToanThanhCong()
        {
            thanhToanThanhCong = true;
            HienThiTablePanel();
            lbPhuongThucThanhToan.Text = "Chuyển khoản";
            // Ẩn lable còn lại
            lbTienDaDua.Visible = false;
            lbTienTraLai.Visible = false;
        }
        private void InitializeTableLayoutPanel()
        {
            // Cấu hình TableLayoutPanel
            tablePanel.ColumnCount = 1;
            tablePanel.RowCount = 3;

            // Đặt tỷ lệ cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Cột cho tên nhãn
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Cột cho giá trị

            // Thêm các Label giá trị vào cột 
            lbPhuongThucThanhToan.TextAlign = ContentAlignment.MiddleRight;
            lbTienDaDua.TextAlign = ContentAlignment.MiddleRight;
            lbTienTraLai.TextAlign = ContentAlignment.MiddleRight;


            // Thêm TableLayoutPanel vào form
            this.Controls.Add(tablePanel);
        }

        // Định dạng các label
        private void DinhDangLabel()
        {
            // Định dạng label tổng tiền và các nhãn khác để căn phải
            lbTongTien.TextAlign = ContentAlignment.MiddleRight;
            lbTongTien.ForeColor = Color.FromArgb(0, 122, 204);

            lbPhuongThucThanhToan.ForeColor = Color.FromArgb(0, 122, 204);
            lbTienDaDua.ForeColor = Color.FromArgb(0, 122, 204);
            lbTienTraLai.ForeColor = Color.FromArgb(0, 122, 204);
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
        private void HienThiTablePanel()
        {
            tablePanel.Visible = true;
        }

        // ----------------------- HOÁ ĐƠN -----------------------
        // Hiển thị chi tiết hóa đơn của bệnh nhân
        public void HienThiChiTietHoaDon(List<HoaDonDTO> dsHoaDon = null)
        {
            // Lấy danh sách lịch hẹn trong ngày
            dsHoaDon ??= leTanBUS.LayChiTietHoaDonBenhNhan(maBenhNhan);

            // Xóa tất cả các điều khiển cũ trong panel
            pnHoaDon.Controls.Clear();

            // Tạo một TableLayoutPanel và cấu hình nó
            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                AutoSize = true,  // Tự động thay đổi kích thước theo nội dung
                ColumnCount = 6,  // Thêm cột Chỉnh sửa
                Dock = DockStyle.Top,  // Đặt lên trên cùng của Panel   
                Cursor = Cursors.Default,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt tỷ lệ chiều rộng cho các cột
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // STT
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));    // Tên loại mục
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));    // Tên mục
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Số lượng
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Đơn giá
            tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));    // Thành tiền

            // Thêm tiêu đề cột
            AddHeaderLabel(tablePanel, "STT", 0);
            AddHeaderLabel(tablePanel, "Loại mục", 1);
            AddHeaderLabel(tablePanel, "Tên mục", 2);
            AddHeaderLabel(tablePanel, "Số lượng", 3);
            AddHeaderLabel(tablePanel, "Đơn giá", 4);
            AddHeaderLabel(tablePanel, "Thành tiền", 5);

            // Cấu hình chiều cao của hàng tiêu đề
            tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // Chiều cao hàng tiêu đề

            // Thêm các hàng dữ liệu và tạo khoảng cách
            for (int i = 0; i < dsHoaDon.Count; i++)
            {
                // Thêm chiều cao của mỗi hàng dữ liệu, tạo khoảng cách giữa các hàng
                tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Thêm dữ liệu vào các cột
                AddDataLabel(tablePanel, (i + 1).ToString(), 0, i + 1);
                AddDataLabel(tablePanel, dsHoaDon[i].LoaiMuc, 1, i + 1);
                AddDataLabel(tablePanel, dsHoaDon[i].TenMuc, 2, i + 1);
                AddDataLabel(tablePanel, dsHoaDon[i].SoLuong.ToString(), 3, i + 1);
                AddDataLabel(tablePanel, dsHoaDon[i].DonGia.ToString("N0") + " VND", 4, i + 1);
                AddDataLabel(tablePanel, dsHoaDon[i].ThanhTien.ToString("N0") + " VND", 5, i + 1);
            }

            // Thêm TableLayoutPanel vào Panel chính
            pnHoaDon.Controls.Add(tablePanel);

            // Tính tổng tiền
            foreach (HoaDonDTO hoaDon in dsHoaDon)
            {
                this.tongTien += hoaDon.ThanhTien;
            }

            // Hiển thị tổng tiền
            lbTongTien.Text = "Tổng tiền: " + this.tongTien.ToString("N0") + " VNĐ";
            lbTongTien.Enabled = false;
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            formThanhToan.HienThiDanhSachBenhNhanChuaThanhToan();
        }

        private void vbXacNhan_Click(object sender, EventArgs e)
        {
            if (tongTien == 0)
            {
                MessageBox.Show("Không thể thanh toán hóa đơn với số tiền bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (thanhToanThanhCong)
            {
                // Thanh toán chuyển khoản
                leTanBUS.CapNhatTrangThaiHoaDon(maHoaDon, 1, tongTien); // Cập nhật trạng thái thanh toán
            }
            else
            {
                // Thanh toán tiền mặt
                leTanBUS.CapNhatTrangThaiHoaDon(maHoaDon, 0, tongTien); // Cập nhật trạng thái thanh toán
            }
            formThanhToan.HienThiDanhSachBenhNhanChuaThanhToan();
        }
        private void vbChuyenKhoan_Click(object sender, EventArgs e)
        {
            tablePanel.Visible = false;
            pnTienKhachDua.Visible = false;
            FormThanhToan_ChuyenKhoan formThanhToan_ChuyenKhoan = new FormThanhToan_ChuyenKhoan(this);
            formThanhToan_ChuyenKhoan.ShowDialog();
        }

        private void vbTienMat_Click(object sender, EventArgs e)
        {
            pnTienKhachDua.Visible = true;
            lbTienDaDua.Visible = true;
            lbTienTraLai.Visible = true;

            // Hiển thị label Phương thức thanh toán
            lbPhuongThucThanhToan.Text = "Tiền mặt";
            lbPhuongThucThanhToan.Visible = true;

            // Huỷ label Phương thức thanh toán nếu chọn lại chuyển khoản
            if (lbPhuongThucThanhToan.Text == "Chuyển khoản")
            {
                lbPhuongThucThanhToan.Visible = false;
            }
        }

        // Xử lý sự kiện khi thay đổi số tiền khách đưa
        private void tbTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!int.TryParse(tbTienKhachDua.Text, out _))
            {
                tbTienKhachDua.Text = "";
            }

            if (tbTienKhachDua.Text != "")
            {
                HienThiTablePanel();
                float tienKhachDua = float.Parse(tbTienKhachDua.Text);
                lbTienDaDua.Text = "Tiền đã đưa: " + tienKhachDua.ToString("N0") + " VNĐ";

                // Tính tiền thừa
                float tienThua = tienKhachDua - tongTien;
                lbTienTraLai.Text = "Tiền trả lại: " + (tienThua > 0 ? tienThua.ToString("N0") : "0") + " VNĐ";
            }
            else
            {
                lbTienDaDua.Text = "Tiền đã đưa: 0 VNĐ";
                lbTienTraLai.Text = "Tiền trả lại: 0 VNĐ";
            }
            // Cập nhật căn phải cho các label liên quan
            DinhDangLabel();
        }

        private void vbXuatHoaDon_Click(object sender, EventArgs e)
        {
            var benhNhan = leTanBUS.LayThongTinBenhNhan(maBenhNhan);
            var dsHoaDon = leTanBUS.LayChiTietHoaDonBenhNhan(maBenhNhan);

            leTanBUS.XuatHoaDonPDF(benhNhan, dsHoaDon);
        }
    }
}
