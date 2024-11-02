using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.ChamCong
{
    internal class ChamCongDTO
    {
        private int maNguoiDung;
        private string ngay;
        private int ca;
        private string hoTen;
        private bool gioiTinh;
        private string email;
        private int trangThai;
        private string ghiChu;
        private string gioVao;
        private string gioRa;
        private string sĐT;
        private string diaChi;

        public string Ngay { get => ngay; set => ngay = value; }
        public int Ca { get => ca; set => ca = value; }
        public int MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string Email { get => email; set => email = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string GioVao { get => gioVao; set => gioVao = value; }
        public string GioRa { get => gioRa; set => gioRa = value; }
        public string SĐT { get => sĐT; set => sĐT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
