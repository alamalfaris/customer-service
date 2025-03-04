using Microsoft.Data.SqlClient;
using System.Data;

namespace customer_service.Helpers
{
    public class DapperContext
    {
        private readonly string? _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new ArgumentException("Connection string must filled!");
            }

            return new SqlConnection(_connectionString);
        }
    }
}
