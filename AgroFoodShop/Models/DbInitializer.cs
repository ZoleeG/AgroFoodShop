
namespace AgroFoodShop.Models
{
    public static class DbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AgroFoodShopDbContext context =
                applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AgroFoodShopDbContext>();
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                    (
                    new Product { Name = "Golden Delicious apples", Price = 1.99M, ShortDescription = "1 kg of Golden Delicious apples", LongDescription = "All our Golden Delicious apples are hand picked from carefully tended orchards. This ensures they are of the highest standard with a sweet, mild flavour. Harvest time: September - October", Category = Categories["Fruits"], ImageUrl = "https://live.staticflickr.com/65535/54107838909_45541e80ba_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107838909_45541e80ba_o.jpg" },
                    new Product { Name = "Butternut squash", Price = 3.09M, ShortDescription = "1 kg of Butternut squash", LongDescription = "Butternut squash has a clean, creamy flavour, thin skin, and the highest proportion of flesh to cavity.", Category = Categories["Vegetables"], ImageUrl = "https://live.staticflickr.com/65535/54107950010_9cd51a25ce_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107950010_9cd51a25ce_o.jpg" },
                    new Product { Name = "Wheat", Price = 90.95M, ShortDescription = "100 kg Raw Whole Wheat grains", LongDescription = "Whole wheat grains cleaned (dust removed) graded. Our wheat grains are grown in the UK. The grain is not treated with any chemical when it is stored and may contain 0.03% chaff. It is dried with hot air to a moisture content of 14%. These grains can be used for making Heated Wheat Bags and Craft items.", Category = Categories["Grains"], ImageUrl = "https://live.staticflickr.com/65535/54106629292_b4b424b69b_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54106629292_b4b424b69b_o.jpg" },
                    new Product { Name = "Tvorog (Túró)", Price = 2.12M, ShortDescription = "500g of Tvorog (Túró)", LongDescription = "Fresh dairy product made from milk. The milk is soured by adding lactic acid bacteria cultures, and strained once the desired curdling is achieved. It can be classified as fresh acid-set cheese. It is soft, white and unaged, no salt is added.", Category = Categories["Dairy"], ImageUrl = "https://live.staticflickr.com/65535/54107949950_b51f6c6c52_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107949950_b51f6c6c52_o.jpg" },
                    new Product { Name = "Propolis extract", Price = 5.12M, ShortDescription = "ORGANIC RAW PROPOLIS", LongDescription = "Our water based PROPOLIS is entirely raw and untouched, developed through a distinctive process that preserves all the antioxidant compounds found within propolis as it naturally exists in the hive. It has never been subjected to heat, pasteurization, or boiling, ensuring a 100% bio-available composition.", Category = Categories["Honey"], ImageUrl = "https://live.staticflickr.com/65535/54107844874_0b10a3b873_o.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://live.staticflickr.com/65535/54107844874_0b10a3b873_o.jpg" }
                    );
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genreList = new Category[]
                    {
                        new Category {CategoryName = "Fruits"},
                        new Category {CategoryName = "Vegetables"},
                        new Category {CategoryName = "Grains"},
                        new Category {CategoryName = "Dairy"},
                        new Category {CategoryName = "Honey"}
                    };
                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genreList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }
                return categories;
            }
        }
    }
}
