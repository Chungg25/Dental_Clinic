using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DTO.Patient
{
    public class BenhNhanDTO
    {   
        private int id;
        private string hoVaTen = string.Empty;
        private bool gioiTinh;
        private int tuoi;
        private string sDT = string.Empty;
        private string diaChi = string.Empty;
        private int maHoSo;
        private string chanDoan = string.Empty;
        private string phuongPhapDieuTri = string.Empty;
        private string trieuChung = string.Empty;

        public int Id { get => id; set => id = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int MaHoSo { get => maHoSo; set => maHoSo = value; }
        public string ChanDoan { get => chanDoan; set => chanDoan = value; }
        public string PhuongPhapDieuTri { get => phuongPhapDieuTri; set => phuongPhapDieuTri = value; }
        public string TrieuChung { get => trieuChung; set => trieuChung = value; }
    }
}
