using bCommerce.Core.Entities;

namespace bCommerce.Web.Infrastructure.Services.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
}
