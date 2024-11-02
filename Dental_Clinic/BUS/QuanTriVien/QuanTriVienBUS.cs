using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LeTan;

namespace Dental_Clinic.BUS.Admin
{
    internal class QuanTriVienBUS
    {
        private QuanTriVienDAO quanTriVienDAO;
        public QuanTriVienBUS()
        {
            quanTriVienDAO = new QuanTriVienDAO();
        }
        public int SoLuongBacSi()
        {
            return quanTriVienDAO.SoLuongBacSi();
        }
        public int SoLuongBenhNhan()
        {
            return quanTriVienDAO.SoLuongBenhNhan();
        }
        public int TongLuong()
        {
            return quanTriVienDAO.TongLuong();
        }

        public List<BacSiDTO> LayDanhSachBacSi()
        {
            return quanTriVienDAO.LayDanhSachBacSi();
        }

        public void CapNhatTrangThai(int userID)
        {
            quanTriVienDAO.CapNhatTrangThai(userID);
        }
        public BacSiDTO LayThongTinBacSi(int userID)
        {
            return quanTriVienDAO.LayThongTinBacSi(userID);
        }
        public void CapNhatBacSi(BacSiDTO doctorDTO)
        {
            quanTriVienDAO.CapNhatBacSi(doctorDTO);
        }
        public void ThemBacSi(BacSiDTO doctorDTO)
        {
            quanTriVienDAO.ThemBacSi(doctorDTO);
        }

        public List<LeTanDTO> LayDanhSachLeTan()
        {
            return quanTriVienDAO.LayDanhSachLeTan();
        }

        public LeTanDTO LayThongTinLeTan(int id)
        {
            return quanTriVienDAO.LayThongTinLeTan(id);
        }
        public void CapNhatLeTan(LeTanDTO leTanDTO)
        {
            quanTriVienDAO.CapNhatLeTan(leTanDTO);
        }
        public void ThemLeTan(LeTanDTO leTanDTO)
        {
            quanTriVienDAO.ThemLeTan(leTanDTO);
        }
    }
}
