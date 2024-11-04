using Xunit;
using System;
using System.Collections.Generic;
using Dental_Clinic.DAO.Luong;
using Dental_Clinic.DTO.Luong;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.Luong
{
    public class LuongDAOTests : IClassFixture<DatabaseFixture>
    {
        private readonly LuongDAO _luongDAO;
        private readonly SqlConnection _testConnection;

        public LuongDAOTests(DatabaseFixture fixture)
        {
            _testConnection = fixture.TestDatabaseConnection;
            _luongDAO = new LuongDAO();
        }

        [Fact]
        public void DanhSachLuongBacSi_TraVeDanhSachHopLe()
        {
            // Arrange
            DateTime firstDayOfMonth = new DateTime(2023, 11, 1);
            DateTime lastDayOfMonth = new DateTime(2024, 11, 30);

            // Act
            List<LuongDTO> ketQua = _luongDAO.DanhSachLuongBacSi(firstDayOfMonth, lastDayOfMonth);

            // Assert
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void DanhSachLuongLeTan_TraVeDanhSachHopLe()
        {
            // Arrange
            DateTime firstDayOfMonth = new DateTime(2023, 11, 1);
            DateTime lastDayOfMonth = new DateTime(2024, 11, 30);

            // Act
            List<LuongDTO> ketQua = _luongDAO.DanhSachLuongLeTan(firstDayOfMonth, lastDayOfMonth);

            // Assert
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void LuongBacSi_TraVeThongTinLuongHopLe()
        {
            // Arrange
            int id = 6; // Replace with a valid doctor ID
            DateTime firstDayOfMonth = new DateTime(2023, 11, 1);
            DateTime lastDayOfMonth = new DateTime(2024, 11, 30);

            // Act
            LuongDTO ketQua = _luongDAO.LuongBacSi(id, firstDayOfMonth, lastDayOfMonth);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(id, ketQua.Id);
        }

        [Fact]
        public void CapNhatLuong_CapNhatThanhCong_KhongNemNgoaiLe()
        {
            // Arrange
            var luongCapNhat = new LuongDTO
            {
                Id = 1, // Replace with a valid ID
                HeSoLuong = 2.0f,
                LuongCoBan = 5000f,
                Thuong = 1000f,
                Phat = 200f,
                PhuCap = 300f
            };

            // Act & Assert
            var exception = Record.Exception(() => _luongDAO.CapNhatLuong(luongCapNhat));
            Assert.Null(exception);
        }

        [Fact]
        public void LuongLeTan_TraVeThongTinLuongHopLe()
        {
            // Arrange
            int id = 1; // Replace with a valid receptionist ID
            DateTime firstDayOfMonth = new DateTime(2023, 11, 1);
            DateTime lastDayOfMonth = new DateTime(2024, 11, 30);

            // Act
            LuongDTO ketQua = _luongDAO.LuongLeTan(id, firstDayOfMonth, lastDayOfMonth);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(id, ketQua.Id);
        }
    }
}
