using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SL.Domain.Entities;
using SL.Persistence.DB;
using SL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<IGenericRepository<Person>, PeopleRepository>();

            return services;
        }
    }
}
