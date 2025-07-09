using System;

namespace Dental_Clinic.DTO.Patient
{
    public class BenhNhanDTO
    {
        // Thông tin cơ bản của bệnh nhân
        private int id;
        private string hoVaTen = string.Empty;
        private bool gioiTinh;
        private int tuoi;
        private string sDT = string.Empty;
        private string diaChi = string.Empty;

        // Thông tin bệnh án
        private int maHoSo;
        private string chanDoan = string.Empty;
        private string phuongPhapDieuTri = string.Empty;
        private string trieuChung = string.Empty;

        // Thông tin thanh toán và trạng thái
        private int maBacSi;
        private string tenBacSi = string.Empty;
        private DateTime ngayHen;
        private int ca;
        private string trangThaiKham = string.Empty;       // Ví dụ: "Đã khám", "Chưa khám"
        private string trangThaiThanhToan = string.Empty;  // Ví dụ: "Đã thanh toán", "Chưa thanh toán"

        // Thông tin hoá đơn
        private int maHoaDon;
        private int maLichHen;

        // Các thuộc tính truy cập
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

        // Thông tin bổ sung cho thanh toán
        public int MaBacSi { get => maBacSi; set => maBacSi = value; }
        public string TenBacSi { get => tenBacSi; set => tenBacSi = value; }
        public DateTime NgayHen { get => ngayHen; set => ngayHen = value; }
        public int Ca { get => ca; set => ca = value; }
        public string TrangThaiKham { get => trangThaiKham; set => trangThaiKham = value; }
        public string TrangThaiThanhToan { get => trangThaiThanhToan; set => trangThaiThanhToan = value; }

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaLichHen { get => maLichHen; set => maLichHen = value; }
    }
}
