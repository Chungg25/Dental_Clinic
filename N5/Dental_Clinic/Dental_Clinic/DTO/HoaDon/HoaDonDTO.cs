using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.HoaDon
{
    public class HoaDonDTO
    {
        private string loaiMuc = string.Empty;
        private string tenMuc = string.Empty;
        private int soLuong;
        private float donGia;
        private float thanhTien;

        public string LoaiMuc { get => loaiMuc; set => loaiMuc = value; }
        public string TenMuc { get => tenMuc; set => tenMuc = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
