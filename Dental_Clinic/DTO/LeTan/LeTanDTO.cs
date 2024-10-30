using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.LeTan
{
    public class LeTanDTO
    {
        private int id;
        private string hoVaTen;
        private string cCCD;
        private string sDT;
        private string diaChi;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string tenDangNhap;
        private string matKhau;
        private string email;
        private float heSoLuong;
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public float HeSoLuong { get; set; }
        public string ChuyenNganh { get; set; }
        public int TrangThai { get; set; }
    }
}
