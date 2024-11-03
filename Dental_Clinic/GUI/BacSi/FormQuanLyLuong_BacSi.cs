using Dental_Clinic.BUS.LeTan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi
{
    public partial class FormQuanLyLuong_BacSi : Form
    {
        private LeTanBUS leTanBUS;
        private int maBacSi;
        public FormQuanLyLuong_BacSi(int maBacSi)
        {
            InitializeComponent();
            this.maBacSi = maBacSi;
            this.leTanBUS = new LeTanBUS();
        }

        private void FormQuanLyLuong_Load(object sender, EventArgs e)
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
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
            }

            // Chỉ được xem thông tin lương của chính mình
            HienThiLuong();
        }
        // Hiển thị thông tin lương
        private void HienThiLuong()
        {
            // Lấy tháng và năm hiện tại
            var thangHienTai = DateTime.Now.Month;
            var namHienTai = DateTime.Now.Year;
            var dsLuong = leTanBUS.LayThongTinLuong(maBacSi, thangHienTai, namHienTai);

            // Hiển thị thông tin lương
            tbHoTen.Text = dsLuong.Ten;
            tbSoNgayLam.Text = dsLuong.SoCa.ToString();
            tbTongSoLoi.Text = dsLuong.TongSoLoi.ToString();
            tbTongTienPhat.Text = dsLuong.TongPhat.ToString();
            tbTongLuong.Text = dsLuong.TongLuong.ToString();
        }
    }
}
