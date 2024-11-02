using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Dental_Clinic.GUI.Administrator.Supplies
{
    public partial class FormThemThuoc : Form
    {
        private MainForm mainForm;
        private VatTuBUS thuocBUS;
        private VatTuDTO thuocDTO;
        public FormThemThuoc(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            thuocBUS = new VatTuBUS();
            thuocDTO = new VatTuDTO();

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

            cbLoaiThuoc.Items.Add("Kháng sinh");
            cbLoaiThuoc.Items.Add("Kháng viêm");
            cbLoaiThuoc.Items.Add("Giảm đau");

            dtpNgaySanXuat.Format = DateTimePickerFormat.Custom;
            dtpNgaySanXuat.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayHetHan.Format = DateTimePickerFormat.Custom;
            dtpNgayHetHan.CustomFormat = "dd/MM/yyyy";
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

            if (string.IsNullOrEmpty(cbLoaiThuoc.Text))
            {
                vbLoaiThuoc.BorderColor = Color.Red; // Đặt màu viền cho tbEmail
                isValid = false;
            }
            else
            {
                vbLoaiThuoc.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbSoLuong.Text))
            {
                vbSoLuong.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbSoLuong.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbLieuLuong.Text))
            {
                vbLieuLuong.BorderColor = Color.Red; // Đặt màu viền cho tbSĐT
                isValid = false;
            }
            else
            {
                vbLieuLuong.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbDonViTinh.Text))
            {
                vbDonViTinh.BorderColor = Color.Red; // Đặt màu viền cho tbCCCD
                isValid = false;
            }
            else
            {
                vbDonViTinh.BorderColor = Color.Black; // Đặt màu viền mặc định
            }

            if (string.IsNullOrEmpty(tbGia.Text))
            {
                vbGia.BorderColor = Color.Red; // Đặt màu viền cho tbQueQuan
                isValid = false;
            }
            else
            {
                vbGia.BorderColor = Color.Black; // Đặt màu viền mặc định
            }
            if (dtpNgaySanXuat.Value >= dtpNgayNhap.Value)
            {
                vbNgaySanXuat.BorderColor = Color.Red;
                vbNgayNhap.BorderColor = Color.Red;
                isValid = false;
            }
            else
            {
                vbNgayNhap.BorderColor = Color.Black;
                vbNgaySanXuat.BorderColor = Color.Black;
            }
            if (dtpNgayHetHan.Value <= dtpNgayNhap.Value)
            {
                vbNgayHetHan.BorderColor = Color.Red;
                vbNgayNhap.BorderColor = Color.Red;
                isValid = false;
            }
            else
            {
                vbNgayHetHan.BorderColor = Color.Black;
                vbNgayNhap.BorderColor = Color.Black;
            }
            return isValid;
        }

        private void vbThemThuoc_Click(object sender, EventArgs e)
        {
            if (!KiemTraThem())
            {
                return;
            }
            thuocDTO.Ten = tbThuoc.Text;
            thuocDTO.TenLoai = cbLoaiThuoc.SelectedItem?.ToString() ?? "";
            thuocDTO.SoLuong = tbSoLuong.Text;
            thuocDTO.DonVi = tbDonViTinh.Text;
            thuocDTO.LieuLuong = tbDonViTinh.Text;
            thuocDTO.Gia = float.Parse(tbGia.Text);
            thuocDTO.NgaySanXuat = dtpNgaySanXuat.Value.ToString();
            thuocDTO.NgayNhap = dtpNgayNhap.Value.ToString();
            thuocDTO.NgayHetHan = dtpNgayHetHan.Value.ToString();

            thuocBUS.ThemThuoc(thuocDTO);
            //MessageBox.Show(thuocDTO.TenLoai)
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
                            formVatTu.HienThiThuoc();
                        }
                    }
                }
            }
        }
    }
}
