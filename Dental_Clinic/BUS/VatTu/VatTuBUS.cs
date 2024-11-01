using Dental_Clinic.DAO.VatTu;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.VatTu
{
    internal class VatTuBUS
    {
        private VatTuDAO vatTuDAO;
        public VatTuBUS()
        {
            vatTuDAO = new VatTuDAO();
        }
        public List<VatTuDTO> DanhSachThuoc(int id)
        {
            return vatTuDAO.DanhSachThuoc(id);
        }

        public List<VatTuDTO> DanhSachVatTu(int id)
        {
            return vatTuDAO.DanhSachVatTu(id);
        }
    }
}
