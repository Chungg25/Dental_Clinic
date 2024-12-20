﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.LichLamViec;
using Dental_Clinic.DTO.ChamCong;

namespace Dental_Clinic.DAO.LichLamViec
{
    internal class LichLamViecDAO
    {
        //Bác sĩ
        public List<LichLamViecDTO> DanhSachLichLamViecBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            List<LichLamViecDTO> lichLamViecBacSiList = new List<LichLamViecDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            int doctorCount = 0;

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongBacSi()", dbConnection.Conn))
            {
                doctorCount = (int)cmd.ExecuteScalar();
            }

            try
            {
                
                using (SqlCommand cmd = new SqlCommand("DanhSachLichLamViecBacSi", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
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
                                    SoCa = Convert.ToInt32(reader["so_ca"]),
                                };
                                lichLamViecBacSiList.Add(lichLamViecBacSi);
                            }
                        }
                    }
                    if (lichLamViecBacSiList.Count < doctorCount)
                    {
                        using (SqlCommand cmdNoSchedule = new SqlCommand("DanhSachLichLamViecBacSiKhongNgayLam", dbConnection.Conn))
                        {
                            cmdNoSchedule.CommandType = CommandType.StoredProcedure;

                            using (SqlDataReader readerNoSchedule = cmdNoSchedule.ExecuteReader())
                            {
                                while (readerNoSchedule.Read())
                                {
                                    int maNguoiDung = Convert.ToInt32(readerNoSchedule["ma_nguoi_dung"]);
                                    if (!lichLamViecBacSiList.Any(l => l.MaNguoiDung == maNguoiDung))
                                    {
                                        LichLamViecDTO lichLamViecBacSi = new LichLamViecDTO
                                        {
                                            MaNguoiDung = maNguoiDung,
                                            HoTen = readerNoSchedule["ho_ten"].ToString() ?? "",
                                            GioiTinh = Convert.ToBoolean(readerNoSchedule["gioi_tinh"]),
                                            Email = readerNoSchedule["email"]?.ToString() ?? "",
                                            ChuyenNganh = readerNoSchedule["ten_chuyen_mon"]?.ToString() ?? "",
                                            SoCa = 0,
                                        };
                                        lichLamViecBacSiList.Add(lichLamViecBacSi);
                                    }
                                }
                            }
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

        public List<ChamCongDTO> LichLamViec(int id, DateTime day)
        {

            DateTime firstDayOfMonth = new DateTime(day.Year, day.Month, 1);
            DateTime lastDayOfMonth = new DateTime(day.Year, day.Month, DateTime.DaysInMonth(day.Year, day.Month));
            List<ChamCongDTO> chamCongs = new List<ChamCongDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("LichLamViec", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChamCongDTO chamCong = new ChamCongDTO
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                HoTen = reader["ho_ten"].ToString() ?? "",
                                Ca = Convert.ToInt32(reader["ca"]),
                                Ngay = reader["ngay"].ToString(),
                                TrangThai = Convert.ToInt32(reader["LamViecDungGio"]),
                            };
                            chamCongs.Add(chamCong);
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

            return chamCongs;
        }

        public ChamCongDTO ChiTietLamViec(int id, DateTime day)
        {
            ChamCongDTO ChiTietLamViec = new ChamCongDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();
            DateOnly NgayLamViec = new DateOnly(day.Year, day.Month, day.Day);
            string ThayDoiDinhDangNgay = NgayLamViec.ToString("yyyy-MM-dd");
            try
            {
                using (SqlCommand cmd = new SqlCommand("ChiTietCaLam", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@day", ThayDoiDinhDangNgay);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows) 
                        {
                            while (reader.Read())
                            {
                                
                                ChiTietLamViec = new ChamCongDTO
                                {
                                    MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                    HoTen = reader["ho_ten"].ToString() ?? "",
                                    GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                                    Ngay = reader["ngay"].ToString(),
                                    Email = reader["email"]?.ToString() ?? "",
                                    GioVao = reader["gio_vao"].ToString(),
                                    GioRa = reader["gio_ra"].ToString(),
                                    GhiChu = reader["ghi_chu"].ToString(),
                                    SĐT = reader["so_dien_thoai"].ToString(),
                                    Ca = Convert.ToInt32(reader["ca"]),
                                    DiaChi = reader["dia_chi"].ToString(),
                                };
                            }
                        }  
                        else
                        {
                            reader.Close();
                            using (SqlCommand cmdNoSchedule = new SqlCommand("ThongTinLamViecChuaChamCong", dbConnection.Conn))
                            {
                                cmdNoSchedule.CommandType = CommandType.StoredProcedure;
                                cmdNoSchedule.Parameters.AddWithValue("@userId", id);
                                cmdNoSchedule.Parameters.AddWithValue("@ngay", ThayDoiDinhDangNgay);

                                using (SqlDataReader readerNoSchedule = cmdNoSchedule.ExecuteReader())
                                {
                                    while (readerNoSchedule.Read())
                                    {
                                        ChiTietLamViec = new ChamCongDTO
                                        {
                                            MaNguoiDung = Convert.ToInt32(readerNoSchedule["ma_nguoi_dung"]),
                                            HoTen = readerNoSchedule["ho_ten"].ToString() ?? "",
                                            GioiTinh = Convert.ToBoolean(readerNoSchedule["gioi_tinh"]),
                                            Email = readerNoSchedule["email"]?.ToString() ?? "",
                                            SĐT = readerNoSchedule["so_dien_thoai"].ToString(),
                                            DiaChi = readerNoSchedule["dia_chi"].ToString(),
                                            Ca = Convert.ToInt32(readerNoSchedule["ca"])
                                        };
                                    }
                                }
                            }
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

            return ChiTietLamViec;
        }

        public void ThemLichLamViec(int id, int ca, DateTime ngay)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("ThemLichLamViec", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ca", ca);
                    cmd.Parameters.AddWithValue("@day", ngay);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL errors
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                // Optionally, log the error or rethrow the exception
            }
            catch (Exception ex)
            {
                // Handle other errors
                Console.WriteLine($"Error: {ex.Message}");
                // Optionally, log the error or rethrow the exception
            }
        }

        public void XoaLichLamViec(int id, DateTime ngay)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("XoaLichLamViec", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@day", ngay);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL errors
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                // Optionally, log the error or rethrow the exception
            }
            catch (Exception ex)
            {
                // Handle other errors
                Console.WriteLine($"Error: {ex.Message}");
                // Optionally, log the error or rethrow the exception
            }
        }




        //Lễ tân
        public List<LichLamViecDTO> DanhSachLichLamViecLeTan(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            List<LichLamViecDTO> lichLamViecBacSiList = new List<LichLamViecDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            int soLuongLeTan = 0;

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongLeTan()", dbConnection.Conn))
            {
                soLuongLeTan = (int)cmd.ExecuteScalar();
            }

            try
            {

                using (SqlCommand cmd = new SqlCommand("DanhSachLichLamViecLeTan", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LichLamViecDTO lichLamViecBacSi = new LichLamViecDTO
                                {
                                    MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                    HoTen = reader["ho_ten"].ToString() ?? "",
                                    GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                                    Email = reader["email"]?.ToString() ?? "",
                                    SoCa = Convert.ToInt32(reader["so_ca"]),
                                };
                                lichLamViecBacSiList.Add(lichLamViecBacSi);
                            }
                        }
                    }
                    if (lichLamViecBacSiList.Count < soLuongLeTan)
                    {
                        using (SqlCommand cmdNoSchedule = new SqlCommand("DanhSachLichLamViecLeTanKhongNgayLam", dbConnection.Conn))
                        {
                            cmdNoSchedule.CommandType = CommandType.StoredProcedure;

                            using (SqlDataReader readerNoSchedule = cmdNoSchedule.ExecuteReader())
                            {
                                while (readerNoSchedule.Read())
                                {
                                    int maNguoiDung = Convert.ToInt32(readerNoSchedule["ma_nguoi_dung"]);
                                    if (!lichLamViecBacSiList.Any(l => l.MaNguoiDung == maNguoiDung))
                                    {
                                        LichLamViecDTO lichLamViecBacSi = new LichLamViecDTO
                                        {
                                            MaNguoiDung = maNguoiDung,
                                            HoTen = readerNoSchedule["ho_ten"].ToString() ?? "",
                                            GioiTinh = Convert.ToBoolean(readerNoSchedule["gioi_tinh"]),
                                            Email = readerNoSchedule["email"]?.ToString() ?? "",
                                            SoCa = 0,
                                        };
                                        lichLamViecBacSiList.Add(lichLamViecBacSi);
                                    }
                                }
                            }
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

        public List<ChamCongDTO> LichLamViecLeTan(int id, DateTime day)
        {

            DateTime firstDayOfMonth = new DateTime(day.Year, day.Month, 1);
            DateTime lastDayOfMonth = new DateTime(day.Year, day.Month, DateTime.DaysInMonth(day.Year, day.Month));
            List<ChamCongDTO> chamCongBacSiList = new List<ChamCongDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("LichLamViecLeTanTheoID", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChamCongDTO chamCongBacSi = new ChamCongDTO
                            {
                                MaNguoiDung = Convert.ToInt32(reader["ma_nguoi_dung"]),
                                HoTen = reader["ho_ten"].ToString() ?? "",
                                Ca = Convert.ToInt32(reader["ca"]),
                                Ngay = reader["ngay"].ToString(),
                                TrangThai = Convert.ToInt32(reader["LamViecDungGio"]),
                            };
                            chamCongBacSiList.Add(chamCongBacSi);
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

            return chamCongBacSiList;
        }
    }
}
