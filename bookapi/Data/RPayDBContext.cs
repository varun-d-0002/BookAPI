using Npgsql;
using System.Data;

namespace bookapi.Data
{
    public class RPayDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public RPayDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
