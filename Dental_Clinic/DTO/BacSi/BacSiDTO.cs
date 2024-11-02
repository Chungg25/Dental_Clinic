using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.BacSi
{
    public class BacSiDTO
    {
        private int id;
        private string hoVaTen = string.Empty;
        private string cCCD = string.Empty;
        private string sDT = string.Empty;
        private string diaChi = string.Empty;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string tenDangNhap = string.Empty;
        private string matKhau = string.Empty;
        private string email = string.Empty;
        private float heSoLuong;
        private string chuyenNganh = string.Empty;
        private int ca;
        private int soLuongBenhNhan;
        private string trangThaiLamViec = string.Empty;
        private int trangThai;

        public int Id { get => id; set => id = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Email { get => email; set => email = value; }
        public float HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public string ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }
        public int Ca { get => ca; set => ca = value; }
        public int SoLuongBenhNhan { get => soLuongBenhNhan; set => soLuongBenhNhan = value; }
        public string TrangThaiLamViec { get => trangThaiLamViec; set => trangThaiLamViec = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
