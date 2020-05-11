using SkateStore.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Products.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAsync();
        public void Add(Product data);
    }
}
