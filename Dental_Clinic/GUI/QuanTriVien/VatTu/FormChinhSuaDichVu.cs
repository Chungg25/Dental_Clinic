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
    public partial class FormChinhSuaDichVu : Form
    {
        private MainForm mainForm;
        private VatTuBUS vatTuBUS;
        private VatTuDTO dichVu;
        private int idDichVu;
        public FormChinhSuaDichVu(MainForm mainForm, int id)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            idDichVu = id;
            vatTuBUS = new VatTuBUS();
            TaiForm();
        }

        public void TaiForm()
        {
            ChinhSua();
            dichVu = vatTuBUS.ThongTinDichVu(idDichVu);
            tbThuoc.Text = dichVu.Ten;
            tbLoaiThuoc.Text = dichVu.TenLoai;
            tbDonViTinh.Text = dichVu.DonVi;
            tbGia.Text = dichVu.Gia.ToString();
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
        }
        private void vbHuy_Click_1(object sender, EventArgs e)
        {
            TaiForm();
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            dichVu.Id = dichVu.Id;
            dichVu.DonVi = tbDonViTinh.Text;
            dichVu.Gia = int.Parse(tbGia.Text);

            vatTuBUS.CapNhatDichVu(dichVu);
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
                            formVatTu.HienThiDichVu();
                        }
                    }
                }
            }
        }

        private void FormChinhSuaDichVu_Load(object sender, EventArgs e)
        {

        }
    }
}
