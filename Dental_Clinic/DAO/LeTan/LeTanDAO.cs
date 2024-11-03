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
            BenhNhanDTO benhNhan = new BenhNhanDTO();

            using (SqlCommand cmd = new SqlCommand("LayThongTinBenhNhanVaBenhAn", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_benh_nhan", maBenhNhan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        benhNhan.Id = Convert.ToInt32(reader["ma_benh_nhan"]);
                        benhNhan.HoVaTen = reader["ho_ten"].ToString() ?? "";
                        benhNhan.GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]);
                        benhNhan.Tuoi = Convert.ToInt32(reader["tuoi"]);
                        benhNhan.SDT = reader["so_dien_thoai"].ToString() ?? "";
                        benhNhan.DiaChi = reader["dia_chi"].ToString() ?? "";
                        benhNhan.MaHoSo = Convert.ToInt32(reader["ma_ho_so"]);
                        benhNhan.ChanDoan = reader["chan_doan"].ToString() ?? "";
                        benhNhan.PhuongPhapDieuTri = reader["phuong_phap_dieu_tri"].ToString() ?? "";
                        benhNhan.TrieuChung = reader["trieu_chung"].ToString() ?? "";
                    }
                }
            }
            return benhNhan;
        }
        // Cập nhật thông tin bệnh nhân và bệnh án theo mã bệnh nhân
        public bool CapNhatThongTinBenhNhanVaBenhAn (BenhNhanDTO benhNhan)
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
    }
}
