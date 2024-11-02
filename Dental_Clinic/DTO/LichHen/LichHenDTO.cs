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
        private string soDienThoai = string.Empty;
        private string diaChi = string.Empty;
        private string gioiTinh = string.Empty;
        private int tuoi;
        private int maBacSi;
        private string tenBacSi = string.Empty;
        private string trangThai = string.Empty;
        private string ghiChu = string.Empty;

        public int MaLichHen { get => maLichHen; set => maLichHen = value; }
        public int MaBenhNhan { get => maBenhNhan; set => maBenhNhan = value; }
        public string TenBenhNhan { get => tenBenhNhan; set => tenBenhNhan = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public int MaBacSi { get => maBacSi; set => maBacSi = value; }
        public string TenBacSi { get => tenBacSi; set => tenBacSi = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public LichHenDTO()
        {

        }
    }
}
