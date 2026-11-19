using Microsoft.Data.SqlClient;

namespace KaraokeManagement.DAL
{
    public class DBConnection
    {
        private static readonly string connectionString =
            @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=KaraokeDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}