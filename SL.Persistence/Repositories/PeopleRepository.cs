using SL.Domain.Entities;
using SL.Persistence.DB;
using SL.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence.Repositories
{
    public class PeopleRepository : IGenericRepository<Person>
    {
        private readonly ISqlConnectionFactory connectionFactory;

        public PeopleRepository(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<Person> FindById(Guid id)
        {
            var sql = "Select * from People p where p.Id=@Id";
            using (var conn = connectionFactory.CreateConnection())
            {
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                var reader = await cmd.ExecuteReaderAsync();
                var person = reader.ConvertToObject<Person>().FirstOrDefault();
                return await Task.FromResult(person);
            }
        }

        public async Task<IEnumerable<Person>> FindAll()
        {
            var sql = "Select * from People";
            using (var conn = connectionFactory.CreateConnection())
            {
                var cmd = new SqlCommand(sql, conn);
                var reader = await cmd.ExecuteReaderAsync();
                var people = reader.ConvertToObject<Person>();
                return await Task.FromResult(people);
            }
        }

        public async Task Insert(Person entity)
        {
            var sql = "insert into People(\"id\", \"name\") values (@Id, @Name)";
            using (var conn = connectionFactory.CreateConnection())
            {                
                var cmd = new SqlCommand(sql, conn, conn.BeginTransaction());
                cmd.Parameters.Add(new SqlParameter("@Id", entity.Id));
                cmd.Parameters.Add(new SqlParameter("@Name", entity.Name));
                int v = await cmd.ExecuteNonQueryAsync();
                cmd.Transaction.Commit();
            }
        }
    }
}
