using Dental_Clinic.BUS.BacSi;
using Dental_Clinic.DTO.VatTu;
using Dental_Clinic.GUI.BacSi.BenhNhan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi.TrangChu
{
    public partial class FormHoaDon : Form
    {
        private BacSiBUS bacSiBUS;
        private Dictionary<int, string> dsLoaiDichVu;
        private Dictionary<int, List<VatTuDTO>> dsDichVu;
        private List<string> dsThuoc;
        private FormTrangChuBacSi formTrangChuBacSi;
        private FormThemHoSoBenhAn formThemHoSoBenhAn;
        public FormHoaDon(FormThemHoSoBenhAn formThemHoSoBenhAn, FormTrangChuBacSi formTrangChuBacSi)
        {
            InitializeComponent();
            this.bacSiBUS = new BacSiBUS();
            this.dsDichVu = new Dictionary<int, List<VatTuDTO>>();
            this.dsThuoc = new List<string>();
            this.formTrangChuBacSi = formTrangChuBacSi;
            this.formThemHoSoBenhAn = formThemHoSoBenhAn;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            SetControlStyles();
            CapNhatLoaiDichVu();
            this.dsThuoc = bacSiBUS.LayDanhSachThuoc();

            foreach (var thuoc in dsThuoc)
            {
                cbThuoc.Items.Add(thuoc);
            }

            cbThuoc.SelectedIndex = 0;
            SetupDataGridView();
        }

        private void SetControlStyles()
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

                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.KeyDown += TextBox_KeyDown; // Gán sự kiện KeyDown
                }

                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        // Thiết lập cột cho DataGridView
        private void SetupDataGridView()
        {
            // Cột Tên
            DataGridViewColumn tenColumn = new DataGridViewTextBoxColumn
            {
                Name = "Ten",
                HeaderText = "Tên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 70,  // Tỷ lệ chiếm 70% chiều rộng
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft // Căn trái
                }
            };
            dgvDanhSach.Columns.Add(tenColumn);

            // Cột Số lượng
            DataGridViewColumn soLuongColumn = new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20,  // Tỷ lệ chiếm 20% chiều rộng
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter // Căn giữa
                }
            };
            dgvDanhSach.Columns.Add(soLuongColumn);

            // Cột Xóa (nút)
            DataGridViewButtonColumn btnXoaColumn = new DataGridViewButtonColumn
            {
                Name = "Xoa",
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10,  // Tỷ lệ chiếm 10% chiều rộng
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter // Căn giữa
                }
            };
            dgvDanhSach.Columns.Add(btnXoaColumn);

            // Cấu hình chung cho DataGridView
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Gán sự kiện cho các chức năng chỉnh sửa và xóa
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;  // Xử lý nút xóa
            dgvDanhSach.CellEndEdit += dgvDanhSach_CellEndEdit;  // Cập nhật số lượng sau khi chỉnh sửa
        }


        // Cập nhật danh sách loại dịch vụ vào combobox và danh sách dịch vụ
        private void CapNhatLoaiDichVu()
        {
            this.dsLoaiDichVu = bacSiBUS.LayDanhSachLoaiDichVu();

            foreach (var loaiDichVu in dsLoaiDichVu)
            {
                cbLoaiDichVu.Items.Add(loaiDichVu.Value);
                dsDichVu.Add(loaiDichVu.Key, bacSiBUS.LayDanhSachDichVuTheoLoai(loaiDichVu.Key));
            }
            cbLoaiDichVu.SelectedIndex = 0;
        }

        private void cbLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDichVu.Items.Clear();
            foreach (var dichVu in dsDichVu[cbLoaiDichVu.SelectedIndex + 1])
            {
                cbDichVu.Items.Add(dichVu.Ten);
            }
            //cbDichVu.SelectedIndex = 0;
        }

        // Sự kiện KeyDown để thêm mục khi nhấn Enter
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = sender as TextBox;
                if (textBox == tbSoLuongDichVu && int.TryParse(tbSoLuongDichVu.Text, out int soLuongDichVu) && soLuongDichVu > 0)
                {
                    string tenDichVu = cbDichVu.SelectedItem.ToString();
                    ThemHoacCapNhatDataGridView(tenDichVu, soLuongDichVu);
                    tbSoLuongDichVu.Clear();
                }
                else if (textBox == tbSoLuongThuoc && int.TryParse(tbSoLuongThuoc.Text, out int soLuongThuoc) && soLuongThuoc > 0)
                {
                    string tenThuoc = cbThuoc.SelectedItem.ToString();
                    ThemHoacCapNhatDataGridView(tenThuoc, soLuongThuoc);
                    tbSoLuongThuoc.Clear();
                }
            }
        }

        // Thêm hoặc cập nhật thông tin vào DataGridView
        private void ThemHoacCapNhatDataGridView(string ten, int soLuong)
        {
            if (dgvDanhSach == null || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Lỗi khi thêm vào bảng. Hãy đảm bảo tên dịch vụ hoặc thuốc không rỗng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["Ten"]?.Value?.ToString() == ten)
                {
                    row.Cells["SoLuong"].Value = soLuong;
                    return;
                }
            }

            dgvDanhSach.Rows.Add(ten, soLuong);
        }

        // Sự kiện xử lý nút xóa
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDanhSach.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                string ten = dgvDanhSach.Rows[e.RowIndex].Cells["Ten"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa '{ten}' khỏi danh sách không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvDanhSach.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        // Cập nhật số lượng khi chỉnh sửa trực tiếp trong DataGridView
        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDanhSach.Columns["SoLuong"].Index)
            {
                if (!int.TryParse(dgvDanhSach.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString(), out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvDanhSach.Rows[e.RowIndex].Cells["SoLuong"].Value = 1; // Đặt lại số lượng mặc định nếu nhập sai
                }
            }
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            formTrangChuBacSi.HienThiDanhSachBenhNhan();
        }

        private void vbXacNhan_Click(object sender, EventArgs e)
        {
            // Chuẩn bị danh sách thuốc và dịch vụ từ DataGridView
            var danhSachThuoc = new List<object>();
            var danhSachDichVu = new List<object>();

            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.Cells["Ten"].Value != null && row.Cells["SoLuong"].Value != null)
                {
                    string ten = row.Cells["Ten"].Value.ToString();
                    int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());

                    // Phân loại thuốc và dịch vụ (giả định dựa vào dsThuoc)
                    if (dsThuoc.Contains(ten))
                    {
                        danhSachThuoc.Add(new { tenThuoc = ten, soLuong = soLuong });
                    }
                    else
                    {
                        danhSachDichVu.Add(new { tenDichVu = ten, soLuong = soLuong });
                    }
                }
            }

            // Chuyển đổi danh sách thuốc và dịch vụ thành JSON
            string jsonThuoc = JsonConvert.SerializeObject(danhSachThuoc);
            string jsonDichVu = JsonConvert.SerializeObject(danhSachDichVu);

            // Thiết lập các tham số cần truyền vào proc
            int maBacSi = formThemHoSoBenhAn.MaBacSi();
            int maBenhNhan = formThemHoSoBenhAn.MaBenhNhan();
            int phuongThucThanhToan = -1;
            string ngay = DateTime.Now.ToString("yyyy-MM-dd");

            if (bacSiBUS.ThemHoaDon(maBacSi, maBenhNhan, phuongThucThanhToan, ngay, jsonThuoc, jsonDichVu))
            {
                MessageBox.Show("Thêm hoá đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formTrangChuBacSi.HienThiDanhSachBenhNhan();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm hoá đơn thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
