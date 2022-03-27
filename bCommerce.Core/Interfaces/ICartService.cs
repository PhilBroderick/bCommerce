using bCommerce.Models.Cart;

namespace bCommerce.Core.Interfaces;
public interface ICartService
{
    Task AddProduct(CartRequestModel model, string userId);

    Task<IEnumerable<CartProductResponseModel>> ByUserId(string userId);
}
