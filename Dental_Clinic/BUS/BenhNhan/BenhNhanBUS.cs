using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.Patient
{
    internal class BenhNhanBUS
    {
        private BenhNhanDAO patientDAO;
        public BenhNhanBUS()
        {
            patientDAO = new BenhNhanDAO();
        }
        // Lấy danh sách bệnh nhân
        public List<BenhNhanDTO> LayDanhSachBenhNhan()
        {
            return patientDAO.LayDanhSachBenhNhan();
        }
        // Lấy thông tin bênh nhân
        public BenhNhanDTO LayThongTinBenhNhan(int id)
        {
            return patientDAO.LayThongTinBenhNhan(id);
        }
        // Cập nhật thông tin bệnh nhân
        public void CapNhatBenhNhan(BenhNhanDTO patientDTO)
        {
            patientDAO.CapNhatBenhNhan(patientDTO);
        }
        // Thêm bệnh nhân
        public void ThemBenhNhan(BenhNhanDTO patientDTO)
        {
            patientDAO.ThemBenhNhan(patientDTO);
        }
        // Lấy danh sách bệnh nhân của bác sĩ
        public List<BenhNhanDTO> LayDanhSachBenhNhanCuaBacSi(int id)
        {
            return patientDAO.LayDanhSachBenhNhanCuaBacSi(id);
        }
        public void ThemBenhNhan_BacSi(BenhNhanDTO patientDTO, int id)
        {
            patientDAO.ThemBenhNhan_BacSi(patientDTO, id);
        }
    }
}
