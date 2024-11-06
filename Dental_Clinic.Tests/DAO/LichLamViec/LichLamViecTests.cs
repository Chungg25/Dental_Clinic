using Xunit;
using System;
using System.Collections.Generic;
using Dental_Clinic.DAO.LichLamViec;
using Dental_Clinic.DTO.LichLamViec;
using Dental_Clinic.DTO.ChamCong;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.LichLamViec
{
    public class LichLamViecTests 
    {
        private readonly LichLamViecDAO _lichLamViecDAO;

        public LichLamViecTests()
        {
            _lichLamViecDAO = new LichLamViecDAO();
        }

        [Fact]
        public void DanhSachLichLamViecBacSi_TraVeDanhSachHopLe()
        {
            // Arrange
            DateTime firstDay = new DateTime(2023, 11, 1);
            DateTime lastDay = new DateTime(2024, 11, 30);

            // Act
            List<LichLamViecDTO> result = _lichLamViecDAO.DanhSachLichLamViecBacSi(firstDay, lastDay);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void LichLamViec_TraVeLichLamViecHopLe()
        {
            // Arrange
            int id = 1; 
            DateTime day = DateTime.Now;

            // Act
            List<ChamCongDTO> result = _lichLamViecDAO.LichLamViec(id, day);

            // Assert
            Assert.NotNull(result);
            Assert.All(result, item => Assert.Equal(id, item.MaNguoiDung));
        }

        [Fact]
        public void ChiTietLamViec_TraVeChiTietLamViecHopLe()
        {
            // Arrange
            int id = 1; 
            DateTime day = DateTime.Now;

            // Act
            ChamCongDTO result = _lichLamViecDAO.ChiTietLamViec(id, day);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ThemLichLamViec_ThemThanhCong_KhongNemNgoaiLe()
        {
            // Arrange
            int id = 1; 
            int ca = 1;
            DateTime ngay = DateTime.Now;

            // Act & Assert
            var exception = Record.Exception(() => _lichLamViecDAO.ThemLichLamViec(id, ca, ngay));
            Assert.Null(exception);
        }

        [Fact]
        public void XoaLichLamViec_XoaThanhCong_KhongNemNgoaiLe()
        {
            // Arrange
            int id = 1; 
            DateTime ngay = DateTime.Now;

            // Act & Assert
            var exception = Record.Exception(() => _lichLamViecDAO.XoaLichLamViec(id, ngay));
            Assert.Null(exception);
        }
    }
}
