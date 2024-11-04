using Xunit;
using System;
using System.Collections.Generic;
using Dental_Clinic.DAO.Admin;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.DTO.BacSi;
using Dental_Clinic.DTO.LeTan;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.Admin
{
    public class QuanTriVienDAOTests : IClassFixture<DatabaseFixture>
    {
        private readonly QuanTriVienDAO _quanTriVienDAO;
        private readonly SqlConnection _testConnection;

        public QuanTriVienDAOTests(DatabaseFixture fixture)
        {
            _testConnection = fixture.TestDatabaseConnection;
            _quanTriVienDAO = new QuanTriVienDAO();
        }

        [Fact]
        public void SoLuongBacSi_TraVeSoLuongHopLe()
        {
            // Act
            int ketQua = _quanTriVienDAO.SoLuongBacSi();

            // Assert
            Assert.True(ketQua >= 0);
        }

        [Fact]
        public void SoLuongBenhNhan_TraVeSoLuongHopLe()
        {
            // Act
            int ketQua = _quanTriVienDAO.SoLuongBenhNhan();

            // Assert
            Assert.True(ketQua >= 0);
        }

        [Fact]
        public void TongLuong_TraVeTongLuongHopLe()
        {
            // Act
            int ketQua = _quanTriVienDAO.TongLuong();

            // Assert
            Assert.True(ketQua >= 0);
        }

        [Fact]
        public void LayDanhSachBacSi_TraVeDanhSachHopLe()
        {
            // Act
            List<BacSiDTO> ketQua = _quanTriVienDAO.LayDanhSachBacSi();

            // Assert
            Assert.NotNull(ketQua);
            Assert.NotEmpty(ketQua);
        }

        [Fact]
        public void LayThongTinBacSi_TraVeThongTinDung()
        {
            // Arrange
            int id = 1;

            // Act
            BacSiDTO ketQua = _quanTriVienDAO.LayThongTinBacSi(id);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(id, ketQua.Id);
        }
    }
}
