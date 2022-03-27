using bCommerce.Models.Cart;

namespace bCommerce.Web.Infrastructure.Services.Cart;

public class CartService : ICartService
{
    private readonly HttpClient _httpClient;

    private const string CartPath = "api/carts";

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddProduct(CartRequestModel model) => await _httpClient.PostAsJsonAsync(CartPath, model);

    public async Task<IEnumerable<CartProductResponseModel>> ByUserId() => 
        await _httpClient.GetFromJsonAsync<IEnumerable<CartProductResponseModel>>(CartPath);
}
