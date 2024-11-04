using Xunit;
using System;
using Dental_Clinic.DAO.ThongKe;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO.ThongKe
{
    public class ThongKeDAOTests : IClassFixture<DatabaseFixture>
    {
        private readonly ThongKeDAO _thongKeDAO;
        private readonly SqlConnection _testConnection;

        public ThongKeDAOTests(DatabaseFixture fixture)
        {
            _testConnection = fixture.TestDatabaseConnection;
            _thongKeDAO = new ThongKeDAO();
        }

        [Fact]
        public void TienThuoc_ReturnsValidTotalAmount()
        {
            // Arrange
            DateTime date = new DateTime(2024, 11, 1);

            // Act
            float result = _thongKeDAO.TienThuoc(date);

            // Assert
            Assert.True(result >= 0, "The returned total should be a non-negative value.");
        }
    }
}
