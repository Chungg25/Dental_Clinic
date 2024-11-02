using Dental_Clinic.BUS.VatTu;
using Dental_Clinic.DTO.VatTu;
using Dental_Clinic.GUI.Receptionist;
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
    public partial class FormChinhSuaVatTu : Form
    {
        private MainForm mainForm;
        private VatTuBUS vatTuBUS;
        private VatTuDTO vatTu;
        private int idVatTu;
        public FormChinhSuaVatTu(MainForm mainForm, int id)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            idVatTu = id;
            vatTuBUS = new VatTuBUS();

            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            vatTu = vatTuBUS.ThongTinVatTu(idVatTu);
            tbThuoc.Text = vatTu.Ten;
            tbLoaiThuoc.Text = vatTu.TenLoai;
            tbSoLuong.Text = vatTu.SoLuong;
            tbDonViTinh.Text = vatTu.DonVi;
            tbLieuLuong.Text = vatTu.LieuLuong;
            tbGia.Text = vatTu.Gia.ToString();
            tbNgaySanXuat.Text = vatTu.NgaySanXuat;
            tbNgayHetHan.Text = vatTu.NgayHetHan;
            tbNgayNhap.Text = vatTu.NgayNhap;
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
                            formVatTu.HienVatTu();
                        }
                    }
                }
            }
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            TaiForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            vatTu.Id = vatTu.Id;
            vatTu.DonVi = tbDonViTinh.Text;
            vatTu.Gia = int.Parse(tbGia.Text);

            vatTuBUS.CapNhatVatTu(vatTu);
            TaiForm();
        }
    }
}
