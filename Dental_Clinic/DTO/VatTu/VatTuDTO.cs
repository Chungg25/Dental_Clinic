using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dental_Clinic.DTO.VatTu
{
    internal class VatTuDTO
    {
        private int id;
        private string ten;
        private string loai;
        private string soLuong;
        private string donVi;
        private string lieuLuong;
        private string ngaySanXuat;
        private string ngayHetHan;
        private string ngayNhap;
        private float gia;
        private string tenLoai;

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Loai { get => loai; set => loai = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public string LieuLuong { get => lieuLuong; set => lieuLuong = value; }
        public string NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float Gia { get => gia; set => gia = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
    }
}
