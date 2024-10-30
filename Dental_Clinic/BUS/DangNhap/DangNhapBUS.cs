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
        private DangNhapDAO dangNhapDAO;

        public DangNhapBUS()
        {
            dangNhapDAO = new DangNhapDAO();
        }

        public DataRow KiemTraDangNhap(DangNhapDTO dangNhapDTO)
        {
            return dangNhapDAO.KiemTraDangNhap(dangNhapDTO);
        }
    }
}
