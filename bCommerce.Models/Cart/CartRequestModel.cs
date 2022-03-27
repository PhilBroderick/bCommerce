using System.ComponentModel.DataAnnotations;

namespace bCommerce.Models.Cart;

public class CartRequestModel
{
    [Required]
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
