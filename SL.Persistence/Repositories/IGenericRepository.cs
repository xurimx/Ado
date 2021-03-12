using SL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<Person> FindById(Guid id);
        Task<IEnumerable<T>> FindAll();
        Task Insert(T entity);
    }
}
