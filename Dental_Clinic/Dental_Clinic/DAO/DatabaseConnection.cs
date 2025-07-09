using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace Dental_Clinic.DAO
{
    internal class DatabaseConnection
    {
        private SqlConnection conn;
        private static string stringConnection = "Data Source=.;" +
            "                                       Initial Catalog=DentalClinic;" +
            "                                       Integrated Security=True";
        public DatabaseConnection()
        {
            try
            {
                conn = new SqlConnection(stringConnection);
                conn.Open();
            }
            catch (SqlException ex)
            {
                // Handle exception (e.g., log the error, rethrow, etc.)
                throw new Exception("Lỗi kết nối cơ sở dữ liệu!" + ex.Message);
            }
        }

        public SqlConnection Conn
        {
            get { return conn; }
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close(); // Đóng kết nối
            }
        }
    }
}