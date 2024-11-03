using Dental_Clinic.DAO;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.Luong;
using Dental_Clinic.DAO.Luong;

namespace Dental_Clinic.BUS.Luong
{
    internal class LuongBUS
    {
        private LuongDAO luongDAO;
        public LuongBUS()
        {
            luongDAO = new LuongDAO();
        }
        public List<LuongDTO> DanhSachLuongBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return luongDAO.DanhSachLuongBacSi(firstDayOfMonth, lastDayOfMonth);
        }
        public List<LuongDTO> DanhSachLuongLeTan(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return luongDAO.DanhSachLuongLeTan(firstDayOfMonth, lastDayOfMonth);
        }

        public LuongDTO LuongBacSi(int id, DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return luongDAO.LuongBacSi(id, firstDayOfMonth, lastDayOfMonth);
        }
        public void CapNhatLuong(LuongDTO luong)
        {
            luongDAO.CapNhatLuong(luong);
        }

        public LuongDTO LuongLeTan(int id, DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            return luongDAO.LuongLeTan(id, firstDayOfMonth, lastDayOfMonth);
        }

    }
}
