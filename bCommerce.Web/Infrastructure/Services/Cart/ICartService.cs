using bCommerce.Models.Cart;

namespace bCommerce.Web.Infrastructure.Services.Cart;

public interface ICartService
{
    Task AddProduct(CartRequestModel model);

    Task<IEnumerable<CartProductResponseModel>> ByUserId();
}
