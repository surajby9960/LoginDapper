using System.Data;
using System.Data.SqlClient;

namespace LoginDapper.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionstring = _configuration.GetConnectionString("sqlConnection");
        }
        public IDbConnection CreateConnection()
            =>new SqlConnection(connectionstring);
    }
}
