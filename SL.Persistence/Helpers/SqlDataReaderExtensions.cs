using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence.Helpers
{
    public static class SqlDataReaderExtensions
    {
        public static IEnumerable<T> ConvertToObject<T>(this SqlDataReader rd) where T : class, new()
        {
            List<T> list = new List<T>();
            
            var parser = rd.GetRowParser<T>(typeof(T));

            while (rd.Read())
            {
                T type = parser(rd);
                list.Add(type);
            }
            return list.AsEnumerable<T>();
        }
    }
}
