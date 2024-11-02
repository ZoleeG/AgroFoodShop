using AgroFoodShop.Models;

namespace AgroFoodShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOfTheWeek { get; }
        public HomeViewModel(IEnumerable<Product> productsOfTheWeek)
        {
            ProductsOfTheWeek = productsOfTheWeek;
        }
    }
}
