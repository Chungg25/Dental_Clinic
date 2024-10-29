using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Admin
{
    public class UserDTO
    {
        private int id;
        private string hoVaTen;
        private string cCCD;
        private string sDT;
        private string diaChi;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string chucVu;
        private string tenDangNhap;
        private string matKhau;
        private string email;
        private float heSoLuong;

        public int Id { get => id; set => id = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Email { get => email; set => email = value; }
        public float HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
    }
}
