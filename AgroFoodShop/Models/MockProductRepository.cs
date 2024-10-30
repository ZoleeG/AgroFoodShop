
using static System.Net.WebRequestMethods;

namespace AgroFoodShop.Models
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Product> AllProducts =>
        new List<Product>
        {
                new Product {ProductId = 1, Name = "Golden Delicious apples", Price = 1.99M, ShortDescription = "1 kg of Golden Delicious apples", LongDescription = "All our Golden Delicious apples are hand picked from carefully tended orchards. This ensures they are of the highest standard with a sweet, mild flavour. Harvest time: September - October", Category = _categoryRepository.AllCategories.ToList()[0], ImageURL = "https://photos.google.com/album/AF1QipNrVrtZI6UfTSUxuBcU3bM7nF-x7dP7ZrP68xEt/photo/AF1QipO5ICkM3Btd1unZprYGjlc0o2VGBq29GlRIiWDB", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://photos.google.com/album/AF1QipNrVrtZI6UfTSUxuBcU3bM7nF-x7dP7ZrP68xEt/photo/AF1QipP31476iQGhwPgvAG5-xLmVE42_5SeiBStj_pCc"},
                new Product {ProductId = 2, Name = "Butternut squash", Price = 3.09M, ShortDescription = "1 kg of Butternut squash", LongDescription = "Butternut squash has a clean, creamy flavour, thin skin, and the highest proportion of flesh to cavity.", Category = _categoryRepository.AllCategories.ToList()[1], ImageURL = "https://photos.fife.usercontent.google.com/pw/AP1GczO5AmL2OUq3N0kPpwPXBqJfpXV7w9MjqAzwlHF5OCjRP6PtxRQFH_k=w593-h889-s-no?authuser=0", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://photos.fife.usercontent.google.com/pw/AP1GczNod0fYo3tbZQSRuzNegP51KgLkGyAjxAOlIn7EQguJSOkXJNcIbu8=w240-h360-s-no?authuser=0"},
                new Product {ProductId = 3, Name = "Wheat", Price = 164.95M, ShortDescription = "100 kg Raw Whole Wheat grains", LongDescription = "Whole wheat grains cleaned (dust removed) graded. Our wheat grains are grown in the UK. The grain is not treated with any chemical when it is stored and may contain 0.03% chaff. It is dried with hot air to a moisture content of 14%. These grains can be used for making Heated Wheat Bags and Craft items.", Category = _categoryRepository.AllCategories.ToList()[2], ImageURL = "https://photos.fife.usercontent.google.com/pw/AP1GczMDkdcDLnNE0Lu8_M6tkw9C891irNLs9mTOzLOw7iPkt26Riwy7swk=w1318-h889-s-no?authuser=0", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://photos.fife.usercontent.google.com/pw/AP1GczOjB3mde3SqGd9gJg4FCHYjo-ECvAfrZYXaNz6psdeNu0bZgDieDRY=w650-h438-s-no?authuser=0"},
                new Product {ProductId = 4, Name = "Tvorog (Túró)", Price = 2.12M, ShortDescription = "500g of Tvorog (Túró)", LongDescription = "Fresh dairy product made from milk. The milk is soured by adding lactic acid bacteria cultures, and strained once the desired curdling is achieved. It can be classified as fresh acid-set cheese. It is soft, white and unaged, no salt is added.", Category = _categoryRepository.AllCategories.ToList()[3], ImageURL = "https://photos.fife.usercontent.google.com/pw/AP1GczPJpAxU_Grgb4nDHPBmlmxaghZogO4mmpYiVMHNDBTdYbUqbQyZQ3U=w1334-h889-s-no?authuser=0", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://photos.fife.usercontent.google.com/pw/AP1GczPitYK18Lx4szei7A7SS9j3Y_K1JSlCHY3nrQ34rSBn95on4h7zb9U=w300-h200-s-no?authuser=0"},
                new Product {ProductId = 5, Name = "Propolis extract", Price = 5.12M, ShortDescription = "ORGANIC RAW PROPOLIS", LongDescription = "Our water based PROPOLIS is entirely raw and untouched, developed through a distinctive process that preserves all the antioxidant compounds found within propolis as it naturally exists in the hive. It has never been subjected to heat, pasteurization, or boiling, ensuring a 100% bio-available composition.", Category = _categoryRepository.AllCategories.ToList()[4], ImageURL = "https://photos.fife.usercontent.google.com/pw/AP1GczOYzUcMk6n1u_XTNTsEDTWd7tYrVIWf4YNBoG1UA5iDiZII8wP_-b0=w889-h889-s-no?authuser=0", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://photos.fife.usercontent.google.com/pw/AP1GczOX77yXpDaiPtLShNltujItyCjZcwa4lYKbrdtxGtSJGxRWvyY92bQ=w280-h280-s-no?authuser=0"}
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
