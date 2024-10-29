using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Patient
{
    internal class PatientBUS
    {
        private PatientDAO patientDAO;
        public PatientBUS()
        {
            patientDAO = new PatientDAO();
        }
        public List<PatientDTO> LayDanhSachBenhNhan()
        {
            return patientDAO.LayDanhSachBenhNhan();
        }
        public PatientDTO LayThongTinBenhNhan(int id)
        {
            return patientDAO.LayThongTinBenhNhan(id);
        }

        public void CapNhatBenhNhan(PatientDTO patientDTO)
        {
            patientDAO.CapNhatBenhNhan(patientDTO);
        }
        public void ThemBenhNhan(PatientDTO patientDTO)
        {
            patientDAO.ThemBenhNhan(patientDTO);
        }
    }
}
