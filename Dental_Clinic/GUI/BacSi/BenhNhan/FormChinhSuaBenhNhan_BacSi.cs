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
    public partial class FormChinhSuaBenhNhan_BacSi : Form
    {
        private FormBacSi _formBacSi;
        private BenhNhanDTO _benhNhanDTO;
        private BenhNhanBUS _benhNhanBUS;
        public FormChinhSuaBenhNhan_BacSi(FormBacSi formBacSi, BenhNhanDTO benhNhanDTO)
        {
            InitializeComponent();
            this._formBacSi = formBacSi;
            this._benhNhanDTO = benhNhanDTO;
            this._benhNhanBUS = new BenhNhanBUS();

            TaiThongTinBenhNhan();
        }
        // Tải thông tin bệnh nhân
        public void TaiThongTinBenhNhan()
        {
            ChinhSua();
            tbHoTen.Text = _benhNhanDTO.HoVaTen;
            tbSĐT.Text = _benhNhanDTO.SDT;
            tbTuoi.Text = _benhNhanDTO.Tuoi.ToString();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedItem = _benhNhanDTO.GioiTinh ? "Nam" : "Nữ";
            tbQueQuan.Text = _benhNhanDTO.DiaChi;
            // Chỉ được đọc không được chỉnh sửa trong comboBox
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        // Chỉnh sửa thông tin
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
        }
        // Lưu thông tin
        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            _benhNhanDTO.Id = _benhNhanDTO.Id;
            _benhNhanDTO.HoVaTen = tbHoTen.Text;
            _benhNhanDTO.SDT = tbSĐT.Text;
            _benhNhanDTO.GioiTinh = cbGioiTinh.SelectedItem?.ToString() == "Nam"; // Cập nhật giới tính
            _benhNhanDTO.Tuoi = Convert.ToInt32(tbTuoi.Text);
            _benhNhanDTO.DiaChi = tbQueQuan.Text;

            _benhNhanBUS.CapNhatBenhNhan(_benhNhanDTO);
            _benhNhanBUS.LayThongTinBenhNhan(_benhNhanDTO.Id);

            MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ChinhSua();
        }
        // Đặt lại thông tin
        private void vbDatLai_Click(object sender, EventArgs e)
        {
            TaiThongTinBenhNhan();
        }
        // Huỷ - Quay lại
        private void vbHuy_Click(object sender, EventArgs e)
        {
            _formBacSi.ShowFormOnPanel(new FormBenhNhan_BacSi(_formBacSi));
        }
    }
}
