using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.DTO.VatTu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.BacSi
{
    public class BacSiDAO
    {
        private DatabaseConnection dbConnection;

        public BacSiDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        // Lấy danh sách bệnh nhân của bác sĩ
        public List<BenhNhanDTO> LayDanhSachBenhNhanCuaBacSi(int id, string ngayHienTai)
        {
            List<BenhNhanDTO> dsBenhNhan = new List<BenhNhanDTO>();

            using (SqlCommand cmd = new SqlCommand("LayThongTinBenhNhanCuaBacSi", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ma_bac_si", id);
                cmd.Parameters.AddWithValue("@ngay_hien_tai", ngayHienTai);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BenhNhanDTO benhNhan = new BenhNhanDTO
                        {
                            Id = Convert.ToInt32(reader["ma_benh_nhan"]),
                            HoVaTen = reader["ho_ten"].ToString() ?? string.Empty,
                            DiaChi = reader["dia_chi"].ToString() ?? string.Empty,
                            GioiTinh = Convert.ToBoolean(reader["gioi_tinh"]),
                            Tuoi = Convert.ToInt32(reader["tuoi"]),
                            SDT = reader["so_dien_thoai"].ToString() ?? string.Empty,
                            TrangThaiKham = reader["trang_thai_kham"].ToString() ?? string.Empty,
                            MaLichHen = Convert.ToInt32(reader["ma_lich_hen"]),
                        };
                        dsBenhNhan.Add(benhNhan);
                    }
                }
            }
            return dsBenhNhan;
        }
        // Cập nhật hồ sơ bệnh án
        public bool CapNhatHoSoBenhAn(int maBenhNhan, string chanDoan, string phuongPhapDieuTri, string trieuChung, string ngayLap, int maBacSi, int maLichHen)
        {
            using (SqlCommand cmd = new SqlCommand("ThemHoSoBenhAnVaCapNhatTrangThaiKham", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                cmd.Parameters.AddWithValue("@ChanDoan", chanDoan);
                cmd.Parameters.AddWithValue("@PhuongPhapDieuTri", phuongPhapDieuTri);
                cmd.Parameters.AddWithValue("@TrieuChung", trieuChung);
                cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);
                cmd.Parameters.AddWithValue("@MaLichHen", maLichHen);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Thêm lịch hẹn
        public bool ThemLichHen(int maBenhNhan, int maBacSi, string ghiChu, string ngayHen, int ca)
        {
            using (SqlCommand cmd = new SqlCommand("ThemLichHen", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                cmd.Parameters.AddWithValue("@MaNguoiDung", maBacSi);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@NgayHen", ngayHen);
                cmd.Parameters.AddWithValue("@Ca", ca);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy danh sách loại dịch vụ
        public Dictionary<int, string> LayDanhSachLoaiDichVu()
        {
            Dictionary<int, string> dsLoaiDichVu = new Dictionary<int, string>();

            using (SqlCommand cmd = new SqlCommand("LayTatCaLoaiDichVu", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dsLoaiDichVu.Add(Convert.ToInt32(reader["ma_loai_dich_vu"]), reader["ten_loai_dich_vu"].ToString());
                    }
                }
            }
            //MessageBox.Show(dsLoaiDichVu.Count.ToString());
            return dsLoaiDichVu;
        }
        // Lấy danh sách dịch vụ theo loại dịch vụ
        public List<VatTuDTO> LayDanhSachDichVuTheoLoai(int maLoaiDichVu)
        {
            List<VatTuDTO> dsDichVu = new List<VatTuDTO>();

            using (SqlCommand cmd = new SqlCommand("LayDanhSachDichVuTheoLoai", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaLoaiDichVu", maLoaiDichVu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VatTuDTO dichVu = new VatTuDTO
                        {
                            Id = Convert.ToInt32(reader["ma_dich_vu"]),
                            Ten = reader["ten_dich_vu"].ToString() ?? string.Empty,
                            DonVi = reader["don_vi"].ToString() ?? string.Empty,
                            Gia = Convert.ToInt32(reader["gia"]),
                        };
                        dsDichVu.Add(dichVu);
                    }
                }
            }
            return dsDichVu;
        }
        // Lấy danh sách thuốc
        public List<string> LayDanhSachThuoc()
        {
            List<string> dsThuoc = new List<string>();

            using (SqlCommand cmd = new SqlCommand("LayDanhSachThuoc", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dsThuoc.Add(reader["ten"].ToString());
                    }
                }
                return dsThuoc;
            }
        }
        // Thêm hoá đơn
        public bool ThemHoaDon(int maBacSi, int maBenhNhan, int phuongThucThanhToan, string ngay, string jsonThuoc, string jsonDichVu)
        {
            using (SqlCommand cmd = new SqlCommand("ThemHoaDon", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);
                cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", phuongThucThanhToan);
                cmd.Parameters.AddWithValue("@Ngay", ngay);
                cmd.Parameters.AddWithValue("@DanhSachThuoc", jsonThuoc);
                cmd.Parameters.AddWithValue("@DanhSachDichVu", jsonDichVu);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
