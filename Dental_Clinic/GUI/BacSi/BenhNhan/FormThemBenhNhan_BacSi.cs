using Dental_Clinic.BUS.Patient;
using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi.BenhNhan 
{
    public partial class FormThemBenhNhan_BacSi : Form
    {
        private FormBacSi _formBacSi;
        private BenhNhanBUS _benhNhanBUS;
        private BenhNhanDTO _benhNhanDTO;
        public FormThemBenhNhan_BacSi(FormBacSi formBacSi)
        {
            InitializeComponent();
            this._formBacSi = formBacSi;
            this._benhNhanBUS = new BenhNhanBUS();
            this._benhNhanDTO = new BenhNhanDTO();
        }
        private void FormThemBenhNhan_BacSi_Load(object sender, EventArgs e)
        {
            ChinhSua();
            // Chỉ được đọc không được chỉnh sửa trong comboBox
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void vbThemBenhNhan_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _benhNhanDTO.HoVaTen = tbHoTen.Text;
            _benhNhanDTO.SDT = tbSĐT.Text;
            _benhNhanDTO.GioiTinh = cbGioiTinh.SelectedItem?.ToString() == "Nam"; // Cập nhật giới tính
            _benhNhanDTO.DiaChi = tbQueQuan.Text;
            _benhNhanDTO.Tuoi = int.Parse(tbTuoi.Text);

            _benhNhanBUS.ThemBenhNhan(_benhNhanDTO);

            MessageBox.Show("Thêm bệnh nhân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Quay lại form bệnh nhân
            _formBacSi.ShowFormOnPanel(new FormBenhNhan_BacSi(_formBacSi));
        }

        public void ChinhSua()
        {
            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in panelDuLieu.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }

        public bool KiemTraThem()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                vbHoTen.BorderColor = Color.Red; // Đặt màu viền cho tbHoTen
                isValid = false;
            }
            else
            {
                vbHoTen.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbSĐT.Text))
            {
                vbSĐT.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSĐT.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbQueQuan.Text))
            {
                vbQueQuan.BorderColor = Color.Red; // Đặt màu viền cho tbQueQuan
                isValid = false;
            }
            else
            {
                vbQueQuan.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbTuoi.Text))
            {
                vbTuoi.BorderColor = Color.Red; // Đặt màu viền cho vbTuoi
                isValid = false;
            }
            else
            {
                vbTuoi.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (cbGioiTinh.SelectedItem == null)
            {
                vbGioiTinh.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbGioiTinh.BorderColor = Color.White; // Đặt màu nền mặc định
            }
            return isValid;
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            _formBacSi.ShowFormOnPanel(new FormBenhNhan_BacSi(_formBacSi));
        }
    }
}
