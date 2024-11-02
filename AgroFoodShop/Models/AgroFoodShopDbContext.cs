using Microsoft.EntityFrameworkCore;

namespace AgroFoodShop.Models
{
    public class AgroFoodShopDbContext : DbContext
    {
        public AgroFoodShopDbContext(DbContextOptions<AgroFoodShopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
