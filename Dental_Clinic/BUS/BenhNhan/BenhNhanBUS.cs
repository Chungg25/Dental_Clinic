using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Patient
{
    internal class BenhNhanBUS
    {
        private BenhNhanDAO patientDAO;
        public BenhNhanBUS()
        {
            patientDAO = new BenhNhanDAO();
        }
        public List<BenhNhanDTO> LayDanhSachBenhNhan()
        {
            return patientDAO.LayDanhSachBenhNhan();
        }
        public BenhNhanDTO LayThongTinBenhNhan(int id)
        {
            return patientDAO.LayThongTinBenhNhan(id);
        }

        public void CapNhatBenhNhan(BenhNhanDTO patientDTO)
        {
            patientDAO.CapNhatBenhNhan(patientDTO);
        }
        public void ThemBenhNhan(BenhNhanDTO patientDTO)
        {
            patientDAO.ThemBenhNhan(patientDTO);
        }
    }
}
