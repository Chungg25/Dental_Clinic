using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.Login
{
    public class QuenMatKhauDAO
    {
        private DatabaseConnection dbConnection;

        public QuenMatKhauDAO()
        {
            try { dbConnection = new DatabaseConnection(); }
            catch (Exception ex) { throw; }
        }
        // Kiểm tra username có tồn tại trong database không
        public bool KiemTraTenDangNhap(string username)
        {
            string query = "KiemTraUserName";
            using (SqlCommand cmd = new SqlCommand(query, dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // Kiểm tra email có tồn tại trong database không
        public bool KiemTraMail(string email)
        {
            string query = "KiemTraEmail";
            using (SqlCommand cmd = new SqlCommand(query, dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // Lấy mật khẩu từ mail và username
        public string MatKhau(string email, string username)
        {
            string query = "LayThongTinEmailVaUserName";
            using (SqlCommand cmd = new SqlCommand(query, dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@username", username);
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}
