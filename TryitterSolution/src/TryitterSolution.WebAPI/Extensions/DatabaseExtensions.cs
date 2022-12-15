using Microsoft.EntityFrameworkCore;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Repository;

namespace TryitterSolution.WebAPI.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TryitterContext>(optionsAction: options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITryitterContext, TryitterContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            
            return services;
        }
    }
}
