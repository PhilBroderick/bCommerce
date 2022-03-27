namespace bCommerce.Core.Entities;

public class Cart
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public ICollection<CartProduct> Products { get; set; } = new HashSet<CartProduct>();
}
