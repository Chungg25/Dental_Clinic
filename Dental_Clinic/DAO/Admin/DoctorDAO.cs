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
    internal class DoctorDAO
    {
        public List<DoctorDTO> GetDoctorList()
        {
            List<DoctorDTO> doctorList = new List<DoctorDTO>();
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
                            DoctorDTO doctor = new DoctorDTO
                            {
                                Id = Convert.ToInt32(reader["user_id"]),
                                Full_name = reader["full_name"].ToString(),
                                Citizen_id = reader["citizen_id"]?.ToString(),
                                Phone = reader["phone_number"]?.ToString(),
                                Address = reader["address"]?.ToString(),
                                Gender = Convert.ToBoolean(reader["gender"]),
                                Dob = Convert.ToDateTime(reader["dob"]),
                                Username = reader["username"]?.ToString(),
                                Password = reader["password"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                Salary_coefficient = Convert.ToSingle(reader["salary_coefficient"]),
                                Specialization_name = reader["specialization_name"]?.ToString(),
                                Status = Convert.ToInt32(reader["status"])
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


        public void UpdateStatus(int userID)
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

        public DoctorDTO GetDoctorInfo(int id)
        {
            DoctorDTO doctor = new DoctorDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetUserInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        doctor = new DoctorDTO
                        {
                            Id = Convert.ToInt32(reader["user_id"]),
                            Full_name = reader["full_name"].ToString(),
                            Citizen_id = reader["citizen_id"]?.ToString(),
                            Phone = reader["phone_number"]?.ToString(),
                            Address = reader["address"]?.ToString(),
                            Gender = Convert.ToBoolean(reader["gender"]),
                            Dob = Convert.ToDateTime(reader["dob"]),
                            Username = reader["username"]?.ToString(),
                            Password = reader["password"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            Salary_coefficient = Convert.ToSingle(reader["salary_coefficient"]),
                            Status = Convert.ToInt32(reader["status"]),
                            Specialization_name = reader["specialization_name"]?.ToString()
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

        public void UpdateDoctor(DoctorDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateUserInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", doctor.Id);
                cmd.Parameters.AddWithValue("@fullName", doctor.Full_name);
                cmd.Parameters.AddWithValue("@citizenId", doctor.Citizen_id);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.Phone);
                cmd.Parameters.AddWithValue("@address", doctor.Address);
                cmd.Parameters.AddWithValue("@gender", doctor.Gender);
                cmd.Parameters.AddWithValue("@dob", doctor.Dob);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.Salary_coefficient);
                cmd.Parameters.AddWithValue("@specializationID", ConvertSpecializationToId(doctor.Specialization_name));

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


        public void AddDoctor(DoctorDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddDoctor", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", doctor.Full_name);
                cmd.Parameters.AddWithValue("@citizenId", doctor.Citizen_id);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.Phone);
                cmd.Parameters.AddWithValue("@address", doctor.Address);
                cmd.Parameters.AddWithValue("@gender", doctor.Gender);
                cmd.Parameters.AddWithValue("@dob", doctor.Dob);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.Salary_coefficient);

                cmd.Parameters.AddWithValue("@specializationId", ConvertSpecializationNameToAdjustedId(doctor.Specialization_name));
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
