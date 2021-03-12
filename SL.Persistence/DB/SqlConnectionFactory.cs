using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence.DB
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            var conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            conn.Open();
            return conn;
        }
        
    }
}
