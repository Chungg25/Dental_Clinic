using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.LeTan;
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

namespace Dental_Clinic.GUI.Administrator.Supplies
{
    public partial class FormChinhSuaThuoc : Form
    {
        private MainForm mainForm;
        private VatTuBUS vatTuBUS;
        private VatTuDTO thuoc;
        private int idThuoc;
        public FormChinhSuaThuoc(MainForm mainForm, int id)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            vatTuBUS = new VatTuBUS();
            idThuoc = id;
            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            thuoc = vatTuBUS.ThongTinThuoc(idThuoc);
            tbThuoc.Text = thuoc.Ten;
            tbLoaiThuoc.Text = thuoc.TenLoai;
            tbSoLuong.Text = thuoc.SoLuong;
            tbDonViTinh.Text = thuoc.DonVi;
            tbLieuLuong.Text = thuoc.LieuLuong;
            tbGia.Text = thuoc.Gia.ToString();
            tbNgaySanXuat.Text = thuoc.NgaySanXuat;
            tbNgayHetHan.Text = thuoc.NgayHetHan;
            tbNgayNhap.Text = thuoc.NgayNhap;
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
                    if (textBox.Name == "tbDonViTinh" || textBox.Name == "tbGia")
                    {
                        textBox.BorderStyle = BorderStyle.None;
                        textBox.ReadOnly = false;
                    }
                    else
                    {
                        textBox.BorderStyle = BorderStyle.None;
                        textBox.KeyPress += TextBox_KeyPress;
                    }
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

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Name != "tbDonViTinh" && textBox.Name != "tbGia")
            {
                e.Handled = true; // Ngăn không cho nhập
            }
        }

        private void panelDuLieu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            TaiForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            thuoc.Id = thuoc.Id;
            thuoc.DonVi = tbDonViTinh.Text;
            thuoc.Gia = int.Parse(tbGia.Text);

            vatTuBUS.CapNhatThuoc(thuoc);
            TaiForm();
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
