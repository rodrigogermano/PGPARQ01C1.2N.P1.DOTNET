using Microsoft.EntityFrameworkCore;
using SkateStore.Products.Domain.Entities;
using SkateStore.Products.Domain.Repositories;
using SkateStore.Products.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateStore.Products.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Product>> GetAsync()
        {
            return await this._context.Products.ToListAsync();
        }

        public void Add(Product data)
        {
            this._context.Products.Add(data);            
        }
    }
}
