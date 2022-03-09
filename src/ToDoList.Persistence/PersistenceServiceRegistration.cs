using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Persistence.Repositories;

namespace ToDoList.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPeristenceServices(this IServiceCollection services, IConfiguration configuration, string databaseName)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IToDoTaskRepository), typeof(ToDoTaskRepository));

            return services;
        }
    }
}
