using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.LichLamViec
{
    internal class LichLamViecDTO
    {
        private int maNguoiDung;
        private string hoTen;
        private bool gioiTinh;
        private string email;
        private int soCa;

        public int MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string ChuyenNganh { get; set; }
        public int SoCa { get => soCa; set => soCa = value; }
    }
}
