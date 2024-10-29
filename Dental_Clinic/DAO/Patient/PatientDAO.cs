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
        public List<PatientDTO> LayDanhSachBenhNhan()
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
                                HoVaTen = reader["full_name"].ToString(),
                                SDT = reader["phone_number"]?.ToString(),
                                DiaChi = reader["address"]?.ToString(),
                                GioiTinh = Convert.ToBoolean(reader["gender"]),
                                Tuoi = Convert.ToInt32(reader["age"])
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

        public PatientDTO LayThongTinBenhNhan(int id)
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
                            HoVaTen = reader["full_name"].ToString(),
                            SDT = reader["phone_number"]?.ToString(),
                            DiaChi = reader["address"]?.ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gender"]),
                            Tuoi = Convert.ToInt32(reader["age"])
                        };
                    }
                }
            }
            return patient;
        }

        public void CapNhatBenhNhan(PatientDTO patient)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdatePatientInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", patient.Id);
                cmd.Parameters.AddWithValue("@fullName", patient.HoVaTen);
                cmd.Parameters.AddWithValue("@phoneNumber", patient.SDT);
                cmd.Parameters.AddWithValue("@address", patient.DiaChi);
                cmd.Parameters.AddWithValue("@gender", patient.GioiTinh);
                cmd.Parameters.AddWithValue("@age", patient.Tuoi);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        public void ThemBenhNhan(PatientDTO patient)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddPatient", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", patient.HoVaTen);
                cmd.Parameters.AddWithValue("@phoneNumber", patient.SDT);
                cmd.Parameters.AddWithValue("@address", patient.DiaChi);
                cmd.Parameters.AddWithValue("@gender", patient.GioiTinh);
                cmd.Parameters.AddWithValue("@age", patient.Tuoi);
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    } 
}
