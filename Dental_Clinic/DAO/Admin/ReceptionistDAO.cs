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
    internal class ReceptionistDAO
    {
        public List<ReceptionistDTO> GetReceptionistList()
        {
            List<ReceptionistDTO> receptionistList = new List<ReceptionistDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetRepceptionistList", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReceptionistDTO doctor = new ReceptionistDTO
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
                            Status = Convert.ToInt32(reader["status"])
                        };
                        receptionistList.Add(doctor);
                    }
                }
                dbConnection.CloseConnection();
            }
            return receptionistList;
        }

        public ReceptionistDTO GetReceptionistInfo(int id)
        {
            ReceptionistDTO receptionist = new ReceptionistDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        receptionist = new ReceptionistDTO
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

        public void UpdateReceptionist(ReceptionistDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", receptionist.Id);
                cmd.Parameters.AddWithValue("@fullName", receptionist.Full_name);
                cmd.Parameters.AddWithValue("@citizenId", receptionist.Citizen_id);
                cmd.Parameters.AddWithValue("@phoneNumber", receptionist.Phone);
                cmd.Parameters.AddWithValue("@address", receptionist.Address);
                cmd.Parameters.AddWithValue("@gender", receptionist.Gender);
                cmd.Parameters.AddWithValue("@dob", receptionist.Dob);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", receptionist.Salary_coefficient);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public void AddReceptionist(ReceptionistDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddReceptionist", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", receptionist.Full_name);
                cmd.Parameters.AddWithValue("@citizenId", receptionist.Citizen_id);
                cmd.Parameters.AddWithValue("@phoneNumber", receptionist.Phone);
                cmd.Parameters.AddWithValue("@address", receptionist.Address);
                cmd.Parameters.AddWithValue("@gender", receptionist.Gender);
                cmd.Parameters.AddWithValue("@dob", receptionist.Dob);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", receptionist.Salary_coefficient);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    }
}
