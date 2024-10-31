using Dental_Clinic.DAO.LichLamViec;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.ChamCong;
using Dental_Clinic.DTO.LeTan;
using Dental_Clinic.DTO.LichLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.LichLamViec
{
    internal class LichLamViecBUS
    {
        private LichLamViecDAO lichLamViecDAO;
        public LichLamViecBUS() {
            lichLamViecDAO = new LichLamViecDAO();
        }
        public List<LichLamViecDTO> DanhSachLichLamViecBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return lichLamViecDAO.DanhSachLichLamViecBacSi(firstDayOfMonth, lastDayOfMonth);
        }
        public List<ChamCongDTO> LichLamViecBacSi(int id, DateTime day)
        {
            return lichLamViecDAO.LichLamViecBacSi(id, day);
        }

        public ChamCongDTO ChiTietLamViec(int id, DateTime day)
        {
            return lichLamViecDAO.ChiTietLamViec(id, day);
        }

    }
}
