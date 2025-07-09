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

namespace Dental_Clinic.GUI.LeTan
{
    public partial class FormQuanLyLuong_LeTan : Form
    {
        private LeTanBUS leTanBUS;
        private int maLeTan;
        public FormQuanLyLuong_LeTan(int maLeTan)
        {
            InitializeComponent();
            this.leTanBUS = new LeTanBUS();
            this.maLeTan = maLeTan;
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
            DateTime ngayChon = dtpNgay.Value; 
            DateTime dauThang = new DateTime(ngayChon.Year, ngayChon.Month, 1);
            DateTime cuoiThang = dauThang.AddMonths(1).AddDays(-1);
            var dsLuong = leTanBUS.LayThongTinLuong(maLeTan, dauThang, cuoiThang);

            // Hiển thị thông tin lương
            tbHoTen.Text = dsLuong.Ten;
            tbSoNgayLam.Text = dsLuong.SoCa.ToString();
            tbTongSoLoi.Text = dsLuong.Phat.ToString();
            tbTongTienPhat.Text = dsLuong.Phat.ToString();
            float tongLuong = (dsLuong.LuongCoBan * dsLuong.SoCa * dsLuong.HeSoLuong) + dsLuong.PhuCap + dsLuong.Thuong - dsLuong.Phat;
            tbTongLuong.Text = tongLuong.ToString();
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            HienThiLuong();
        }
    }
}
