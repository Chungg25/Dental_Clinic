using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.Admin
{
    internal class QuanTriVienDAO
    {
        // Hàm lấy số lượng bác sĩ
        public int SoLuongBacSi()
        {
            
            int doctorCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongBacSi()", dbConnection.Conn))
            {
                doctorCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return doctorCount; // Trả về số lượng bác sĩ
        }
        // Hàm lấy số lượng bệnh nhân
        public int SoLuongBenhNhan()
        {
            int patientCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongBenhNhan()", dbConnection.Conn))
            {
                patientCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return patientCount; // Trả về số lượng bệnh nhân
        }
        // Tổng lương
        public int TongLuong()
        {
            int revenueCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.TongDoanhThu()", dbConnection.Conn))
            {
                revenueCount = (int)cmd.ExecuteScalar(); 
                dbConnection.CloseConnection();
            }
            return revenueCount;
        }
    }
}
