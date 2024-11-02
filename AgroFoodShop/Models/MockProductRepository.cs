
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgroFoodShop.Models
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Product> AllProducts =>
        new List<Product>
        {
                new Product {ProductId = 1, Name = "Golden Delicious apples", Price = 1.99M, ShortDescription = "1 kg of Golden Delicious apples", LongDescription = "All our Golden Delicious apples are hand picked from carefully tended orchards. This ensures they are of the highest standard with a sweet, mild flavour. Harvest time: September - October", Category = _categoryRepository.AllCategories.ToList()[0], ImageURL = "https://live.staticflickr.com/65535/54107838909_45541e80ba_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107838909_45541e80ba_o.jpg"},
                new Product {ProductId = 2, Name = "Butternut squash", Price = 3.09M, ShortDescription = "1 kg of Butternut squash", LongDescription = "Butternut squash has a clean, creamy flavour, thin skin, and the highest proportion of flesh to cavity.", Category = _categoryRepository.AllCategories.ToList()[1], ImageURL = "https://live.staticflickr.com/65535/54107950010_9cd51a25ce_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107950010_9cd51a25ce_o.jpg"},
                new Product {ProductId = 3, Name = "Wheat", Price = 90.95M, ShortDescription = "100 kg Raw Whole Wheat grains", LongDescription = "Whole wheat grains cleaned (dust removed) graded. Our wheat grains are grown in the UK. The grain is not treated with any chemical when it is stored and may contain 0.03% chaff. It is dried with hot air to a moisture content of 14%. These grains can be used for making Heated Wheat Bags and Craft items.", Category = _categoryRepository.AllCategories.ToList()[2], ImageURL = "https://live.staticflickr.com/65535/54106629292_b4b424b69b_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54106629292_b4b424b69b_o.jpg"},
                new Product {ProductId = 4, Name = "Tvorog (Túró)", Price = 2.12M, ShortDescription = "500g of Tvorog (Túró)", LongDescription = "Fresh dairy product made from milk. The milk is soured by adding lactic acid bacteria cultures, and strained once the desired curdling is achieved. It can be classified as fresh acid-set cheese. It is soft, white and unaged, no salt is added.", Category = _categoryRepository.AllCategories.ToList()[3], ImageURL = "https://live.staticflickr.com/65535/54107949950_b51f6c6c52_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107949950_b51f6c6c52_o.jpg"},
                new Product {ProductId = 5, Name = "Propolis extract", Price = 5.12M, ShortDescription = "ORGANIC RAW PROPOLIS", LongDescription = "Our water based PROPOLIS is entirely raw and untouched, developed through a distinctive process that preserves all the antioxidant compounds found within propolis as it naturally exists in the hive. It has never been subjected to heat, pasteurization, or boiling, ensuring a 100% bio-available composition.", Category = _categoryRepository.AllCategories.ToList()[4], ImageURL = "https://live.staticflickr.com/65535/54107844874_0b10a3b873_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107844874_0b10a3b873_o.jpg"}
            };

        public IEnumerable<Product> ProductsOfTheWeek
        {
            get
            {
                return AllProducts.Where(p => p.IsProductOfTheWeek);
            }
        }

        public Product? GetProductById(int productId) => AllProducts.FirstOrDefault(p => p.ProductId == productId);
    }
}
