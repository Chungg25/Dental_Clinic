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

        public string Ngay { get => ngay; set => ngay = value; }
        public int Ca { get => ca; set => ca = value; }
        public int MaNguoiDung { get => maNguoiDung; set => maNguoiDung = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
