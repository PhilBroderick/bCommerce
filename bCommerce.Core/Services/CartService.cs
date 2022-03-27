using bCommerce.Core.Entities;
using bCommerce.Core.Interfaces;
using bCommerce.Models.Cart;
using Microsoft.Extensions.Caching.Memory;

namespace bCommerce.Core.Services;

public class CartService : ICartService
{
    private readonly IMemoryCache _memoryCache;

    public CartService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task AddProduct(CartRequestModel model, string userId)
    {
        // check if cart exists
        var cartExistsForUser = _memoryCache.TryGetValue<Cart>(userId, out var cart);

        // if it does, check if product exists in cart
        if (cartExistsForUser)
        {
            var productExistsInCart = cart.Products.FirstOrDefault(p => p.ProductId == model.ProductId);

            // if it does, increment quantitiy
            if (productExistsInCart is not null)
            {
                productExistsInCart.Quantity += model.Quantity;
            }
            else
            {
                // if product doesn't exist, but cart does, add product to cart
                var newCartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = model.ProductId
                };
                cart.Products.Add(newCartProduct);
            }

            _memoryCache.Set(userId, cart);
        }
        // if cart doesn't exist, create and add product
        else
        {
            var newUserCart = new Cart
            {
                UserId = userId,
                Products = new List<CartProduct>
                {
                    new() { ProductId = model.ProductId, Quantity = model.Quantity }
                }
            };
            _memoryCache.Set(userId, newUserCart);
        }
    }

    public Task<IEnumerable<CartProductResponseModel>> ByUserId(string userId)
    {
        var cartExistsForUser = _memoryCache.TryGetValue<Cart>(userId, out var cart);

        throw new Exception();

    }
}
