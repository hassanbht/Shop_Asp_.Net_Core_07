namespace Asp07Store.ShopUI.Models
{
    public record BasketPageViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
    }
}
