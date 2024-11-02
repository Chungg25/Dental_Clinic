using Dental_Clinic.BUS.LeTan;
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
    public partial class FormThemLichHen : Form
    {
        private FormTrangChuLeTan formTrangChuLeTan;
        private LeTanBUS leTanBUS;
        private List<BacSiDTO> dsBacSi;
        private string ngayHienTai;
        public FormThemLichHen(FormTrangChuLeTan formTrangChuLeTan, List<BacSiDTO> dsBacSi, string ngayHienTai)
        {
            InitializeComponent();
            this.formTrangChuLeTan = formTrangChuLeTan;
            this.leTanBUS = new LeTanBUS();
            this.dsBacSi = dsBacSi;
            this.ngayHienTai = ngayHienTai;
        }

        private void FormThemLichHen_Load(object sender, EventArgs e)
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
            // Dữ liệu cho combobox giới tính
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.SelectedIndex = 0;

            // Dữ liệu cho combobox bác sĩ
            foreach (BacSiDTO bacSi in dsBacSi)
            {
                cbBacSi.Items.Add(bacSi.HoVaTen);
            }
            cbBacSi.SelectedIndex = 0;

            // Chỉ được đọc và chọn đối với các combobox
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBacSi.DropDownStyle = ComboBoxStyle.DropDownList;

            // Chỉ được đọc và không được chỉnh sửa đối với textbox ca làm
            tbHoTen.Focus();
        }
        // Thêm lịch hẹn
        private void cbBacSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCaLam.Text = dsBacSi[cbBacSi.SelectedIndex].Ca.ToString();
        }
        // Kiểm tra thông tin trước khi thêm
        public bool KiemTraThem()
        {
            bool isValid = true;

            // Họ tên
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                vbHoTen.BorderColor = Color.Red; // Đặt màu viền cho tbHoTen
                isValid = false;
            }
            else
            {
                vbHoTen.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            // Giới tính
            if (cbGioiTinh.SelectedItem == null)
            {
                vbGioiTinh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbGioiTinh.BorderColor = Color.Black; // Đặt màu nền mặc định
            }
            // Tuổi
            if (string.IsNullOrEmpty(tbTuoi.Text))
            {
                vbTuoi.BorderColor = Color.Red; // Đặt màu viền cho vbTuoi
                isValid = false;
            }
            else
            {
                vbTuoi.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            // SĐT
            if (string.IsNullOrEmpty(tbSĐT.Text))
            {
                vbSĐT.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSĐT.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            // Bác sĩ
            if (cbBacSi.SelectedItem == null)
            {
                vbBacSi.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbBacSi.BorderColor = Color.Black; // Đặt màu nền mặc định
            }
            // Ca làm
            if (string.IsNullOrEmpty(tbCaLam.Text))
            {
                vbCaLam.BorderColor = Color.Red; // Đặt màu viền cho tbCaLam
                isValid = false;
            }
            else
            {
                vbCaLam.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            // Ghi chú
            if (string.IsNullOrEmpty(tbGhiChu.Text))
            {
                vbGhiChu.BorderColor = Color.Red; // Đặt màu viền cho tbGhiChu
                isValid = false;
            }
            else
            {
                vbGhiChu.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            // Địa chỉ
            if (string.IsNullOrEmpty(tbDiaChi.Text))
            {
                vbDiaChi.BorderColor = Color.Red; // Đặt màu viền cho tbQueQuan
                isValid = false;
            }
            else
            {
                vbDiaChi.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            return isValid;
        }

        private void vbThemLichHen_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem()) { return; }

            LichHenDTO lichHen = new LichHenDTO()
            {
                TenBenhNhan = tbHoTen.Text,
                // Chuyển giới tính từ string sang int (nam = 1, nữ = 0)
                GioiTinh = cbGioiTinh.SelectedIndex,
                Tuoi = Convert.ToInt32(tbTuoi.Text),
                SoDienThoai = tbSĐT.Text,
                DiaChi = tbDiaChi.Text,
                // Mã bác sĩ dựa vào tên bác sĩ được chọn
                MaBacSi = dsBacSi[cbBacSi.SelectedIndex].Id,
                NgayHen = this.ngayHienTai,
                Ca = Convert.ToInt32(tbCaLam.Text),
                GhiChu = tbGhiChu.Text,
            };

            if (leTanBUS.ThemLichHen(lichHen))
            {
                formTrangChuLeTan.vbBacSi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm lịch hẹn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            formTrangChuLeTan.vbBacSi_Click(sender, e);
        }
    }
}
