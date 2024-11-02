using Dental_Clinic.BUS.LeTan;
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
        public FormTrangChuLeTan()
        {
            InitializeComponent();
            this._leTanBUS = new LeTanBUS();
            this.NgayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
        }
        private void FormTrangChuLeTan_Load(object sender, EventArgs e)
        {
            LayDanhSachLichHenTheoNgay();
        }
        // Xử lý sự kiện chọn ngày trên DateTimePicker
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.NgayHienTai = dateTimePicker.Value.ToString("yyyy-MM-dd");
        }
        // Lấy danh sách lịch hẹn theo ngày
        private void LayDanhSachLichHenTheoNgay()
        {
            // Lấy danh sách lịch hẹn theo ngày
            var DanhSachLichHen = _leTanBUS.LayDanhSachLichHenTheoNgay("2024-10-25");

            MessageBox.Show(DanhSachLichHen.Count.ToString());

            // Hiển thị danh sách lịch hẹn lên GirdHienThiDanhSach
            GirdHienThiDanhSach.DataSource = DanhSachLichHen;
            GirdHienThiDanhSach.Refresh();
            // Chỉnh sửa lại tên header của các cột chỉ hiển thị Tên bệnh nhân, Số điện thoại, Địa chỉ, Giới tính, Tuổi, Tên bác sĩ, Trạng thái, Ghi chú
            GirdHienThiDanhSach.Columns["TenBenhNhan"].HeaderText = "Tên bệnh nhân";
            GirdHienThiDanhSach.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            GirdHienThiDanhSach.Columns["DiaChi"].HeaderText = "Địa chỉ";
            GirdHienThiDanhSach.Columns["GioiTinh"].HeaderText = "Giới tính";
            GirdHienThiDanhSach.Columns["Tuoi"].HeaderText = "Tuổi";
            GirdHienThiDanhSach.Columns["TenBacSi"].HeaderText = "Tên bác sĩ";
            GirdHienThiDanhSach.Columns["TrangThai"].HeaderText = "Trạng thái";
            GirdHienThiDanhSach.Columns["GhiChu"].HeaderText = "Ghi chú";

            // Ẩn các cột không cần thiết
            GirdHienThiDanhSach.Columns["MaLichHen"].Visible = false;
            GirdHienThiDanhSach.Columns["MaBenhNhan"].Visible = false;
            GirdHienThiDanhSach.Columns["MaBacSi"].Visible = false;

        }
    }
}
