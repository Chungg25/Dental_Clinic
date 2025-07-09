using Dental_Clinic.BUS.BacSi;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.GUI.BacSi.BenhNhan;
using Dental_Clinic.GUI.LeTan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.BacSi.TrangChu
{
    public partial class FormThemHoSoBenhAn : Form
    {
        private FormTrangChuBacSi formTrangChuBacSi;
        private BenhNhanDTO benhNhan;
        private BacSiBUS bacSiBUS;
        private int maBacSi;
        private bool kiemTraHenTaiKham = false;
        private bool kiemTraThemHoaDon = false;

        public FormThemHoSoBenhAn(FormTrangChuBacSi formTrangChuBacSi, BenhNhanDTO maBenhNhan, int maBacSi)
        {
            InitializeComponent();
            this.formTrangChuBacSi = formTrangChuBacSi;
            this.benhNhan = maBenhNhan;
            this.maBacSi = maBacSi;
            this.bacSiBUS = new BacSiBUS();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormThemHoSoBenhAn_Load(object sender, EventArgs e)
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

            tbHoTen.Text = benhNhan.HoVaTen;
            tbSDT.Text = benhNhan.SDT;

            // Chỉ được xem Họ tên và SĐT của bệnh nhân
            tbHoTen.ReadOnly = true;
            tbSDT.ReadOnly = true;
            // Màu nền trắng khi chỉ xem
            tbHoTen.BackColor = Color.White;
            tbSDT.BackColor = Color.White;

        }
        // Kiểm tra thông tin nhập vào
        private bool KiemTraThongTin()
        {
            bool kiemTra = true;

            if (tbTrieuChung.Text == "")
            {
                vbTrieuChung.BorderColor = Color.Red;
                kiemTra = false;
            }
            else
            {
                vbTrieuChung.BorderColor = Color.Black;
                kiemTra = true;
            }

            if (tbChanDoan.Text == "")
            {
                vbChanDoan.BorderColor = Color.Red;
                kiemTra = false;
            }
            else
            {
                vbChanDoan.BorderColor = Color.Black;
                kiemTra = true;
            }

            if (tbPhuongPhapDieuTri.Text == "")
            {
                vbPhuongPhapDieuTri.BorderColor = Color.Red;
                kiemTra = false;
            }
            else
            {
                vbPhuongPhapDieuTri.BorderColor = Color.Black;
                kiemTra = true;
            }

            return kiemTra;
        }
        private void vbXacNhan_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin()) { return; }

            int maBenhNhan = benhNhan.Id;
            int maLichHen = benhNhan.MaLichHen;
            string trieuChung = tbTrieuChung.Text;
            string chanDoan = tbChanDoan.Text;
            string phuongPhapDieuTri = tbPhuongPhapDieuTri.Text;
            string ngayLap = DateTime.Now.ToString("yyyy-MM-dd");

            // Cập nhật hồ sơ bệnh án
            bacSiBUS.CapNhatHoSoBenhAn(maBenhNhan, chanDoan, phuongPhapDieuTri, trieuChung, ngayLap, maBacSi, maLichHen);

            // Quay lại trang chủ bác sĩ
            formTrangChuBacSi.HienThiDanhSachBenhNhan();
            this.Close();
        }

        private void vbHuy_Click(object sender, EventArgs e)
        {
            formTrangChuBacSi.HienThiDanhSachBenhNhan();
        }

        private void vbHenTaiKham_Click(object sender, EventArgs e)
        {
            FormDatLichHen formDatLichHen = new FormDatLichHen(maBacSi, benhNhan.Id);
            formDatLichHen.ShowDialog();
        }

        private void vbThemHoaDon_Click(object sender, EventArgs e)
        {
            formTrangChuBacSi.HienThiForm(new FormHoaDon(this, formTrangChuBacSi));
        }

        public int MaBacSi () { return maBacSi; }
        public int MaBenhNhan () { return benhNhan.Id; }
    }
}
