namespace Asp07Store.ShopUI.Models;

public record BasketItem
{

    public int Id { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}

