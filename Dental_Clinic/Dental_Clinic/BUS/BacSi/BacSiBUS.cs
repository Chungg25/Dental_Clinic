using Dental_Clinic.DAO.BacSi;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.BacSi
{
    public class BacSiBUS
    {
        private BacSiDAO bacSiDAO;

        public BacSiBUS()
        {
            bacSiDAO = new BacSiDAO();
        }

        // Lấy danh sách bệnh nhân của bác sĩ
        public List<BenhNhanDTO> LayDanhSachBenhNhanCuaBacSi(int id, string ngayHienTai)
        {
            return bacSiDAO.LayDanhSachBenhNhanCuaBacSi(id, ngayHienTai);
        }
        // Thêm hồ sơ bệnh án
        public bool CapNhatHoSoBenhAn(int maBenhNhan, string chanDoan, string phuongPhapDieuTri, string trieuChung, string ngayLap, int maBacSi, int maLichHen)
        {
            //MessageBox.Show(maBenhNhan + " " + chanDoan + " " + phuongPhapDieuTri + " " + trieuChung + " " + ngayLap + " " + maBacSi + " " + maLichHen);

            return bacSiDAO.CapNhatHoSoBenhAn(maBenhNhan, chanDoan, phuongPhapDieuTri, trieuChung, ngayLap, maBacSi, maLichHen);
        }
        // Thêm lịch hẹn
        public bool ThemLichHen(int maBenhNhan, int maBacSi, string ghiChu, string ngayHen, int ca)
        {
            return bacSiDAO.ThemLichHen(maBenhNhan, maBacSi, ghiChu, ngayHen, ca);
        }
        // Lấy danh sách loại dịch vụ
        public Dictionary<int, string> LayDanhSachLoaiDichVu()
        {
            return bacSiDAO.LayDanhSachLoaiDichVu();
        }
        // Lấy danh sách dịch vụ theo loại dịch vụ
        public List<VatTuDTO> LayDanhSachDichVuTheoLoai(int maLoaiDichVu)
        {
            return bacSiDAO.LayDanhSachDichVuTheoLoai(maLoaiDichVu);
        }
        // Lấy danh sách thuốc
        public List<string> LayDanhSachThuoc()
        {
            return bacSiDAO.LayDanhSachThuoc();
        }
        // Thêm hoá đơn
        public bool ThemHoaDon(int maBacSi, int maBenhNhan, int phuongThucThanhToan, string ngay, string jsonThuoc, string jsonDichVu)
        {
            return bacSiDAO.ThemHoaDon(maBacSi, maBenhNhan, phuongThucThanhToan, ngay, jsonThuoc, jsonDichVu);
        }
    }
}
