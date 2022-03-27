using bCommerce.Core.Entities;

namespace bCommerce.Web.Infrastructure.Services.Products;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    private const string ProductsPath = "api/products";

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => 
        await _httpClient.GetFromJsonAsync<IEnumerable<Product>>(ProductsPath);
}
