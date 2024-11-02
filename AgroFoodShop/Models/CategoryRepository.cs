
namespace AgroFoodShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AgroFoodShopDbContext _agroFoodShopDbContext;

        public CategoryRepository(AgroFoodShopDbContext agroFoodShopDbContext)
        {
            _agroFoodShopDbContext = agroFoodShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _agroFoodShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
