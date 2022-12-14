using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Services;

namespace TryitterSolution.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();

            return services;
        }
    }
}
