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
    public partial class FormChiTietLuongLeTan : Form
    {
        private MainForm mainForm;
        private LuongDTO luongLeTan;
        private LuongBUS luongBUS;
        public FormChiTietLuongLeTan(MainForm mainForm, LuongDTO luongLeTan)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.luongLeTan = luongLeTan;
            luongBUS = new LuongBUS();

            TaiForm();
        }

        private void FormChiTietLuongLeTan_Load(object sender, EventArgs e)
        {

        }

        private void TaiForm()
        {
            ChinhSua();
            vbHoTen.Text = luongLeTan.Ten;
            vbEmail.Text = luongLeTan.Email;
            vbSoCaLam.Text = luongLeTan.SoCa.ToString();
            vbGioiTinh.Text = luongLeTan.GioiTinh ? "Nam" : "Nữ";
            tbHeSoLuong.Text = luongLeTan.HeSoLuong.ToString();
            tbLuongCoBan.Text = luongLeTan.LuongCoBan.ToString();
            tbThuong.Text = luongLeTan.Thuong.ToString();
            tbPhat.Text = luongLeTan.Phat.ToString();
            tbPhuCap.Text = luongLeTan.PhuCap.ToString();
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

        private void vbLuuThayDoi_Click(object sender, EventArgs e)
        {
            luongLeTan.HeSoLuong = float.Parse(tbHeSoLuong.Text);
            luongLeTan.LuongCoBan = float.Parse(tbLuongCoBan.Text);
            luongLeTan.Thuong = float.Parse(tbThuong.Text);
            luongLeTan.PhuCap = float.Parse(tbPhuCap.Text);
            luongLeTan.Phat = float.Parse(tbPhat.Text);

            luongBUS.CapNhatLuong(luongLeTan);

            mainForm.panelTrangChu.Controls.RemoveAt(0);
            if (mainForm.panelTrangChu.Controls.Count > 0)
            {
                Control control = mainForm.panelTrangChu.Controls[0];
                control.Visible = true;
                if (control is Form form)
                {
                    if (form is FormQuanLyLuong forma)
                    {
                        forma.HienThiLuongLeTan();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
                        forma.HienThiLuongLeTan();
                    }
                }
            }
        }
    }
}
