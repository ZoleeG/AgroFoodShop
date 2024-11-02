using AgroFoodShop.Models;
using AgroFoodShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgroFoodShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var productsOfTheWeek = _productRepository.ProductsOfTheWeek;
            var homeViewModel = new HomeViewModel(productsOfTheWeek);
            return View(homeViewModel);
        }
    }
}
