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
        public List<PatientDTO> GetPatientList()
        {
            return patientDAO.GetPatientList();
        }
        public PatientDTO GetPatientInfo(int id)
        {
            return patientDAO.GetPatientInfo(id);
        }

        public void UpdatePatient(PatientDTO patientDTO)
        {
            patientDAO.UpdatePatient(patientDTO);
        }
    }
}
