using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Admin
{
    internal class LeTanBUS
    {
        private LeTanDAO receptionistDAO;

        public LeTanBUS()
        {
            receptionistDAO = new LeTanDAO();
        }

        public List<LeTanDTO> LayDanhSachLeTan()
        {
            return receptionistDAO.LayDanhSachLeTan();
        }

        public LeTanDTO LayThongTinLeTan(int id)
        {
            return receptionistDAO.LayThongTinLeTan(id);
        }
        public void CapNhatTrangThai(int userID)
        {
            receptionistDAO.CapNhatTrangThai(userID);
        }
        public void CapNhatLeTan(LeTanDTO receptionistDTO)
        {
            receptionistDAO.CapNhatLeTan(receptionistDTO);
        }
        public void ThemLeTan(LeTanDTO receptionistDTO)
        {
            receptionistDAO.ThemLeTan(receptionistDTO);
        }
    }
}
