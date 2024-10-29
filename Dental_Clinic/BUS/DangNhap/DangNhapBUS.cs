using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DAO.Login;
using Dental_Clinic.DTO.Login;

namespace Dental_Clinic.BUS.Login
{
    internal class DangNhapBUS
    {
        private DangNhapDAO loginDAO;

        public DangNhapBUS()
        {
            loginDAO = new DangNhapDAO();
        }

        public DataRow KiemTraDangNhap(DangNhapDTO loginDTO)
        {
            return loginDAO.KiemTraDangNhap(loginDTO);
        }
    }
}
