using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.Login
{
    internal class DangNhapDAO
    {
        public DataRow KiemTraDangNhap(DangNhapDTO loginDTO)
        {
            // Tạo đối tượng kết nối
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                // Câu lệnh SQL để kiểm tra username và password
                string query = "KiemTraDangNhap";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số đầu vào cho stored procedure
                    cmd.Parameters.AddWithValue("@username", loginDTO.TenDangNhap);
                    cmd.Parameters.AddWithValue("@password", loginDTO.Matkhau);

                    // Khai báo các tham số đầu ra
                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
                    idParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idParam);

                    SqlParameter roleParam = new SqlParameter("@role", SqlDbType.VarChar, 50);
                    roleParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(roleParam);

                    // Thực thi câu lệnh
                    cmd.ExecuteNonQuery();

                    int userId = (int)cmd.Parameters["@id"].Value;

                    // Nếu userId > 0, lấy thông tin người dùng từ bảng users
                    if (userId > 0)
                    {
                        // Câu lệnh SQL để lấy thông tin người dùng
                        string userQuery = "LayThongTinBacSi";
                        using (SqlCommand userCmd = new SqlCommand(userQuery, dbConnection.Conn))
                        {
                            userCmd.CommandType = CommandType.StoredProcedure; // Đặt loại lệnh là StoredProcedure

                            // Thêm tham số đầu vào
                            userCmd.Parameters.AddWithValue("@userId", userId);

                            // Thực thi truy vấn và lưu kết quả vào DataTable
                            using (SqlDataAdapter adapter = new SqlDataAdapter(userCmd))
                            {
                                DataTable userTable = new DataTable();
                                adapter.Fill(userTable);

                                // Kiểm tra xem có dữ liệu không
                                if (userTable.Rows.Count > 0)
                                {
                                    // Trả về thông tin người dùng
                                    return userTable.Rows[0]; // Trả về dòng đầu tiên chứa thông tin người dùng
                                }
                            }
                        }
                    }
                    // Trả về null nếu không tìm thấy người dùng
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
            finally
            {
                // Đóng kết nối
                dbConnection.CloseConnection();
            }
        }

        public QuanTriVienDTO LayThongTinTheoID(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            QuanTriVienDTO thongTin = new QuanTriVienDTO();

            using (SqlCommand cmd = new SqlCommand("LayThongTinTheoID", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thongTin = new QuanTriVienDTO
                        {
                            Id = Convert.ToInt32(reader["ma"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? "",
                            CCCD = reader["cccd"].ToString() ?? "",
                            SDT = reader["so_dien_thoai"].ToString() ?? "",
                            DiaChi = reader["dia_chi"].ToString() ?? "",
                            GioiTinh = reader["gioi_tinh"] != DBNull.Value && (bool)reader["gioi_tinh"],
                            NgaySinh = reader["ngay_sinh"] != DBNull.Value ? (DateTime)reader["ngay_sinh"] : DateTime.MinValue,
                            ChucVu = reader["vai_tro"].ToString() ?? "",
                            TenDangNhap = reader["ten_dang_nhap"].ToString() ?? "",
                            MatKhau = reader["mat_khau"].ToString() ?? "",
                            Email = reader["email"].ToString() ?? "",
                            HeSoLuong = Convert.ToSingle(reader["he_so_luong"])
                        };
                    }
                }
            }
            return thongTin;
        }
        // Đăng xuất cập nhật phiên
        public bool CapNhatPhien(int maNguoiDung)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("CapNhatPhien", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", maNguoiDung);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
