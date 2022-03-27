using bCommerce.Core.Entities;

namespace bCommerce.Core.Interfaces;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
}
