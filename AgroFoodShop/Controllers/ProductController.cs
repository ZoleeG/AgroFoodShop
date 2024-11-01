using AgroFoodShop.Models;
using AgroFoodShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgroFoodShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult List()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(_productRepository.AllProducts, "Dairy");
            return View(productListViewModel);
        }
    }
}
