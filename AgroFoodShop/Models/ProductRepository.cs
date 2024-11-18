using Microsoft.EntityFrameworkCore;

namespace AgroFoodShop.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AgroFoodShopDbContext _agroFoodShopDbContext;
        public ProductRepository(AgroFoodShopDbContext agroFoodShopDbContext)
        {
            _agroFoodShopDbContext = agroFoodShopDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _agroFoodShopDbContext.Products.Include(p => p.Category);
            }
        }

        public IEnumerable<Product> ProductsOfTheWeek
        {
            get
            {
                return _agroFoodShopDbContext.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
            }
        }

        public Product? GetProductById(int productId)
        {
            return _agroFoodShopDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            return _agroFoodShopDbContext.Products.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
