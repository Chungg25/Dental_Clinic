using Dental_Clinic.BUS.LichLamViec;
using Dental_Clinic.DTO.ChamCong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_Clinic.GUI.QuanTriVien.LichLamViec
{
    public partial class FormChiTietCaLam : Form
    {
        private LichLamViecBUS lichLamViecBUS;
        public FormChiTietCaLam(int id, DateTime day)
        {
            InitializeComponent();
            lichLamViecBUS = new LichLamViecBUS();
            ChinhSua();
            HienThi(id, day);
        }

        public void HienThi(int id, DateTime day)
        {
            ChamCongDTO chamCongDTO = lichLamViecBUS.ChiTietLamViec(id, day);
            vbHoTen.Text = chamCongDTO.HoTen;
            vbEmail.Text = chamCongDTO.Email;
            vbSĐT.Text = chamCongDTO.SĐT;
            vbGioiTinh.Text = chamCongDTO.GioiTinh ? "Nam" : "Nữ";
            vbGioVao.Text = chamCongDTO.GioVao;
            vbGioRa.Text = chamCongDTO.GioRa;
            vbTrangThai.Text = chamCongDTO.GhiChu;
            if (chamCongDTO.GhiChu.Equals("làm việc đúng giờ", StringComparison.OrdinalIgnoreCase))
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#28a745");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }
            else if (chamCongDTO.GhiChu.Equals("đi làm trễ", StringComparison.OrdinalIgnoreCase))
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#17a2b8");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }
            else
            {
                vbTrangThai.BackColor = ColorTranslator.FromHtml("#dc3545");
                vbTrangThai.ForeColor = Color.White;
                vbTrangThai.Font = new Font(vbTrangThai.Font, FontStyle.Bold);
                vbTrangThai.BorderSize = 1;
                vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
                vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;
            }
            vbQueQuan.Text = chamCongDTO.DiaChi;
        }

        private void ChinhSua()
        {
            vbHoTen.FlatStyle = FlatStyle.Flat;
            vbHoTen.FlatAppearance.BorderSize = 0;
            vbHoTen.FlatAppearance.MouseOverBackColor = vbHoTen.BackColor;
            vbHoTen.FlatAppearance.MouseDownBackColor = vbHoTen.BackColor;

            vbEmail.FlatStyle = FlatStyle.Flat;
            vbEmail.FlatAppearance.BorderSize = 0;
            vbEmail.FlatAppearance.MouseOverBackColor = vbEmail.BackColor;
            vbEmail.FlatAppearance.MouseDownBackColor = vbEmail.BackColor;

            vbSĐT.FlatStyle = FlatStyle.Flat;
            vbSĐT.FlatAppearance.BorderSize = 0;
            vbSĐT.FlatAppearance.MouseOverBackColor = vbSĐT.BackColor;
            vbSĐT.FlatAppearance.MouseDownBackColor = vbSĐT.BackColor;

            vbGioiTinh.BorderSize = 1;
            vbGioiTinh.BorderColor = Color.Black;
            vbGioiTinh.FlatAppearance.MouseOverBackColor = vbGioiTinh.BackColor;
            vbGioiTinh.FlatAppearance.MouseDownBackColor = vbGioiTinh.BackColor;

            vbGioVao.BorderSize = 1;
            vbGioVao.BorderColor = Color.Black;
            vbGioVao.FlatAppearance.MouseOverBackColor = vbGioVao.BackColor;
            vbGioVao.FlatAppearance.MouseDownBackColor = vbGioVao.BackColor;

            vbGioRa.BorderSize = 1;
            vbGioRa.BorderColor = Color.Black;
            vbGioRa.FlatAppearance.MouseOverBackColor = vbGioRa.BackColor;
            vbGioRa.FlatAppearance.MouseDownBackColor = vbGioRa.BackColor;

            vbTrangThai.BorderSize = 1;
            vbTrangThai.BorderColor = Color.Black;
            vbTrangThai.FlatAppearance.MouseOverBackColor = vbTrangThai.BackColor;
            vbTrangThai.FlatAppearance.MouseDownBackColor = vbTrangThai.BackColor;

            vbQueQuan.BorderSize = 1;
            vbQueQuan.BorderColor = Color.Black;
            vbQueQuan.FlatAppearance.MouseOverBackColor = vbQueQuan.BackColor;
            vbQueQuan.FlatAppearance.MouseDownBackColor = vbQueQuan.BackColor;
        }
    }
}
