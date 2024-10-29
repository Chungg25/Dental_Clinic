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
    internal class LeTanDAO
    {
        // Hàm lấy danh sách lễ tân
        public List<LeTanDTO> LayDanhSachLeTan()
        {
            List<LeTanDTO> receptionistList = new List<LeTanDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetReceptionistList", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LeTanDTO letan = new LeTanDTO
                        {  
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? "",
                            CCCD = reader["cccd"]?.ToString() ?? "",
                            SDT = reader["so_dien_thoai"]?.ToString() ?? "",
                            DiaChi = reader["dia_chi"]?.ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            NgaySinh = Convert.ToDateTime(reader["ngay_sinh"]),
                            TenDangNhap = reader["ten_dang_nhap"]?.ToString() ?? "",
                            MatKhau = reader["mat_khau"]?.ToString() ?? "",
                            Email = reader["email"]?.ToString() ?? "",
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            TrangThai = Convert.ToInt32(reader["trang_thai"])
                        };
                        receptionistList.Add(letan);
                    }
                }
                dbConnection.CloseConnection();
            }
            return receptionistList;
        }
        // Hàm lấy thông tin lễ tân
        public LeTanDTO LayThongTinLeTan(int id)
        {
            LeTanDTO receptionist = new LeTanDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("GetReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        receptionist = new LeTanDTO
                        {
                            Id = Convert.ToInt32(reader["ma_nguoi_dung"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? "",
                            CCCD = reader["cccd"]?.ToString() ?? "",
                            SDT = reader["so_dien_thoai"]?.ToString() ?? "",
                            DiaChi = reader["dia_chi"]?.ToString() ?? "",
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            NgaySinh = Convert.ToDateTime(reader["ngay_sinh"]),
                            TenDangNhap = reader["ten_dang_nhap"]?.ToString() ?? "",
                            MatKhau = reader["mat_khau"]?.ToString() ?? "",
                            Email = reader["email"]?.ToString() ?? "",
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"]),
                            TrangThai = Convert.ToInt32(reader["trang_thai"])
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
        // Cập nhật trạng thái lễ tân
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
        // Cập nhật thông tin lễ tân
        public void CapNhatLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("UpdateReceptionistInfo", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@maNguoiDung", receptionist.Id);
                cmd.Parameters.AddWithValue("@hoTen", receptionist.HoVaTen);
                cmd.Parameters.AddWithValue("@cccd", receptionist.CCCD);
                cmd.Parameters.AddWithValue("@soDienThoai", receptionist.SDT);
                cmd.Parameters.AddWithValue("@diaChi", receptionist.DiaChi);
                cmd.Parameters.AddWithValue("@gioiTinh", receptionist.GioiTinh);
                cmd.Parameters.AddWithValue("@ngaySinh", receptionist.NgaySinh);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@heSoLuong", receptionist.HeSoLuong);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        // Thêm lễ tân
        public void ThemLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("AddReceptionist", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@hoTen", receptionist.HoVaTen);
                cmd.Parameters.AddWithValue("@cccd", receptionist.CCCD);
                cmd.Parameters.AddWithValue("@soDienThoai", receptionist.SDT);
                cmd.Parameters.AddWithValue("@diaChi", receptionist.DiaChi);
                cmd.Parameters.AddWithValue("@gioiTinh", receptionist.GioiTinh);
                cmd.Parameters.AddWithValue("@ngaySinh", receptionist.NgaySinh);
                cmd.Parameters.AddWithValue("@email", receptionist.Email);
                cmd.Parameters.AddWithValue("@heSoLuong", receptionist.HeSoLuong);

                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    }
}
