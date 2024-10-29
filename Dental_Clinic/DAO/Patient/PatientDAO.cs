using Dental_Clinic.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.Patient;

namespace Dental_Clinic.DAO.Patient
{
    internal class PatientDAO
    {
        public List<PatientDTO> GetPatientList()
        {
            List<PatientDTO> patientList = new List<PatientDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetPatienttListForAdmin", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PatientDTO patient = new PatientDTO
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Full_name = reader["full_name"].ToString(),
                                Phone = reader["phone_number"]?.ToString(),
                                Address = reader["address"]?.ToString(),
                                Gender = Convert.ToBoolean(reader["gender"]),
                                Age = Convert.ToInt32(reader["age"])
                            };
                            patientList.Add(patient);
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

            return patientList;
        }

        public PatientDTO GetPatientInfo(int id)
        {
            PatientDTO patient = new PatientDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("GetPatientInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patient = new PatientDTO
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Full_name = reader["full_name"].ToString(),
                            Phone = reader["phone_number"]?.ToString(),
                            Address = reader["address"]?.ToString(),
                            Gender = Convert.ToBoolean(reader["gender"]),
                            Age = Convert.ToInt32(reader["age"])
                        };
                    }
                }
            }
            return patient;
        }

        public void UpdatePatient(PatientDTO patient)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdatePatientInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", patient.Id);
                cmd.Parameters.AddWithValue("@fullName", patient.Full_name);
                cmd.Parameters.AddWithValue("@phoneNumber", patient.Phone);
                cmd.Parameters.AddWithValue("@address", patient.Address);
                cmd.Parameters.AddWithValue("@gender", patient.Gender);
                cmd.Parameters.AddWithValue("@age", patient.Age);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    }
}
