using Xunit;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dental_Clinic.DAO.Patient;
using Dental_Clinic.DTO.Patient;

namespace Dental_Clinic.Tests.DAO.BenhNhan
{
    public class BenhNhanTests
    {
        private readonly BenhNhanDAO _benhNhanDAO;

        public BenhNhanTests()
        {
            // Use the test database connection from the fixture
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
    }
}
