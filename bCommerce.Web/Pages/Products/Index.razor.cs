using bCommerce.Core.Entities;
using bCommerce.Models.Cart;
using bCommerce.Web.Infrastructure.Services.Cart;
using bCommerce.Web.Infrastructure.Services.Products;
using Microsoft.AspNetCore.Components;

namespace bCommerce.Web.Pages.Products;

public partial class Index
{
    private IEnumerable<Product> _products;

    [Parameter]
    public int Page { get; set; } = 1;

    [Inject]
    IProductService ProductService { get; set; }

    [Inject]
    ICartService CartService { get; set; }

    protected override async Task OnInitializedAsync() => await LoadData();

    private async Task LoadData()
    {
        if (Page == 0)
        {
            Page = 1;
        }

        _products = await ProductService.GetAllAsync();
    }

    private async Task AddToCart(int id)
    {
        var cartRequest = new CartRequestModel
        {
            ProductId = id,
            Quantity = 1,
        };

        await CartService.AddProduct(cartRequest);
    }
}
