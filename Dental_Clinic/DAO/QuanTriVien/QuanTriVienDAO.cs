using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LeTan;
using Dental_Clinic.DTO.Admin;

namespace Dental_Clinic.DAO.Admin
{
    internal class QuanTriVienDAO
    {
        // Hàm lấy số lượng bác sĩ
        public int SoLuongBacSi()
        {
            
            int doctorCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongBacSi()", dbConnection.Conn))
            {
                doctorCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return doctorCount; // Trả về số lượng bác sĩ
        }
        // Hàm lấy số lượng bệnh nhân
        public int SoLuongBenhNhan()
        {
            int patientCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.SoLuongBenhNhan()", dbConnection.Conn))
            {
                patientCount = (int)cmd.ExecuteScalar(); // Lấy giá trị trả về
                dbConnection.CloseConnection();
            }
            return patientCount; // Trả về số lượng bệnh nhân
        }
        // Tổng lương
        public int TongLuong()
        {
            int revenueCount = 0;
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.TongDoanhThu()", dbConnection.Conn))
            {
                revenueCount = (int)cmd.ExecuteScalar(); 
                dbConnection.CloseConnection();
            }
            return revenueCount;
        }

        public List<BacSiDTO> LayDanhSachBacSi()
        {
            List<BacSiDTO> doctorList = new List<BacSiDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand("DanhSachBacSi", dbConnection.Conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSiDTO doctor = new BacSiDTO
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
                                ChuyenNganh = reader["ten_chuyen_mon"]?.ToString() ?? "",
                                TrangThai = Convert.ToInt32(reader["trang_thai"])
                            };
                            doctorList.Add(doctor);
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

            return doctorList;
        }
        // Cập nhật trạng thái
        public void CapNhatTrangThai(int userID)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatTrangThai", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userID);
                cmd.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }
        // Lấy thông tin bác sĩ
        public BacSiDTO LayThongTinBacSi(int id)
        {
            BacSiDTO doctor = new BacSiDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("LayThongTinBacSi", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        doctor = new BacSiDTO
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
                            ChuyenNganh = reader["ten_chuyen_mon"]?.ToString() ?? "",
                            TrangThai = Convert.ToInt32(reader["trang_thai"])
                        };
                    }
                    else
                    {
                        throw new Exception($"Doctor with ID {id} not found."); // Ném ngoại lệ
                    }
                }
                dbConnection.CloseConnection();
            }
            return doctor;
        }
        // Cập nhật thông tin bác sĩ
        public void CapNhatBacSi(BacSiDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinBacSi", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@userId", doctor.Id);
                cmd.Parameters.AddWithValue("@fullName", doctor.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", doctor.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.SDT);
                cmd.Parameters.AddWithValue("@address", doctor.DiaChi);
                cmd.Parameters.AddWithValue("@gender", doctor.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", doctor.NgaySinh);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.HeSoLuong);
                cmd.Parameters.AddWithValue("@userName", doctor.TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", doctor.MatKhau);
                cmd.Parameters.AddWithValue("@specializationID", ConvertSpecializationToId(doctor.ChuyenNganh));
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        // Chuyển tên chuyên ngành thành ID
        public int ConvertSpecializationToId(string specializationName)
        {
            // Danh sách các chuyên ngành
            string[] specializations = new string[]
            {
                "Nha chu",
                "Nhổ răng và tiểu phẫu",
                "Phục hình",
                "Chữa răng và nội nha",
                "Răng trẻ em",
                "Tổng quát"
            };

            // Tìm chỉ số của chuyên ngành trong danh sách
            for (int i = 0; i < specializations.Length; i++)
            {
                if (specializations[i] == specializationName)
                {
                    return i + 1;
                }
            }

            return -1;
        }
        // Thêm bác sĩ
        public void ThemBacSi(BacSiDTO doctor)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("ThemBacSi", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@fullName", doctor.HoVaTen);
                cmd.Parameters.AddWithValue("@citizenId", doctor.CCCD);
                cmd.Parameters.AddWithValue("@phoneNumber", doctor.SDT);
                cmd.Parameters.AddWithValue("@address", doctor.DiaChi);
                cmd.Parameters.AddWithValue("@gender", doctor.GioiTinh);
                cmd.Parameters.AddWithValue("@dob", doctor.NgaySinh);
                cmd.Parameters.AddWithValue("@email", doctor.Email);
                cmd.Parameters.AddWithValue("@salaryCoefficient", doctor.HeSoLuong);
                cmd.Parameters.AddWithValue("@specializationID", ConvertSpecializationNameToAdjustedId(doctor.ChuyenNganh));
                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        // Chuyển tên chuyên ngành thành ID
        public int ConvertSpecializationNameToAdjustedId(string specialization_name)
        {
            int specializationId;
            if (specialization_name == "0")
            {
                specializationId = 1; // Chuyển "0" thành 1
            }
            else if (specialization_name == "1")
            {
                specializationId = 2; // Chuyển "1" thành 2
            }
            else if (specialization_name == "2")
            {
                specializationId = 3; // Chuyển "2" thành 3
            }
            else if (specialization_name == "3")
            {
                specializationId = 4; // Chuyển "3" thành 4
            }
            else if (specialization_name == "4")
            {
                specializationId = 5; // Chuyển "4" thành 5
            }
            else if (specialization_name == "5")
            {
                specializationId = 6; // Chuyển "5" thành 6
            }
            else
            {
                specializationId = -1;
            }
            return specializationId;
        }

        public List<LeTanDTO> LayDanhSachLeTan()
        {
            List<LeTanDTO> receptionistList = new List<LeTanDTO>();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("DanhSachLeTan", dbConnection.Conn))
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

            using (SqlCommand cmd = new SqlCommand("ThongTinLeTan", dbConnection.Conn))
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
        // Cập nhật thông tin lễ tân
        public void CapNhatLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinLeTan", dbConnection.Conn))
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
                cmd.Parameters.AddWithValue("@userName", receptionist.TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", receptionist.MatKhau);


                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
        // Thêm lễ tân
        public void ThemLeTan(LeTanDTO receptionist)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("ThemLeTan", dbConnection.Conn))
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

        public QuanTriVienDTO LayThongTinQuanTriVien(int id)
        {
            QuanTriVienDTO quanTriVien = new QuanTriVienDTO();
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("ThongTinQuanTriVien", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        quanTriVien = new QuanTriVienDTO
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
                        };
                    }
                    else
                    {
                        throw new Exception($"Receptionist with ID {id} not found."); // Ném ngoại lệ
                    }
                }
                dbConnection.CloseConnection();
            }
            return quanTriVien;
        }
        // Cập nhật thông tin lễ tân
        public void CapNhatQuanTriVien(QuanTriVienDTO quanTriVien)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            using (SqlCommand cmd = new SqlCommand("CapNhatThongQuanTriVien", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho thủ tục lưu trữ
                cmd.Parameters.AddWithValue("@maNguoiDung", quanTriVien.Id);
                cmd.Parameters.AddWithValue("@hoTen", quanTriVien.HoVaTen);
                cmd.Parameters.AddWithValue("@cccd", quanTriVien.CCCD);
                cmd.Parameters.AddWithValue("@soDienThoai", quanTriVien.SDT);
                cmd.Parameters.AddWithValue("@diaChi", quanTriVien.DiaChi);
                cmd.Parameters.AddWithValue("@gioiTinh", quanTriVien.GioiTinh);
                cmd.Parameters.AddWithValue("@ngaySinh", quanTriVien.NgaySinh);
                cmd.Parameters.AddWithValue("@email", quanTriVien.Email);
                cmd.Parameters.AddWithValue("@heSoLuong", quanTriVien.HeSoLuong);
                cmd.Parameters.AddWithValue("@userName", quanTriVien.TenDangNhap);
                cmd.Parameters.AddWithValue("@pass", quanTriVien.MatKhau);


                cmd.ExecuteNonQuery();
                dbConnection.Conn.Close();
            }
        }
    }
}
