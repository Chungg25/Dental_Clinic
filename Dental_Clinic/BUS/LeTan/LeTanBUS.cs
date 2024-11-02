using Dental_Clinic.DAO.LeTan;
using Dental_Clinic.DTO.LichHen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.LeTan
{
    public class LeTanBUS
    {
        private LeTanDAO _leTanDAO;

        public LeTanBUS()
        {
            this._leTanDAO = new LeTanDAO();
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<LichHenDTO> LayDanhSachLichHenTheoNgay(string ngayHienTai)
        {
            return _leTanDAO.LayDanhSachLichHenTheoNgay(ngayHienTai);
        }
    }
}
