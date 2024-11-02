using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.VatTu;
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

namespace Dental_Clinic.GUI.QuanTriVien.VatTu
{
    public partial class FormThemDichVu : Form
    {
        private MainForm mainForm;
        private VatTuBUS dichVuBUS;
        private VatTuDTO dichVuDTO;
        public FormThemDichVu(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            dichVuBUS = new VatTuBUS();
            dichVuDTO = new VatTuDTO();

            ChinhSua();
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

            cbLoaiDichVu.Items.Add("Khám - Hồ sơ");
            cbLoaiDichVu.Items.Add("Nhổ răng");
            cbLoaiDichVu.Items.Add("Nha chu");
            cbLoaiDichVu.Items.Add("Chữa răng - Nội nha");
            cbLoaiDichVu.Items.Add("Phục hình tháo lắp");
            cbLoaiDichVu.Items.Add("Phục hình cố định");
            cbLoaiDichVu.Items.Add("Điều trị răng sữa");
            cbLoaiDichVu.Items.Add("Chỉnh hình răng mặt");
            cbLoaiDichVu.Items.Add("Nha công cộng");
            cbLoaiDichVu.Items.Add("Điều trị loạn năng hệ thống nhai");
            cbLoaiDichVu.Items.Add("X-Quang răng");
            cbLoaiDichVu.Items.Add("Cấy ghép Implant");
            cbLoaiDichVu.Items.Add("Phục hình đơn lẻ");
            cbLoaiDichVu.Items.Add("Phục hình bắt vít");
        }

        public bool KiemTraThem()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(tbThuoc.Text))
            {
                vbThuoc.BorderColor = Color.Red; // Đặt màu viền cho tbHoTen
                isValid = false;
            }
            else
            {
                vbThuoc.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbDonViTinh.Text))
            {
                vbDonViTinh.BorderColor = Color.Red; // Đặt màu viền cho tbEmail
                isValid = false;
            }
            else
            {
                vbDonViTinh.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbGia.Text))
            {
                vbGia.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbGia.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            if (cbLoaiDichVu.SelectedItem == null)
            {
                vbLoaiThuoc.BorderColor = Color.Red; // Đặt màu nền cho ComboBox khi không chọn
                isValid = false;
            }
            else
            {
                vbLoaiThuoc.BorderColor = Color.Black; // Đặt màu nền mặc định
            }
            return isValid;
        }

        private void vbThemDichVu_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                return;
            }
            dichVuDTO.Ten = tbThuoc.Text;
            dichVuDTO.DonVi = tbDonViTinh.Text;
            dichVuDTO.Gia = float.Parse(tbGia.Text);
            dichVuDTO.Loai = cbLoaiDichVu.SelectedItem.ToString();
            dichVuBUS.ThemDichVu(dichVuDTO);
        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            if (mainForm.panelTrangChu.Controls.Count > 0)
            {
                mainForm.panelTrangChu.Controls.RemoveAt(0);
                if (mainForm.panelTrangChu.Controls.Count > 0)
                {
                    Control control = mainForm.panelTrangChu.Controls[0];
                    control.Visible = true;
                    if (control is Form form)
                    {
                        if (form is FormVatTu formVatTu)
                        {
                            formVatTu.HienThiDichVu();
                        }
                    }
                }
            }
        }
    }
}
