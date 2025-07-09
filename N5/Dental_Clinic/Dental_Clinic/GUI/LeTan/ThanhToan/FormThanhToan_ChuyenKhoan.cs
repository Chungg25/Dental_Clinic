using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.LeTan.ThanhToan
{
    public partial class FormThanhToan_ChuyenKhoan : Form
    {
        private FormChiTietHoaDon formChiTietHoaDon;
        public FormThanhToan_ChuyenKhoan(FormChiTietHoaDon formChiTietHoaDon)
        {
            InitializeComponent();
            this.formChiTietHoaDon = formChiTietHoaDon;
        }
        private void FormThanhToan_ChuyenKhoan_Load(object sender, EventArgs e)
        {
        }
        private void vbHuy_Click(object sender, EventArgs e)
        {
            // Tắt form thanh toán chuyển khoản
            this.Close();
        }

        private void vbXacNhan_Click(object sender, EventArgs e)
        {
            formChiTietHoaDon.CapNhatThanhToanThanhCong();
            this.Close();
        }

        private void pbDoiQr_Click(object sender, EventArgs e)
        {
            // Chọn ảnh QR code từ máy
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbQR.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
