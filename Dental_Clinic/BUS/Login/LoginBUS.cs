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
    internal class LoginBUS
    {
        private LoginDAO loginDAO;

        public LoginBUS()
        {
            loginDAO = new LoginDAO();
        }
        // Kiểm tra thông tin đăng nhập
        public DataRow CheckLogin(LoginDTO loginDTO)
        {
            return loginDAO.CheckLogin(loginDTO);
        }
    }
}
