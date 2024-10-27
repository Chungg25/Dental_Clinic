using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DAO.Admin;

namespace Dental_Clinic.BUS.Admin
{
    internal class AdminBUS
    {
        private AdminDAO adminDAO;
        public AdminBUS()
        {
            adminDAO = new AdminDAO();
        }
        public int DoctorCount()
        {
            return adminDAO.DoctorCount();
        }
        public int PatientCount()
        {
            return adminDAO.PatientCount();
        }
        public int RevenueCount()
        {
            return adminDAO.RevenueCount();
        }
    }
}
