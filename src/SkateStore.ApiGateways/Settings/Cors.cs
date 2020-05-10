using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SkateStore.ApiGateways.Settings
{
    public static class Cors
    {
        private static readonly string policyName = "AllowOrigin";
        public static void AddCorsAndConfig(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(policyName, policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                );
            });
        }

        public static void UseSettingCors(this IApplicationBuilder app)
        {
            app.UseCors(policyName);
        }

    }
}
