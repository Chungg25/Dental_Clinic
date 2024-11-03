using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.HoaDon;
using Dental_Clinic.DTO.Luong;

namespace Dental_Clinic.DAO.LeTan
{
    public class LeTanDAO
    {
        private DatabaseConnection dbConnection;

        public LeTanDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        // Lấy danh sách bác sĩ trong ngày
        public List<BacSiDTO> LayThongTinBacSiTrongNgay(string ngayHienTai)
        {
            List<BacSiDTO> dsBacSi = new List<BacSiDTO>();

            using (SqlCommand cmd = new SqlCommand("LayThongTinBacSiTrongNgay", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ngay", ngayHienTai);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BacSiDTO bacSi = new BacSiDTO
                        {
                            Id = Convert.ToInt32(reader["ma_bac_si"]),
                            HoVaTen = reader["ten_bac_si"].ToString() ?? "",
                            ChuyenNganh = reader["ten_chuyen_mon"].ToString() ?? "",
                            Ca = Convert.ToInt32(reader["ca"]),
                            SoLuongBenhNhan = Convert.ToInt32(reader["so_luong_benh_nhan"]),
                            TrangThaiLamViec = reader["trang_thai_lam_viec"].ToString() ?? ""
                        };
                        dsBacSi.Add(bacSi);
                    }
                }
            }
            return dsBacSi;
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<LichHenDTO> LayDanhSachLichHenTheoNgay(string ngayHienTai)
        {
            List<LichHenDTO> dsLichHen = new List<LichHenDTO>();

            using (SqlCommand cmd = new SqlCommand("DanhSachBenhNhanTheoNgay", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ngay", ngayHienTai);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LichHenDTO lichHen = new LichHenDTO
                        {
                            MaLichHen = Convert.ToInt32(reader["ma_lich_hen"]),
                            MaBenhNhan = Convert.ToInt32(reader["ma_benh_nhan"]),
                            TenBenhNhan = reader["ten_benh_nhan"].ToString() ?? "",
                            SoDienThoai = reader["so_dien_thoai"].ToString() ?? "",
                            MaBacSi = Convert.ToInt32(reader["ma_bac_si"]),
                            TenBacSi = reader["ten_bac_si"].ToString() ?? "",
                            Ca = Convert.ToInt32(reader["ca"]),
                            NgayHen = reader["ngay_hen"].ToString() ?? "",
                            GhiChu = reader["ghi_chu"].ToString() ?? "",
                            TrangThai = reader["trang_thai"].ToString() ?? ""
                        };
                        dsLichHen.Add(lichHen);
                    }
                }
            }
            return dsLichHen;
        }
        // Thêm lịch hẹn mới
        public bool ThemLichHen(LichHenDTO lichHen)
        {
            using (SqlCommand cmd = new SqlCommand("TaoLichHenBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ho_ten", lichHen.TenBenhNhan);
                cmd.Parameters.AddWithValue("@gioi_tinh", lichHen.GioiTinh);
                cmd.Parameters.AddWithValue("@tuoi", lichHen.Tuoi);
                cmd.Parameters.AddWithValue("@so_dien_thoai", lichHen.SoDienThoai);
                cmd.Parameters.AddWithValue("@dia_chi", lichHen.DiaChi);
                cmd.Parameters.AddWithValue("@ma_bac_si", lichHen.MaBacSi);
                cmd.Parameters.AddWithValue("@ngay_hen", lichHen.NgayHen);
                cmd.Parameters.AddWithValue("@ca", lichHen.Ca);
                cmd.Parameters.AddWithValue("@ghi_chu", lichHen.GhiChu);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy thông tin bệnh nhân theo mã bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhanVaBenhAnTheoMa(int maBenhNhan)
        {
            BenhNhanDTO? benhNhan = null;

            using (SqlCommand cmd = new SqlCommand("LayThongTinBenhNhanVaBenhAn", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_benh_nhan", maBenhNhan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Chỉ đọc một bản ghi duy nhất
                    {
                        benhNhan = new BenhNhanDTO
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ma_benh_nhan")),
                            HoVaTen = reader["ho_ten"]?.ToString() ?? "",
                            GioiTinh = reader.GetBoolean(reader.GetOrdinal("gioi_tinh")),
                            Tuoi = reader.GetInt32(reader.GetOrdinal("tuoi")),
                            SDT = reader["so_dien_thoai"]?.ToString() ?? "",
                            DiaChi = reader["dia_chi"]?.ToString() ?? "",
                            MaHoSo = reader.IsDBNull(reader.GetOrdinal("ma_ho_so")) ? 0 : reader.GetInt32(reader.GetOrdinal("ma_ho_so")),
                            ChanDoan = reader["chan_doan"]?.ToString() ?? "",
                            PhuongPhapDieuTri = reader["phuong_phap_dieu_tri"]?.ToString() ?? "",
                            TrieuChung = reader["trieu_chung"]?.ToString() ?? ""
                        };
                    }
                }
            }
            return benhNhan ?? new BenhNhanDTO();
        }
        // Cập nhật thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public bool CapNhatThongTinBenhNhanVaBenhAn(BenhNhanDTO benhNhan)
        {
            using (SqlCommand cmd = new SqlCommand("CapNhatThongTinBenhNhanVaBenhAn ", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ma_benh_nhan", benhNhan.Id);
                cmd.Parameters.AddWithValue("@ho_ten", benhNhan.HoVaTen);
                cmd.Parameters.AddWithValue("@gioi_tinh", benhNhan.GioiTinh);
                cmd.Parameters.AddWithValue("@tuoi", benhNhan.Tuoi);
                cmd.Parameters.AddWithValue("@so_dien_thoai", benhNhan.SDT);
                cmd.Parameters.AddWithValue("@dia_chi", benhNhan.DiaChi);
                cmd.Parameters.AddWithValue("@ma_ho_so", benhNhan.MaHoSo);
                cmd.Parameters.AddWithValue("@chan_doan", benhNhan.ChanDoan);
                cmd.Parameters.AddWithValue("@phuong_phap_dieu_tri", benhNhan.PhuongPhapDieuTri);
                cmd.Parameters.AddWithValue("@trieu_chung", benhNhan.TrieuChung);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy danh sách bệnh nhân chưa thanh toán
        public List<BenhNhanDTO> LayDanhSachBenhNhanChuaThanhToan(string ngayHienTai)
        {
            List<BenhNhanDTO> benhNhanChuaThanhToan = new List<BenhNhanDTO>();

            using (SqlCommand cmd = new SqlCommand("LayDanhSachBenhNhanChuaThanhToan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ngay", ngayHienTai);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BenhNhanDTO benhNhan = new BenhNhanDTO
                        {
                            Id = Convert.ToInt32(reader["ma_benh_nhan"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? "",
                            SDT = reader["so_dien_thoai"].ToString() ?? "",
                            TenBacSi = reader["ten_bac_si"].ToString() ?? "",
                            MaHoaDon = Convert.ToInt32(reader["ma_hoa_don"]),   
                            TrangThaiKham = reader["trang_thai_kham"].ToString() ?? "",
                            TrangThaiThanhToan = reader["trang_thai_thanh_toan"].ToString() ?? ""
                        };
                        benhNhanChuaThanhToan.Add(benhNhan);
                    }
                }
            }
            return benhNhanChuaThanhToan;
        }
        // Lấy thông tin bệnh nhân
        public BenhNhanDTO LayThongTinBenhNhan(int maBenhNhan)
        {
            BenhNhanDTO benhNhan = new BenhNhanDTO();

            using (SqlCommand cmd = new SqlCommand("LayThongTinBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_benh_nhan", maBenhNhan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        benhNhan.Id = Convert.ToInt32(reader["ma_benh_nhan"]);
                        benhNhan.HoVaTen = reader["ho_ten"].ToString() ?? "";
                        benhNhan.GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]);
                        benhNhan.Tuoi = Convert.ToInt32(reader["tuoi"]);
                        benhNhan.SDT = reader["so_dien_thoai"].ToString() ?? "";
                        benhNhan.Ca = Convert.ToInt32(reader["ca"]);
                        benhNhan.TenBacSi = reader["ten_bac_si"].ToString() ?? "";
                        benhNhan.TrangThaiKham = reader["trang_thai_kham"].ToString() ?? "";
                    }
                }
            }
            return benhNhan;
        }
        // Lấy chi tiết hóa đơn của bệnh nhân
        public List<HoaDonDTO> LayChiTietHoaDonBenhNhan(int maBenhNhan)
        {
            List<HoaDonDTO> hoaDons = new List<HoaDonDTO>();

            using (SqlCommand cmd = new SqlCommand("LayChiTietHoaDonBenhNhan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_benh_nhan", maBenhNhan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonDTO hoaDon = new HoaDonDTO
                        {
                            LoaiMuc = reader["loai_muc"].ToString() ?? "",
                            TenMuc = reader["ten_muc"].ToString() ?? "",
                            SoLuong = Convert.ToInt32(reader["so_luong"]),
                            DonGia = Convert.ToSingle(reader["don_gia"]),
                            ThanhTien = Convert.ToSingle(reader["thanh_tien"])
                        };
                        hoaDons.Add(hoaDon);
                    }
                }
            }
            return hoaDons;
        }
        // Cập nhật trạng thái thanh toán của bệnh nhân
        public bool CapNhatTrangThaiHoaDon(int maHoaDon, int phuongThucThanhToan, float tongTien)
        {
            using (SqlCommand cmd = new SqlCommand("CapNhatTrangThaiVaPhuongThucThanhToan", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ma_hoa_don", maHoaDon);
                cmd.Parameters.AddWithValue("@phuong_thuc_thanh_toan", phuongThucThanhToan);
                cmd.Parameters.AddWithValue("@tong_tien", tongTien);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy thông tin lương 
        public LuongDTO LayThongTinLuong(int maLeTan, int thang, int nam)
        {
            LuongDTO luong = new LuongDTO();

            using (SqlCommand cmd = new SqlCommand("ThongTinLeTanTheoThang", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_nguoi_dung", maLeTan);
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        luong.Id = reader["ma_nguoi_dung"] != DBNull.Value ? Convert.ToInt32(reader["ma_nguoi_dung"]) : 0;
                        luong.Ten = reader["ho_ten"] != DBNull.Value ? reader["ho_ten"].ToString() : "";
                        luong.SoCa = reader["so_ca"] != DBNull.Value ? Convert.ToInt32(reader["so_ca"]) : 0;
                        luong.TongLuong = reader["tong_luong"] != DBNull.Value ? Convert.ToSingle(reader["tong_luong"]) : 0;
                        luong.TongThuong = reader["tong_thuong"] != DBNull.Value ? Convert.ToSingle(reader["tong_thuong"]) : 0;
                        luong.TongPhat = reader["tong_tien_phat"] != DBNull.Value ? Convert.ToSingle(reader["tong_tien_phat"]) : 0;
                        luong.TongSoLoi = reader["tong_so_loi"] != DBNull.Value ? Convert.ToInt32(reader["tong_so_loi"]) : 0;
                    }

                }
            }
            return luong;
        }

    }
}
