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
    internal class BenhNhanDAO
    {
        public List<BenhNhanDTO> LayDanhSachBenhNhan()
        {
            List<BenhNhanDTO> patientList = new List<BenhNhanDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("DanhSachBenhNhan", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhanDTO patient = new BenhNhanDTO
                            {
                                Id = Convert.ToInt32(reader["ma_benh_nhan"]),
                                HoVaTen = reader["ho_ten"].ToString() ?? "",
                                SDT = reader["so_dien_thoai"]?.ToString() ?? "",
                                DiaChi = reader["dia_chi"]?.ToString() ?? "",
                                GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                                Tuoi = Convert.ToInt32(reader["tuoi"])
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
        // Hàm lấy thông tin bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhan(int id)
        {
            BenhNhanDTO patient = new BenhNhanDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("ThongTinBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maBenhNhan", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patient = new BenhNhanDTO
                        {
                            Id = Convert.ToInt32(reader["ma_benh_nhan"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? "",
                            SDT = reader["so_dien_thoai"]?.ToString() ?? "",
                            DiaChi = reader["dia_chi"]?.ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Tuoi = Convert.ToInt32(reader["tuoi"])
                        };
                    }
                }
            }
            return patient;
        }

        public void CapNhatBenhNhan(BenhNhanDTO patient)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@maBenhNhan", patient.Id);
                cmd.Parameters.AddWithValue("@hoTen", patient.HoVaTen);
                cmd.Parameters.AddWithValue("@soDienThoai", patient.SDT);
                cmd.Parameters.AddWithValue("@diaChi", patient.DiaChi);
                cmd.Parameters.AddWithValue("@gioiTinh", patient.GioiTinh);
                cmd.Parameters.AddWithValue("@tuoi", patient.Tuoi);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        public void ThemBenhNhan(BenhNhanDTO patient)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("ThemBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@hoTen", patient.HoVaTen);
                cmd.Parameters.AddWithValue("@soDienThoai", patient.SDT);
                cmd.Parameters.AddWithValue("@diaChi", patient.DiaChi);
                cmd.Parameters.AddWithValue("@gioiTinh", patient.GioiTinh);
                cmd.Parameters.AddWithValue("@tuoi", patient.Tuoi);
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    } 
}
