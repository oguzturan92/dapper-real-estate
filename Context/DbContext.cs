using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperRealEstate.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection"); // appsettings.json içerisindeki bağlantı adresi adını olduğu gibi yazıyoruz.
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}