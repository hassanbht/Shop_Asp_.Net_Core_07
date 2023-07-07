using Asp07Store.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop_Asp.Net.Core_07.Domain.Setting;

namespace Asp07Store.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOptions<AppSettings> _appSettings;
        public HomeController(IProductRepository productRepository, IOptions<AppSettings> appSettings)
        {
            this.productRepository = productRepository;
            _appSettings = appSettings;
        }
        public IActionResult Index(string category = "",int pageNumber = 1)
        {           
            var viewModel = new ProductListViewModel
            {
                CurrentCategory = category,
                Data = productRepository.GetAll(pageNumber, _appSettings.Value.pageSize, category)
            };
            return View(viewModel);
        }
    }
}
