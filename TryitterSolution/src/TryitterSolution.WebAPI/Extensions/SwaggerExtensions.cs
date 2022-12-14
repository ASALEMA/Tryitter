using Microsoft.OpenApi.Models;

namespace TryitterSolution.WebAPI.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tryitter API",
                    Description = "Api de rede social para Posts."
                });
                options.EnableAnnotations();

            });
            return services;
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
