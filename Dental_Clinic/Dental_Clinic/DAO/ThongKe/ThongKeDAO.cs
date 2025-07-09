using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.ThongKe
{
    internal class ThongKeDAO
    {
        public float TienThuoc(DateTime ngay)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            float tongTienThuoc = 0;

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.LayTongTienThuocDaBanTrongThang(@ngay)", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ngay", ngay);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    tongTienThuoc = Convert.ToSingle(result);
                }
            }
            return tongTienThuoc;
        }
    }
}
