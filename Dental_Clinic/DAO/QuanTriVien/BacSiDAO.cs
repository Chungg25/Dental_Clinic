using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Dental_Clinic.DAO.Admin
{
    internal class BacSiDAO
    {
        public List<BacSiDTO> LayDanhSachBacSi()
        {
            List<BacSiDTO> doctorList = new List<BacSiDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetDoctorList", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSiDTO doctor = new BacSiDTO
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
                                ChuyenNganh = reader["specialization_name"]?.ToString(),
                                TrangThai = Convert.ToInt32(reader["status"])
                            };
                            doctorList.Add(doctor);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi SQL
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                // Có thể ném ngoại lệ hoặc ghi log lỗi ở đây
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                Console.WriteLine($"Error: {ex.Message}");
                // Có thể ném ngoại lệ hoặc ghi log lỗi ở đây
            }
            finally
            {
                // Đảm bảo đóng kết nối trong mọi trường hợp
                dbConnection.CloseConnection();
            }

            return doctorList;
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

        public BacSiDTO LayThongTinBacSi(int id)
        {
            BacSiDTO doctor = new BacSiDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetUserInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        doctor = new BacSiDTO
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
                            TrangThai = Convert.ToInt32(reader["status"]),
                            ChuyenNganh = reader["specialization_name"]?.ToString()
                        };
                    }
                    else
                    {
                        throw new Exception($"Doctor with ID {id} not found."); // Ném ngoại lệ
                    }
                }
                dbConnection.CloseConnection();
            }
            return doctor;
        }

        public void CapNhatBacSi(BacSiDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateUserInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", doctor.Id);
                cmd.Parameters.AddWithValue("@fullName", doctor.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", doctor.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.SDT);
                cmd.Parameters.AddWithValue("@address", doctor.DiaChi);
                cmd.Parameters.AddWithValue("@gender", doctor.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", doctor.NgaySinh);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.HeSoLuong);
                cmd.Parameters.AddWithValue("@specializationID", ConvertSpecializationToId(doctor.ChuyenNganh));

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public int ConvertSpecializationToId(string specializationName)
        {
            // Danh sách các chuyên ngành
            string[] specializations = new string[]
            {
                "Nha chu",
                "Nhổ răng và tiểu phẫu",
                "Phục hình",
                "Chữa răng và nội nha",
                "Răng trẻ em",
                "Tổng quát"
            };

            // Tìm chỉ số của chuyên ngành trong danh sách
            for (int i = 0; i < specializations.Length; i++)
            {
                if (specializations[i] == specializationName)
                {
                    return i + 1;
                }
            }

            return -1;
        }


        public void ThemBacSi(BacSiDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddDoctor", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", doctor.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", doctor.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.SDT);
                cmd.Parameters.AddWithValue("@address", doctor.DiaChi);
                cmd.Parameters.AddWithValue("@gender", doctor.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", doctor.NgaySinh);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.HeSoLuong);
                cmd.Parameters.AddWithValue("@specializationID", ConvertSpecializationNameToAdjustedId(doctor.ChuyenNganh));
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public int ConvertSpecializationNameToAdjustedId(string specialization_name)
        {
            int specializationId;
            if (specialization_name == "0")
            {
                specializationId = 1; // Chuyển "0" thành 1
            }
            else if (specialization_name == "1")
            {
                specializationId = 2; // Chuyển "1" thành 2
            }
            else if (specialization_name == "2")
            {
                specializationId = 3; // Chuyển "2" thành 3
            }
            else if (specialization_name == "3")
            {
                specializationId = 4; // Chuyển "3" thành 4
            }
            else if (specialization_name == "4")
            {
                specializationId = 5; // Chuyển "4" thành 5
            }
            else if (specialization_name == "5")
            {
                specializationId = 6; // Chuyển "5" thành 6
            }
            else
            {
                specializationId = -1; 
            }
            return specializationId;
        }

    }
}
