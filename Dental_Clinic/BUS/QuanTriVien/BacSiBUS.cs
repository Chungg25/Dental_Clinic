using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Admin
{
    internal class BacSiBUS
    {
        private BacSiDAO doctorDAO;
        public BacSiBUS()
        {
            doctorDAO = new BacSiDAO();
        }
        public List<BacSiDTO> LayDanhSachBacSi()
        {
            BacSiDAO doctorDAO = new BacSiDAO();
            return doctorDAO.LayDanhSachBacSi();
        }

        public void CapNhatTrangThai(int userID)
        {
            doctorDAO.CapNhatTrangThai(userID);
        }
        public BacSiDTO LayThongTinBacSi(int userID)
        {
            return doctorDAO.LayThongTinBacSi(userID);
        }
        public void CapNhatBacSi(BacSiDTO doctorDTO)
        {
            doctorDAO.CapNhatBacSi(doctorDTO);
        }
        public void ThemBacSi(BacSiDTO doctorDTO)
        {
            doctorDAO.ThemBacSi(doctorDTO);
        }
    }
}
