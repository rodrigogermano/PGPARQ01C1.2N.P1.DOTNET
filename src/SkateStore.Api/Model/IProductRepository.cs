using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkateStore.Api.Model
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAsync();
        public int Save(Product data);
    }
}
