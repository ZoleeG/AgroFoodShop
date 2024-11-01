namespace AgroFoodShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId = 1, CategoryName = "Fruits", Description = "All freshly picked fruits"},
                new Category{CategoryId = 2, CategoryName = "Vegetables", Description = "All freshly picked vegetables"},
                new Category{CategoryId = 3, CategoryName = "Grains", Description = "All of our grains"},
                new Category{CategoryId = 4, CategoryName = "Dairy", Description = "All products derived from milk"},
                new Category{CategoryId = 5, CategoryName = "Honey", Description = "All the different types of honey and its byproducts"}
            };
    }
}
