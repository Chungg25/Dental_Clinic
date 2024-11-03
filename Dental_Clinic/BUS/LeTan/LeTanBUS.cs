using Dental_Clinic.DAO.LeTan;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.LeTan
{
    public class LeTanBUS
    {
        private LeTanDAO _leTanDAO;

        public LeTanBUS()
        {
            this._leTanDAO = new LeTanDAO();
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<BacSiDTO> LayThongTinBacSiTrongNgay(string ngayHienTai)
        {
            return _leTanDAO.LayThongTinBacSiTrongNgay(ngayHienTai);
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<LichHenDTO> LayDanhSachLichHenTheoNgay(string ngayHienTai)
        {
            return _leTanDAO.LayDanhSachLichHenTheoNgay(ngayHienTai);
        }
        // Thêm lịch hẹn
        public bool ThemLichHen(LichHenDTO lichHenDTO)
        {
            return _leTanDAO.ThemLichHen(lichHenDTO);
        }
        // Lấy thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhanVaBenhAnTheoMa(int maBenhNhan)
        {
            return _leTanDAO.LayThongTinBenhNhanVaBenhAnTheoMa(maBenhNhan);
        }
        // Cập nhật thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public bool CapNhatThongTinBenhNhanVaBenhAn(BenhNhanDTO benhNhan)
        {
            return _leTanDAO.CapNhatThongTinBenhNhanVaBenhAn(benhNhan);
        }
    }
}
