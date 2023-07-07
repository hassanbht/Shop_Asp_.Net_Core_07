namespace Asp07Store.ShopUI.Models
{
    public record OrderDetail
    {
        public int Id { get; set; }
        public Product?  Product { get; set; }
        public int Quantity { get; set; }
    }
}
