using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.LichHen
{
    public class LichHenDTO
    {
        private int maLichHen;
        private int maBenhNhan;
        private string tenBenhNhan = string.Empty;
        private int gioiTinh;
        private int tuoi;
        private string soDienThoai = string.Empty;
        private string diaChi = string.Empty;
        private int maBacSi;
        private string tenBacSi = string.Empty;
        private string ngayHen = string.Empty;
        private int ca;
        private string ghiChu = string.Empty;
        private string trangThai = string.Empty;

        public int MaLichHen { get => maLichHen; set => maLichHen = value; }
        public int MaBenhNhan { get => maBenhNhan; set => maBenhNhan = value; }
        public string TenBenhNhan { get => tenBenhNhan; set => tenBenhNhan = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int MaBacSi { get => maBacSi; set => maBacSi = value; }
        public string TenBacSi { get => tenBacSi; set => tenBacSi = value; }
        public string NgayHen { get => ngayHen; set => ngayHen = value; }
        public int Ca { get => ca; set => ca = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
