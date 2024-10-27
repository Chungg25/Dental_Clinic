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
        private static string stringConnection = "Data Source=DESKTOP-NTCHRQN\\SQLEXPRESS02;Initial Catalog=DentalClinic;Integrated Security=True";
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

        public bool TestConnection()
        {
            try
            {
                conn.Open(); // Mở kết nối
                return true; // Nếu mở thành công, trả về true
            }
            catch (Exception ex)
            {
                // Có thể ghi lại hoặc xử lý ngoại lệ ở đây
                return false; // Nếu có lỗi, trả về false
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close(); // Đóng kết nối nếu nó đang mở
                }
            }
        }
    }
}
