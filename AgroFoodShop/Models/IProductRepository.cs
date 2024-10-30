namespace AgroFoodShop.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> ProductsOfTheWeek { get; }
        Product? GetProductById(int productId);
    }
}
