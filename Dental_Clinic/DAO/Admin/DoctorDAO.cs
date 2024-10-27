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
                            Role = reader["role"]?.ToString(),
                            Username = reader["username"]?.ToString(),
                            Password = reader["password"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            Salary_coefficient = Convert.ToSingle(reader["salary_coefficient"]),
                            Salary_id = Convert.ToInt32(reader["salary_id"]),
                            Specialization_name = reader["specialization_name"]?.ToString(),
                            Status = Convert.ToInt32(reader["status"])
                        };
                        doctorList.Add(doctor);
                    }
                }
                dbConnection.CloseConnection();
            }
            return doctorList;
        }

        public static void UpdateStatus(int userID)
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
            DoctorDTO doctor = null;
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetUserInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                            Role = reader["role"]?.ToString(),
                            Username = reader["username"]?.ToString(),
                            Password = reader["password"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            Salary_coefficient = Convert.ToSingle(reader["salary_coefficient"]),
                            Salary_id = Convert.ToInt32(reader["salary_id"]),
                            Status = Convert.ToInt32(reader["status"])
                        };
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
                cmd.Parameters.AddWithValue("@role", doctor.Role);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.Salary_coefficient);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public void DeleteDoctor(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("DeleteDoctor", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
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
                cmd.Parameters.AddWithValue("@role", doctor.Role);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.Salary_coefficient);
                cmd.Parameters.AddWithValue("@specializationId", GetSpecializationValue(doctor.Specialization_name));

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public int GetSpecializationValue(string specializationId)
        {
            int selectedValue;
            switch (specializationId)
            {
                case "Chữa răng và nội nha":
                    selectedValue = 1;
                    break;
                case "Nha chu":
                    selectedValue = 2;
                    break;
                case "Nhổ răng và tiểu phẫu":
                    selectedValue = 3;
                    break;
                case "Phục hình":
                    selectedValue = 4;
                    break;
                case "Răng trẻ em":
                    selectedValue = 5;
                    break;
                case "Tổng quát":
                    selectedValue = 6;
                    break;
                default:
                    selectedValue = 0; // Không có mục nào được chọn
                    break;
            }
            return selectedValue;
        }
    }
}
