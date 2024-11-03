using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.Luong;
using Dental_Clinic.DTO.LeTan;

namespace Dental_Clinic.DAO.Luong
{
    internal class LuongDAO
    {
        public List<LuongDTO> DanhSachLuongBacSi(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<LuongDTO> danhSachLuong = new List<LuongDTO>();

            using (SqlCommand cmd = new SqlCommand("DanhSachLichLamViecBacSiDeTinhLuong", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LuongDTO luongBacSi = new LuongDTO
                        {
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            Ten = reader["ho_ten"].ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Email = reader["email"]?.ToString() ?? "",
                            TenChuyenNganh = reader["ten_chuyen_mon"]?.ToString() ?? "",
                            LuongCoBan = Convert.ToSingle(reader["luong_co_ban"]),
                            Thuong = Convert.ToSingle(reader["thuong"]),
                            Phat = Convert.ToSingle(reader["phat"]),
                            PhuCap = Convert.ToSingle(reader["phu_cap"]),
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            SoCa = Convert.ToInt32(reader["so_ca"])
                        };
                        danhSachLuong.Add(luongBacSi);
                    }
                }
            }
            return danhSachLuong;
        }

        public List<LuongDTO> DanhSachLuongLeTan(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<LuongDTO> danhSachLuong = new List<LuongDTO>();

            using (SqlCommand cmd = new SqlCommand("DanhSachLichLamViecLeTanDeTinhLuong", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LuongDTO luongLeTan = new LuongDTO
                        {
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            Ten = reader["ho_ten"].ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Email = reader["email"]?.ToString() ?? "",
                            LuongCoBan = Convert.ToSingle(reader["luong_co_ban"]),
                            Thuong = Convert.ToSingle(reader["thuong"]),
                            Phat = Convert.ToSingle(reader["phat"]),
                            PhuCap = Convert.ToSingle(reader["phu_cap"]),
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            SoCa = Convert.ToInt32(reader["so_ca"])
                        };
                        danhSachLuong.Add(luongLeTan);
                    }
                }
            }
            return danhSachLuong;
        }

        public LuongDTO LuongBacSi(int id, DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            LuongDTO luongBacSi = new LuongDTO();

            using (SqlCommand cmd = new SqlCommand("LichLamViecChiTietBacSi", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        luongBacSi = new LuongDTO
                        {
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            Ten = reader["ho_ten"].ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Email = reader["email"]?.ToString() ?? "",
                            TenChuyenNganh = reader["ten_chuyen_mon"]?.ToString() ?? "",
                            LuongCoBan = Convert.ToSingle(reader["luong_co_ban"]),
                            Thuong = Convert.ToSingle(reader["thuong"]),
                            Phat = Convert.ToSingle(reader["phat"]),
                            PhuCap = Convert.ToSingle(reader["phu_cap"]),
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            SoCa = Convert.ToInt32(reader["so_ca"])
                        };
                    }
                }
            }
            return luongBacSi;
        }

        public void CapNhatLuong(LuongDTO luong)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatLuong", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@Id", luong.Id);
                cmd.Parameters.AddWithValue("@heSoLuong", luong.HeSoLuong);
                cmd.Parameters.AddWithValue("@luongCoBan", luong.LuongCoBan);
                cmd.Parameters.AddWithValue("@thuong", luong.Thuong);
                cmd.Parameters.AddWithValue("@phat", luong.Phat);
                cmd.Parameters.AddWithValue("@phuCap", luong.PhuCap);


                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }

        public LuongDTO LuongLeTan(int id, DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            LuongDTO luongLeTan = new LuongDTO();

            using (SqlCommand cmd = new SqlCommand("LichLamViecChiTietLeTan", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@StartOfMonth", firstDayOfMonth);
                cmd.Parameters.AddWithValue("@EndOfMonth", lastDayOfMonth);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        luongLeTan = new LuongDTO
                        {
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            Ten = reader["ho_ten"].ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Email = reader["email"]?.ToString() ?? "",
                            LuongCoBan = Convert.ToSingle(reader["luong_co_ban"]),
                            Thuong = Convert.ToSingle(reader["thuong"]),
                            Phat = Convert.ToSingle(reader["phat"]),
                            PhuCap = Convert.ToSingle(reader["phu_cap"]),
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            SoCa = Convert.ToInt32(reader["so_ca"])
                        };
                    }
                }
            }
            return luongLeTan;
        }
    }
}
