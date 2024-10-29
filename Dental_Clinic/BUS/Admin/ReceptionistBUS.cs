using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Admin
{
    internal class ReceptionistBUS
    {
        private ReceptionistDAO receptionistDAO;

        public ReceptionistBUS()
        {
            receptionistDAO = new ReceptionistDAO();
        }

        public List<ReceptionistDTO> LayDanhSachLeTan()
        {
            return receptionistDAO.LayDanhSachLeTan();
        }

        public ReceptionistDTO LayThongTinLeTan(int id)
        {
            return receptionistDAO.LayThongTinLeTan(id);
        }
        public void CapNhatTrangThai(int userID)
        {
            receptionistDAO.CapNhatTrangThai(userID);
        }
        public void CapNhatLeTan(ReceptionistDTO receptionistDTO)
        {
            receptionistDAO.CapNhatLeTan(receptionistDTO);
        }
        public void ThemLeTan(ReceptionistDTO receptionistDTO)
        {
            receptionistDAO.ThemLeTan(receptionistDTO);
        }
    }
}
