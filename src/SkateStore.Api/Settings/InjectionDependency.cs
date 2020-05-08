using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SkateStore.Api.Infrastructure.Contexts;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SkateStore.Api.Settings
{
    public static class InjectionDependency
    {
        public static void AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SkateStoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SkateStoreDbContext"));
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();            
        }
    }
}
