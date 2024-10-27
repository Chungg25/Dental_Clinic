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
    internal class AdminDAO
    {
       
        public int DoctorCount()
        {
            
            int doctorCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CountDoctors()", dbConnection.Conn))
            {
                doctorCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return doctorCount; // Trả về số lượng bác sĩ
        }

        public int PatientCount()
        {
            int patientCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CountPatient()", dbConnection.Conn))
            {
                patientCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return patientCount; // Trả về số lượng bệnh nhân
        }

        public int RevenueCount()
        {
            int revenueCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.CountRevenue()", dbConnection.Conn))
            {
                revenueCount = (int)cmd.ExecuteScalar(); 
                dbConnection.CloseConnection();
            }
            return revenueCount;
        }
    }
}
