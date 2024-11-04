using Xunit;
using Dental_Clinic.DAO.LeTan;
using Dental_Clinic.DTO.LichHen;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.Patient;
using Dental_Clinic.DTO.HoaDon;
using Dental_Clinic.DTO.Luong;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.LeTan
{
    public class LeTanDAOTests : IClassFixture<DatabaseFixture>
    {
        private readonly SqlConnection _testConnection;
        private readonly LeTanDAO _leTanDAO;

        public LeTanDAOTests(DatabaseFixture fixture)
        {
            _testConnection = fixture.TestDatabaseConnection;
            _leTanDAO = new LeTanDAO();
        }

        [Fact]
        public void LayThongTinBacSiTrongNgay_TraVeDanhSachBacSi()
        {
            // Arrange
            string ngayHienTai = DateTime.Now.ToString("2024-10-01");

            // Act
            List<BacSiDTO> ketQua = _leTanDAO.LayThongTinBacSiTrongNgay(ngayHienTai);

            // Assert
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void LayDanhSachLichHenTheoNgay_TraVeDanhSachLichHen()
        {
            // Arrange
            string ngayHienTai = DateTime.Now.ToString("2024-11-03");

            // Act
            List<LichHenDTO> ketQua = _leTanDAO.LayDanhSachLichHenTheoNgay(ngayHienTai);

            // Assert
            Assert.NotNull(ketQua);
        }

        // TODO: cai nay sai tu proc cua db, muon xoa thi xoa
        // [Fact]
        // public void ThemLichHen_ThemLichHenMoi_TraVeTrue()
        // {
        //     // Arrange
        //     var lichHenMoi = new LichHenDTO
        //     {
        //         TenBenhNhan = "Nguyen Van B",
        //         GioiTinh = 1,
        //         Tuoi = 30,
        //         SoDienThoai = "0987654321",
        //         DiaChi = "123 Main St",
        //         MaBacSi = 1,
        //         NgayHen = DateTime.Now.ToString("yyyy-MM-dd"),
        //         Ca = 1,
        //         GhiChu = "Lich hen moi"
        //     };

        //     // Act
        //     bool ketQua = _leTanDAO.ThemLichHen(lichHenMoi);

        //     // Assert
        //     Assert.True(ketQua);
        // }

        [Fact]
        public void LayThongTinBenhNhanVaBenhAnTheoMa_TraVeThongTinBenhNhan()
        {
            // Arrange
            int maBenhNhan = 1;

            // Act
            BenhNhanDTO ketQua = _leTanDAO.LayThongTinBenhNhanVaBenhAnTheoMa(maBenhNhan);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(maBenhNhan, ketQua.Id);
        }

        [Fact]
        public void CapNhatThongTinBenhNhanVaBenhAn_CapNhatThanhCong_TraVeTrue()
        {
            // Arrange
            var benhNhanCapNhat = new BenhNhanDTO
            {
                Id = 1,
                HoVaTen = "Nguyen Van C",
                GioiTinh = true,
                Tuoi = 32,
                SDT = "0123456789",
                DiaChi = "456 Side St",
                MaHoSo = 101,
                ChanDoan = "Cập nhật chẩn đoán",
                PhuongPhapDieuTri = "Cập nhật phương pháp",
                TrieuChung = "Cập nhật triệu chứng"
            };

            // Act
            bool ketQua = _leTanDAO.CapNhatThongTinBenhNhanVaBenhAn(benhNhanCapNhat);

            // Assert
            Assert.True(ketQua);
        }
    }
}
