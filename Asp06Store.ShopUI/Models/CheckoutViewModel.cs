using System.ComponentModel.DataAnnotations;

namespace Asp07Store.ShopUI.Models
{
    public record CheckoutViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
