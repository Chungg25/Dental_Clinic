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
        public List<DoctorDTO> GetDoctorList()
        {
            DoctorDAO doctorDAO = new DoctorDAO();
            return doctorDAO.GetDoctorList();
        }

        public void UpdateStatus(int userID)
        {
            doctorDAO.UpdateStatus(userID);
        }
        public DoctorDTO GetDoctorInfo(int userID)
        {
            return doctorDAO.GetDoctorInfo(userID);
        }
        public void UpdateDoctorInfo(DoctorDTO doctorDTO)
        {
            doctorDAO.UpdateDoctor(doctorDTO);
        }
        public void AddDoctor(DoctorDTO doctorDTO)
        {
            doctorDAO.AddDoctor(doctorDTO);
        }
    }
}
