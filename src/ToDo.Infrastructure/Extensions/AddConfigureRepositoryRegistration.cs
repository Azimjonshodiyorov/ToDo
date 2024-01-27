using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure.Extensions
{
    public static class AddConfigureRepositoryRegistration
    {
        public static IServiceCollection AddRepositoriesConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<ToDoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TodoConnectionString")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoryRepository, CategoreRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }

        public static IHost AddRepositoreyData(this IHost webHost)
        {
            using(var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var dbContext = services.GetRequiredService<ToDoDbContext>();

                    TodoDbInitializer.Initializer(dbContext);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return webHost;
        }


    }
}
