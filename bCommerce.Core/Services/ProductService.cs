using bCommerce.Core.Entities;
using bCommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bCommerce.Core.Services;

public class ProductService : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = new List<Product>();
        products.Add(new Product { Id = 1, Name = "Keyboard", Description = "This is a keyboard" });
        return products;
    }
}
