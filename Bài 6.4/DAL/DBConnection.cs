using Microsoft.Data.SqlClient;

namespace GarageManagement.DAL
{
    public class DBConnection
    {
        private static readonly string connectionString =
            @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GarageDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
