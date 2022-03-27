using bCommerce.Core.Interfaces;
using bCommerce.Models.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bCommerce.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost]
    public async Task AddProduct(CartRequestModel model) => await _cartService.AddProduct(model, "userId");

    [HttpGet]
    public async Task<IEnumerable<CartProductResponseModel>> GetMyCart() => await _cartService.ByUserId("userId");
}
