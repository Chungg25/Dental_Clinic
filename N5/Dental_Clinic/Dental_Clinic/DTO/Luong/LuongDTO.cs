using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Luong
{
    public class LuongDTO
    {
        private int id;
        private string ten = string.Empty;
        private bool gioiTinh;
        private string email = string.Empty;
        private string tenChuyenNganh = string.Empty;
        private float luongCoBan;
        private float thuong;
        private float phat;
        private float phuCap;
        private int soCa;
        private float heSoLuong;

        private int tongSoLoi;
        private float tongLuong;
        private float tongThuong;
        private float tongPhat; 

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Email { get => email; set => email = value; }
        public string TenChuyenNganh { get => tenChuyenNganh; set => tenChuyenNganh = value; }
        public float LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public float Thuong { get => thuong; set => thuong = value; }
        public float Phat { get => phat; set => phat = value; }
        public float PhuCap { get => phuCap; set => phuCap = value; }
        public int SoCa { get => soCa; set => soCa = value; }
        public float HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        public int TongSoLoi { get => tongSoLoi; set => tongSoLoi = value; }
        public float TongLuong { get => tongLuong; set => tongLuong = value; }
        public float TongThuong { get => tongThuong; set => tongThuong = value; }
        public float TongPhat { get => tongPhat; set => tongPhat = value; }

    }
}
