using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Clinic.DAO.LeTan
{
    public class LeTanDAO
    {
        private DatabaseConnection dbConnection;

        public LeTanDAO()
        {
            dbConnection = new DatabaseConnection();
        }
        // Lấy danh sách lịch hẹn theo ngày
        public List<LichHenDTO> LayDanhSachLichHenTheoNgay(string ngayHienTai)
        {
            List<LichHenDTO> appointmentList = new List<LichHenDTO>();
            
            using (SqlCommand cmd = new SqlCommand("LayDanhSachLichHenTrongNgay", dbConnection.Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayHen", ngayHienTai);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LichHenDTO appointment = new LichHenDTO
                        {
                            MaLichHen = Convert.ToInt32(reader["maLichHen"]),
                            MaBenhNhan = Convert.ToInt32(reader["maBenhNhan"]),
                            TenBenhNhan = reader["tenBenhNhan"].ToString() ?? "",
                            SoDienThoai = reader["soDienThoai"]?.ToString() ?? "",
                            DiaChi = reader["diaChi"]?.ToString() ?? "",
                            GioiTinh = reader["gioiTinh"].ToString() ?? "",
                            Tuoi = Convert.ToInt32(reader["tuoi"]),
                            MaBacSi = Convert.ToInt32(reader["maBacSi"]),
                            TenBacSi = reader["tenBacSi"].ToString() ?? "",
                            TrangThai = reader["trangThai"].ToString() ?? "",
                            GhiChu = reader["ghiChu"].ToString() ?? ""
                        };
                        appointmentList.Add(appointment);
                    }
                }
            }
            return appointmentList;
        }
    }
}
