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
        public int SoLuongBacSi()
        {
            return adminDAO.SoLuongBacSi();
        }
        public int SoLuongBenhNhan()
        {
            return adminDAO.SoLuongBenhNhan();
        }
        public int TongLuong()
        {
            return adminDAO.TongLuong();
        }
    }
}
