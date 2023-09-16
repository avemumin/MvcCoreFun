using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("DefaultConnectionString");
           
            services.AddDbContext<CarWorkshopDbContext>(options =>
            {
                options.UseSqlServer(connStr);
            });

            services.AddScoped<CarWorkshopSeeder>();

            services.AddScoped<ICarWorkshopRepository,CarWorkshopRepository>();
        }

        
    }
}
