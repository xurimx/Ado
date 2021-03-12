using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence.DB
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
