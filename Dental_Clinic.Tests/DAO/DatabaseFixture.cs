using System;
using System.Data.SqlClient;

namespace Dental_Clinic.Tests.DAO 
{
    public class DatabaseFixture : IDisposable
{
    public SqlConnection TestDatabaseConnection { get; private set; }

    public DatabaseFixture()
    {
        // Initialize the test database connection
        // Sample MSSQL connection string
        // Replace with your actual test database connection string
        TestDatabaseConnection = new SqlConnection("Server=TRI-LUU\\PLEASE;Database=DentalClinicTests;User Id=sa;Password=1234;");
        TestDatabaseConnection.Open();
    }

    public void Dispose()
    {
        // Clean up the database connection after tests are done
        TestDatabaseConnection.Close();
        TestDatabaseConnection.Dispose();
    }
}

}