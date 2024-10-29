using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Admin
{
    internal class DoctorBUS
    {
        private DoctorDAO doctorDAO;
        public DoctorBUS()
        {
            doctorDAO = new DoctorDAO();
        }
        public List<DoctorDTO> LayDanhSachBacSi()
        {
            DoctorDAO doctorDAO = new DoctorDAO();
            return doctorDAO.LayDanhSachBacSi();
        }

        public void CapNhatTrangThai(int userID)
        {
            doctorDAO.CapNhatTrangThai(userID);
        }
        public DoctorDTO LayThongTinBacSi(int userID)
        {
            return doctorDAO.LayThongTinBacSi(userID);
        }
        public void CapNhatBacSi(DoctorDTO doctorDTO)
        {
            doctorDAO.CapNhatBacSi(doctorDTO);
        }
        public void ThemBacSi(DoctorDTO doctorDTO)
        {
            doctorDAO.ThemBacSi(doctorDTO);
        }
    }
}
