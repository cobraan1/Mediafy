using System.Collections.Generic;
using System.Threading.Tasks;
using Mediafy.Shared;

namespace Mediafy.Server.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> UpdateProductAsync(Product product);
    }
}