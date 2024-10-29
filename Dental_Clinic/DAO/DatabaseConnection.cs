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
        private static string stringConnection = "Data Source=NGUYENN\\NGUYEN;" +
            "                                       Initial Catalog=DentalClinic;" +
            "                                       Integrated Security=True";
        public DatabaseConnection()
        {
            conn = new SqlConnection(stringConnection);
            conn.Open();
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