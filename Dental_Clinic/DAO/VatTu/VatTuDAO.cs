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
    }
}
