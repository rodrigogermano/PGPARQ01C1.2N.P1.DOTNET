using Microsoft.EntityFrameworkCore;
using SkateStore.Api.Infrastructure.Contexts;
using SkateStore.Api.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateStore.Api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SkateStoreContext _context;
        public ProductRepository(SkateStoreContext context)
        {
            _context = context;
        }      

        public async Task<List<Product>> GetAsync()
        {
            return await this._context.Products.ToListAsync();
        }

        public int Save(Product data)
        {
            this._context.Products.Add(data);
            return _context.SaveChanges();
        }
    }
}
