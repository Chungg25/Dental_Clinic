using Dental_Clinic.DAO.ThongKe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.BUS.ThongKe
{
    internal class ThongKeBus
    {
        private ThongKeDAO thongKeDAO;
        public ThongKeBus() { 
            thongKeDAO = new ThongKeDAO();
        }
        public float TienThuoc(DateTime ngay)
        {
            return thongKeDAO.TienThuoc(ngay);
        }
    }
}
