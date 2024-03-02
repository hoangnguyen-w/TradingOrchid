using Application.Interfaces.Roles;
using Application.Interfaces.Users;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepositoy, UserRepositoy>();
            //services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services.AddDbContext<TradingOrchidContext>
                (options => options.UseSqlServer(GetConnectionString()));
        }
        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();

            return config.GetConnectionString("DefaultConnectionString")!;
        }
    }
}
