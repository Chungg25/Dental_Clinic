using Xunit;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;

namespace Dental_Clinic.Tests.DAO.BenhNhan
{
    public class BenhNhanDAOIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly BenhNhanDAO _benhNhanDAO;
        private readonly SqlConnection _testConnection;

        public BenhNhanDAOIntegrationTests(DatabaseFixture fixture)
        {
            // Use the test database connection from the fixture
            _testConnection = fixture.TestDatabaseConnection;
            _benhNhanDAO = new BenhNhanDAO();
        }

        [Fact]
        public void BenhNhanDAO_LayDanhSachBenhNhan_TraVeDanhSachBenhNhan()
        {
            // Act
            List<BenhNhanDTO> result = _benhNhanDAO.LayDanhSachBenhNhan();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void BenhNhanDAO_LayThongTinBenhNhan_TraVeThongTinBenhNhan()
        {
            // Arrange
            int maBenhNhan = 1;

            // Act
            BenhNhanDTO result = _benhNhanDAO.LayThongTinBenhNhan(maBenhNhan);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(maBenhNhan, result.Id);
        }

        [Fact]
        public void BenhNhanDAO_CapNhatBenhNhan_ThayDoiThongTinBenhNhan()
        {
            // Arrange
            BenhNhanDTO benhNhanThongTinMoi = new BenhNhanDTO
            {
                Id = 1,
                HoVaTen = "Nguyen Van A",
                SDT = "0123456789",
                DiaChi = "123 Pho Hue",
                GioiTinh = true,
                Tuoi = 25
            };

            BenhNhanDTO benhNhanThongTinCu = _benhNhanDAO.LayThongTinBenhNhan(benhNhanThongTinMoi.Id);


            // Act
            _benhNhanDAO.CapNhatBenhNhan(benhNhanThongTinMoi);

            // Assert
            Assert.NotEqual(benhNhanThongTinCu, benhNhanThongTinMoi);
        }

        /*
        TODO: Thang nao viet cai procedure ThemBenhNhan thi coi lai ban than !!!!!
         */   
        // [Fact]
        // public void BenhNhanDAO_ThemBenhNhan_ThemBenhNhanMoi()
        // {
        //     // Arrange
        //     BenhNhanDTO benhNhanMoi = new BenhNhanDTO
        //     {
        //         HoVaTen = "Nguyen Van A",
        //         SDT = "0123456789",
        //         DiaChi = "123 Pho Hue",
        //         GioiTinh = true,
        //         Tuoi = 25
        //     };

        //     // Act
        //     _benhNhanDAO.ThemBenhNhan(benhNhanMoi);

        //     // Assert
        //     BenhNhanDTO benhNhanVuaThem = _benhNhanDAO.LayThongTinBenhNhan(benhNhanMoi.Id);
        //     Assert.NotNull(benhNhanVuaThem);
        //     Assert.Equal(benhNhanMoi, benhNhanVuaThem);
        // }
    }
}
