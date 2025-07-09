using Dental_Clinic.BUS.Luong;
using Dental_Clinic.DTO.Luong;
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

namespace Dental_Clinic.GUI.QuanTriVien.Luong
{
    public partial class FormChiTietLuongBacSi : Form
    {
        private MainForm mainForm;
        private LuongDTO luongBacSi;
        private LuongBUS luongBUS;
        public FormChiTietLuongBacSi(MainForm mainForm, LuongDTO luongBacSi)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.luongBacSi = luongBacSi;
            luongBUS = new LuongBUS();

            TaiForm();
        }

        private void TaiForm()
        {
            ChinhSua();
            vbHoTen.Text = luongBacSi.Ten;
            vbEmail.Text = luongBacSi.Email;
            vbSoCaLam.Text = luongBacSi.SoCa.ToString();
            vbGioiTinh.Text = luongBacSi.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = luongBacSi.HeSoLuong.ToString();
            tbLuongCoBan.Text = luongBacSi.LuongCoBan.ToString();
            tbThuong.Text = luongBacSi.Thuong.ToString();
            tbPhat.Text = luongBacSi.Phat.ToString();
            tbPhuCap.Text = luongBacSi.PhuCap.ToString();
        }

        private void ChinhSua()
        {
            foreach (Control control in panelChiTiet.Controls)
            {
                if (control is Button vbButton)
                {
                    vbButton.FlatStyle = FlatStyle.Flat;
                    vbButton.FlatAppearance.BorderSize = 0;
                    vbButton.FlatAppearance.MouseOverBackColor = vbButton.BackColor;
                    vbButton.FlatAppearance.MouseDownBackColor = vbButton.BackColor;
                }
            }

            foreach (Control control in panelChiTiet.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.TextAlign = HorizontalAlignment.Center;
                }
            }
        }

        private void MakeControlReadOnly(Control control)
        {
            control.KeyPress += (s, e) => e.Handled = true;
        }

        private void vbPhuCap_Click(object sender, EventArgs e)
        {

        }

        private void pbQuayVe_Click(object sender, EventArgs e)
        {
            mainForm.panelTrangChu.Controls.RemoveAt(0);
            if (mainForm.panelTrangChu.Controls.Count > 0)
            {
                Control control = mainForm.panelTrangChu.Controls[0];
                control.Visible = true;
                if (control is Form form)
                {
                    if (form is FormQuanLyLuong forma)
                    {
                        forma.HienThiLuongBacSi();
                    }
                }
            }
        }

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            luongBacSi.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            luongBacSi.LuongCoBan = float.Parse(tbLuongCoBan.Text);
            luongBacSi.Thuong = float.Parse(tbThuong.Text);
            luongBacSi.PhuCap = float.Parse(tbPhuCap.Text);
            luongBacSi.Phat = float.Parse(tbPhat.Text);

            luongBUS.CapNhatLuong(luongBacSi);

            mainForm.panelTrangChu.Controls.RemoveAt(0);
            if (mainForm.panelTrangChu.Controls.Count > 0)
            {
                Control control = mainForm.panelTrangChu.Controls[0];
                control.Visible = true;
                if (control is Form form)
                {
                    if (form is FormQuanLyLuong forma)
                    {
                        forma.HienThiLuongBacSi();
                    }
                }
            }
        }

        private void FormChiTietLuongBacSi_Load(object sender, EventArgs e)
        {

        }
    }
}
