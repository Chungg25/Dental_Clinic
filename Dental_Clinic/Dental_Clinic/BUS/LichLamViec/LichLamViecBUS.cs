using Dental_Clinic.DAO.LichLamViec;
using Dental_Clinic.DTO.ChamCong;
using Dental_Clinic.DTO.LichLamViec;

namespace Dental_Clinic.BUS.LichLamViec
{
    internal class LichLamViecBUS
    {
        private LichLamViecDAO lichLamViecDAO;
        public LichLamViecBUS()
        {
            lichLamViecDAO = new LichLamViecDAO();
        }
        public List<LichLamViecDTO> DanhSachLichLamViecBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return lichLamViecDAO.DanhSachLichLamViecBacSi(firstDayOfMonth, lastDayOfMonth);
        }
        public List<ChamCongDTO> LichLamViec(int id, DateTime day)
        {
            return lichLamViecDAO.LichLamViec(id, day);
        }

        public ChamCongDTO ChiTietLamViec(int id, DateTime day)
        {
            return lichLamViecDAO.ChiTietLamViec(id, day);
        }

        public void ThemLichLamViec(int id, int ca, DateTime ngay)
        {
            lichLamViecDAO.ThemLichLamViec(id, ca, ngay);
        }

        public void XoaLichLamViec(int id, DateTime ngay)
        {
            lichLamViecDAO.XoaLichLamViec(id, ngay);
        }

        public List<LichLamViecDTO> DanhSachLichLamViecLeTan(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return lichLamViecDAO.DanhSachLichLamViecLeTan(firstDayOfMonth, lastDayOfMonth);
        }

        public List<ChamCongDTO> LichLamViecLeTan(int id, DateTime day)
        {
            return lichLamViecDAO.LichLamViecLeTan(id, day);
        }
    }
}
