using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Dental_Clinic.DAO.VatTu
{
    internal class VatTuDAO
    {
        public List<VatTuDTO> DanhSachThuoc(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<VatTuDTO> danhSachThuoc = new List<VatTuDTO>();

            using (SqlCommand cmd = new SqlCommand("ThongTinThuoc", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VatTuDTO thuoc = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_kho"]),
                            Ten = reader["ten"].ToString() ?? "",
                            Loai = reader["loai"]?.ToString() ?? "",
                            SoLuong = reader["so_luong"]?.ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            LieuLuong = reader["lieu_luong"]?.ToString() ?? "",
                            NgaySanXuat = Convert.ToDateTime(reader["ngay_san_xuat"]).ToString("yyyy-MM-dd"),
                            NgayHetHan = Convert.ToDateTime(reader["ngay_het_han"]).ToString("yyyy-MM-dd"),
                            NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]).ToString("yyyy-MM-dd"),
                            TenLoai = reader["ten_loai"]?.ToString() ?? "",
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                        danhSachThuoc.Add(thuoc);
                    }
                }
            }
            return danhSachThuoc;
        }

        public List<VatTuDTO> DanhSachVatTu(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<VatTuDTO> danhSachVatTu = new List<VatTuDTO>();

            using (SqlCommand cmd = new SqlCommand("ThongTinVatTu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VatTuDTO vatTu = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_kho"]),
                            Ten = reader["ten"].ToString() ?? "",
                            Loai = reader["loai"]?.ToString() ?? "",
                            SoLuong = reader["so_luong"]?.ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            LieuLuong = reader["lieu_luong"]?.ToString() ?? "",
                            NgaySanXuat = Convert.ToDateTime(reader["ngay_san_xuat"]).ToString("yyyy-MM-dd"),
                            NgayHetHan = Convert.ToDateTime(reader["ngay_het_han"]).ToString("yyyy-MM-dd"),
                            NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]).ToString("yyyy-MM-dd"),
                            TenLoai = reader["ten_loai"]?.ToString() ?? "",
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                        danhSachVatTu.Add(vatTu);
                    }
                }
            }
            return danhSachVatTu;
        }

        public List<VatTuDTO> DanhSachDichVu()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            List<VatTuDTO> danhSachDichVu = new List<VatTuDTO>();

            using (SqlCommand cmd = new SqlCommand("ThongTinDichVu", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VatTuDTO dichVu = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_dich_vu"]),
                            Ten = reader["ten"].ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            TenLoai = reader["ten_ten_dich"]?.ToString() ?? "",
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                        danhSachDichVu.Add(dichVu);
                    }
                }
            }
            return danhSachDichVu;
        }

        public VatTuDTO ThongTinThuoc(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            VatTuDTO thongTinThuoc = new VatTuDTO();

            using (SqlCommand cmd = new SqlCommand("ThongTinChiTietThuoc", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thongTinThuoc = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_kho"]),
                            Ten = reader["ten"].ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            TenLoai = reader["loai"]?.ToString() ?? "",
                            SoLuong = reader["so_luong"]?.ToString() ?? "",
                            LieuLuong = reader["lieu_luong"]?.ToString() ?? "",
                            NgaySanXuat = Convert.ToDateTime(reader["ngay_san_xuat"]).ToString("yyyy-MM-dd"),
                            NgayHetHan = Convert.ToDateTime(reader["ngay_het_han"]).ToString("yyyy-MM-dd"),
                            NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]).ToString("yyyy-MM-dd"),
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                    }
                }
            }
            return thongTinThuoc;
        }

        public void CapNhatThongTinThuoc(VatTuDTO thuoc)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinThuoc", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", thuoc.Id);
                cmd.Parameters.AddWithValue("@donViTinh", thuoc.DonVi);
                cmd.Parameters.AddWithValue("@gia", thuoc.Gia);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public VatTuDTO ThongTinVatTu(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            VatTuDTO thongTinVatTu = new VatTuDTO();

            using (SqlCommand cmd = new SqlCommand("ThongTinChiTietVatTu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thongTinVatTu = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_kho"]),
                            Ten = reader["ten"].ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            TenLoai = reader["loai"]?.ToString() ?? "",
                            SoLuong = reader["so_luong"]?.ToString() ?? "",
                            LieuLuong = reader["lieu_luong"]?.ToString() ?? "",
                            NgaySanXuat = Convert.ToDateTime(reader["ngay_san_xuat"]).ToString("yyyy-MM-dd"),
                            NgayHetHan = Convert.ToDateTime(reader["ngay_het_han"]).ToString("yyyy-MM-dd"),
                            NgayNhap = Convert.ToDateTime(reader["ngay_nhap"]).ToString("yyyy-MM-dd"),
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                    }
                }
            }
            return thongTinVatTu;
        }

        public void CapNhatThongTinVatTu(VatTuDTO vatTu)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinVatTu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", vatTu.Id);
                cmd.Parameters.AddWithValue("@donViTinh", vatTu.DonVi);
                cmd.Parameters.AddWithValue("@gia", vatTu.Gia);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public VatTuDTO ThongTinDichVu(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            VatTuDTO thongTinDichVu = new VatTuDTO();

            using (SqlCommand cmd = new SqlCommand("ThongTinChiTietDichVu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        thongTinDichVu = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_dich_vu"]),
                            Ten = reader["ten"].ToString() ?? "",
                            DonVi = reader["don_vi"]?.ToString() ?? "",
                            TenLoai = reader["ten_ten_dich"]?.ToString() ?? "",
                            Gia = Convert.ToSingle(reader["gia"])
                        };
                    }
                }
            }
            return thongTinDichVu;
        }

        public void CapNhatThongTinDichVu(VatTuDTO dichVu)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinDichVu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", dichVu.Id);
                cmd.Parameters.AddWithValue("@donViTinh", dichVu.DonVi);
                cmd.Parameters.AddWithValue("@gia", dichVu.Gia);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public void ThemDichVu(VatTuDTO dichVu)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("ThemDichVu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@ten", dichVu.Ten);
                cmd.Parameters.AddWithValue("@donVi", dichVu.DonVi);
                cmd.Parameters.AddWithValue("@gia", dichVu.Gia);
                cmd.Parameters.AddWithValue("@maLoai", GetMaLoaiFromTen(dichVu.Loai));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        private int GetMaLoaiFromTen(string tenDichVu)
        {
            switch (tenDichVu)
            {
                case "Khám - Hồ sơ":
                    return 1;
                case "Nhổ răng":
                    return 2;
                case "Nha chu":
                    return 3;
                case "Chữa răng - Nội nha":
                    return 4;
                case "Phục hình tháo lắp":
                    return 5;
                case "Phục hình cố định":
                    return 6;
                case "Điều trị răng sữa":
                    return 7;
                case "Chỉnh hình răng mặt":
                    return 8;
                case "Nha công cộng":
                    return 9;
                case "Điều trị loạn năng hệ thống nhai":
                    return 10;
                case "X-Quang răng":
                    return 11;
                case "Cấy ghép Implant":
                    return 12;
                case "Phục hình đơn lẻ":
                    return 13;
                case "Phục hình bắt vít":
                    return 14;
                default:
                    return 0; 
            }
        }
        public void ThemVatTu(VatTuDTO vatTu)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("ThemVatTu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@ten", vatTu.Ten);
                cmd.Parameters.AddWithValue("@loai", vatTu.Loai);
                cmd.Parameters.AddWithValue("@soLuong", vatTu.SoLuong);
                cmd.Parameters.AddWithValue("@donVi", vatTu.DonVi);
                cmd.Parameters.AddWithValue("@lieuLuong", vatTu.LieuLuong);
                cmd.Parameters.AddWithValue("@ngaySanXuat", vatTu.NgaySanXuat);
                cmd.Parameters.AddWithValue("@ngayHetHan", vatTu.NgayHetHan);
                cmd.Parameters.AddWithValue("@ngayNhap", vatTu.NgayNhap);
                cmd.Parameters.AddWithValue("@gia", vatTu.Gia);
                cmd.Parameters.AddWithValue("@maLoai", LayMaLoaiVatTu(vatTu.Loai));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public int LayMaLoaiVatTu(string loai)
        {
            switch (loai)
            {
                case "Vật tư":
                    return 2;
                case "Dụng cụ":
                    return 3;
                case "Thiết bị":
                    return 4;
                default:
                    return 0;
            }
        }

        public void ThemThuoc(VatTuDTO thuoc)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("ThemThuoc", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@ten", thuoc.Ten);
                cmd.Parameters.AddWithValue("@loai", thuoc.TenLoai);
                cmd.Parameters.AddWithValue("@soLuong", thuoc.SoLuong);
                cmd.Parameters.AddWithValue("@donVi", thuoc.DonVi);
                cmd.Parameters.AddWithValue("@lieuLuong", thuoc.LieuLuong);
                cmd.Parameters.AddWithValue("@ngaySanXuat", thuoc.NgaySanXuat);
                cmd.Parameters.AddWithValue("@ngayHetHan", thuoc.NgayHetHan);
                cmd.Parameters.AddWithValue("@ngayNhap", thuoc.NgayNhap);
                cmd.Parameters.AddWithValue("@gia", thuoc.Gia);
                cmd.Parameters.AddWithValue("@maLoai", 1);
                MessageBox.Show("!");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public void XoaHang(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("XoaHangTonKho", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }

        public void XoaDichVu(int id)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            using (SqlCommand cmd = new SqlCommand("XoaDichVu", dbConnection.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
        }
    }
}
