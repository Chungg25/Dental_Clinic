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

        public List<VatTuDTO> DanhSachDichVu()
        {
            return vatTuDAO.DanhSachDichVu();
        }

        public VatTuDTO ThongTinThuoc(int id)
        {
            return vatTuDAO.ThongTinThuoc(id);
        }
        public void CapNhatThuoc(VatTuDTO thuoc)
        {
            vatTuDAO.CapNhatThongTinThuoc(thuoc);
        }

        public VatTuDTO ThongTinVatTu(int id)
        {
            return vatTuDAO.ThongTinVatTu(id);
        }
        public void CapNhatVatTu(VatTuDTO vatTu)
        {
            vatTuDAO.CapNhatThongTinVatTu(vatTu);
        }
        public VatTuDTO ThongTinDichVu(int id)
        {
            return vatTuDAO.ThongTinDichVu(id);
        }
        public void CapNhatDichVu(VatTuDTO dichVu)
        {
            vatTuDAO.CapNhatThongTinDichVu(dichVu);
        }
        public void ThemDichVu(VatTuDTO dichVu)
        {
            vatTuDAO.ThemDichVu(dichVu);
        }
        public void ThemVatTu(VatTuDTO vatTu)
        {
            vatTuDAO.ThemVatTu(vatTu);
        }
        public void ThemThuoc(VatTuDTO thuoc)
        {
            vatTuDAO.ThemThuoc(thuoc);
        }
        public void XoaHang(int id)
        {
            vatTuDAO.XoaHang(id);
        }
        public void XoaDichVu(int id)
        {
            vatTuDAO.XoaDichVu(id);
        }
    }
}
