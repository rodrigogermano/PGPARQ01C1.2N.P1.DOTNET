﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SkateStore.ApiGateways.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SkateStore.ApiGateways.Settings
{
    public static class InjectionDependency
    {
        public static void AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<IHttpClientProvider, HttpClientProvider>();            
        }
    }
}
