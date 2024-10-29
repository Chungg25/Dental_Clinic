using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.Admin
{
    internal class LeTanDAO
    {
        public List<LeTanDTO> LayDanhSachLeTan()
        {
            List<LeTanDTO> receptionistList = new List<LeTanDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetRepceptionistList", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LeTanDTO doctor = new LeTanDTO
                        {
                            Id = Convert.ToInt32(reader["user_id"]),
                            HoVaTen = reader["full_name"].ToString(),
                            CCCD = reader["citizen_id"]?.ToString(),
                            SDT = reader["phone_number"]?.ToString(),
                            DiaChi = reader["address"]?.ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gender"]),
                            NgaySinh = Convert.ToDateTime(reader["dob"]),
                            TenDangNhap = reader["username"]?.ToString(),
                            MatKhau = reader["password"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            HeSoLuong = Convert.ToSingle(reader["salary_coefficient"]),
                            TrangThai = Convert.ToInt32(reader["status"])
                        };
                        receptionistList.Add(doctor);
                    }
                }
                dbConnection.CloseConnection();
            }
            return receptionistList;
        }

        public LeTanDTO LayThongTinLeTan(int id)
        {
            LeTanDTO receptionist = new LeTanDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        receptionist = new LeTanDTO
                        {
                            Id = Convert.ToInt32(reader["user_id"]),
                            HoVaTen = reader["full_name"].ToString(),
                            CCCD = reader["citizen_id"]?.ToString(),
                            SDT = reader["phone_number"]?.ToString(),
                            DiaChi = reader["address"]?.ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gender"]),
                            NgaySinh = Convert.ToDateTime(reader["dob"]),
                            TenDangNhap = reader["username"]?.ToString(),
                            MatKhau = reader["password"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            HeSoLuong = Convert.ToSingle(reader["salary_coefficient"]),
                            TrangThai = Convert.ToInt32(reader["status"])
                        };
                    }
                    else
                    {
                        throw new Exception($"Receptionist with ID {id} not found."); // Ném ngoại lệ
                    }
                }
                dbConnection.CloseConnection();
            }
            return receptionist;
        }

        public void CapNhatTrangThai(int userID)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateStatus", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userID);
                cmd.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }

        public void CapNhatLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", receptionist.Id);
                cmd.Parameters.AddWithValue("@fullName", receptionist.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", receptionist.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", receptionist.SDT);
                cmd.Parameters.AddWithValue("@address", receptionist.DiaChi);
                cmd.Parameters.AddWithValue("@gender", receptionist.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", receptionist.NgaySinh);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", receptionist.HeSoLuong);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public void ThemLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddReceptionist", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", receptionist.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", receptionist.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", receptionist.SDT);
                cmd.Parameters.AddWithValue("@address", receptionist.DiaChi);
                cmd.Parameters.AddWithValue("@gender", receptionist.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", receptionist.NgaySinh);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", receptionist.HeSoLuong);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    }
}
