namespace Asp07Store.ShopUI.Models
{
    public record ProductListViewModel
    {
        public PagedData<Product>? Data { get; set; }
        public string? CurrentCategory { get; set; }
    }
}
