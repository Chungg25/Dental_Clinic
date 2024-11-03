using Dental_Clinic.BUS.LeTan;
using Dental_Clinic.DTO.Patient;
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
    public partial class FormChinhSuaThongTinBenhNhan : Form
    {
        private LeTanBUS leTanBUS;
        private FormTrangChuLeTan formTrangChuLeTan;
        private BenhNhanDTO benhNhanDTO;
        public FormChinhSuaThongTinBenhNhan(FormTrangChuLeTan formTrangChuLeTan, BenhNhanDTO benhNhanDTO)
        {
            InitializeComponent();
            this.leTanBUS = new LeTanBUS();
            this.formTrangChuLeTan = formTrangChuLeTan;
            this.benhNhanDTO = benhNhanDTO;

            // Sự kiện Enter để cập nhật thông tin
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Luu_KeyDown);
        }

        private void FormChinhSuaThongTinBenhNhan_Load(object sender, EventArgs e)
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

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            HienThiThongTinBenhNhan();
        }
        // Hiển thị thông tin bệnh nhân
        private void HienThiThongTinBenhNhan()
        {
            tbHoTen.Text = benhNhanDTO.HoVaTen;
            if (benhNhanDTO.GioiTinh)
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else
            {
                cbGioiTinh.SelectedIndex = 1;
            }
            tbTuoi.Text = benhNhanDTO.Tuoi.ToString();
            tbSĐT.Text = benhNhanDTO.SDT;
            tbDiaChi.Text = benhNhanDTO.DiaChi;
            tbChanDoan.Text = benhNhanDTO.ChanDoan;
            tbPhuongPhapDieuTri.Text = benhNhanDTO.PhuongPhapDieuTri;
            tbTrieuChung.Text = benhNhanDTO.TrieuChung;
        }
        // Huỷ - Trở về form trước
        private void vbHuy_Click(object sender, EventArgs e)
        {
            formTrangChuLeTan.vbLichHen_Click(sender, e);
        }

        private void vbLuu_Click(object sender, EventArgs e)
        {
            if (leTanBUS.CapNhatThongTinBenhNhanVaBenhAn(new BenhNhanDTO
            {
                Id = benhNhanDTO.Id,
                HoVaTen = tbHoTen.Text,
                GioiTinh = cbGioiTinh.SelectedIndex == 0 ? true : false,
                Tuoi = int.Parse(tbTuoi.Text),
                SDT = tbSĐT.Text,
                DiaChi = tbDiaChi.Text,
                MaHoSo = benhNhanDTO.MaHoSo,
                ChanDoan = tbChanDoan.Text,
                PhuongPhapDieuTri = tbPhuongPhapDieuTri.Text,
                TrieuChung = tbTrieuChung.Text
            }))
            {
                formTrangChuLeTan.vbLichHen_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin bệnh nhân thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Đặt lại thông tin
        private void vbDatLai_Click(object sender, EventArgs e)
        {
            // Đặt lại dữ liệu
            HienThiThongTinBenhNhan();
        }
        // Enter để cập nhật thông tin
        private void Luu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                vbLuu_Click(sender, e);
            }
        }
    }
}
