using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkateStore.Products.Domain.Commands.Handlers;
using SkateStore.Products.Domain.Repositories;
using SkateStore.Products.Infra.Data.Contexts;
using SkateStore.Products.Infra.Data.Repositories;
using SkateStore.Products.Infra.Data.Transactions;

namespace SkateStore.Products.Application.gRPC.Settings
{
    public static class InjectionDependency
    {
        public static void AddInjectionDependency(this IServiceCollection services, IConfiguration configuration)
        {                        
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductDbContext"));
            });
                        
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductHandler, ProductHandler>();
            services.AddTransient<IUow, Uow>();

        }
    }
}
