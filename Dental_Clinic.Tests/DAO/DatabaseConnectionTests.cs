using System.Data.SqlClient;
using Dental_Clinic.DAO;

namespace Dental_Clinic.Tests
{
    public class DatabaseConnectionTests
    {
        [Fact]
        public void DatabaseConnection_OpenConnection_ConnectionIsOpen()
        {
            // Act
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Assert
            Assert.NotNull(dbConnection.Conn);
            Assert.IsType<SqlConnection>(dbConnection.Conn);

            // Clean up
            dbConnection.Conn.Close();
        }
    }
}
