using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.LichLamViec;

namespace Dental_Clinic.DAO.LichLamViec
{
    internal class LichLamViecDAO
    {
        public List<LichLamViecDTO> DanhSachLichLamViecBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            List<LichLamViecDTO> lichLamViecBacSiList = new List<LichLamViecDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("DanhSachLichLamViecBacSi", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LichLamViecDTO lichLamViecBacSi = new LichLamViecDTO
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                HoTen = reader["ho_ten"].ToString() ?? "",
                                GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                                Email = reader["email"]?.ToString() ?? "",
                                ChuyenNganh = reader["ten_chuyen_mon"]?.ToString() ?? "",
                                SoCa = Convert.ToInt32(reader["so_ca"])
                            };
                            lichLamViecBacSiList.Add(lichLamViecBacSi);
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

            return lichLamViecBacSiList;
        }

        public List<LichLamViecDTO> LichLamViecBacSi(int id, DateTime day)
        {

            DateTime firstDayOfMonth = new DateTime(day.Year, day.Month, 1);
            DateTime lastDayOfMonth = new DateTime(day.Year, day.Month, DateTime.DaysInMonth(day.Year, day.Month));
            List<LichLamViecDTO> lichLamViecBacSiList = new List<LichLamViecDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("LichLamViecBacSiTheoID", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LichLamViecDTO lichLamViecBacSi = new LichLamViecDTO
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                HoTen = reader["ho_ten"].ToString() ?? "",
                                Ca = Convert.ToInt32(reader["ca"]),
                                Ngay = reader["ngay"].ToString()
                            };
                            lichLamViecBacSiList.Add(lichLamViecBacSi);
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

            return lichLamViecBacSiList;
        }
    }
}
