
using Microsoft.EntityFrameworkCore;

namespace AgroFoodShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AgroFoodShopDbContext _agroFoodShopDbContext;

        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(AgroFoodShopDbContext agroFoodShopDbContext)
        {
            _agroFoodShopDbContext = agroFoodShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            AgroFoodShopDbContext context = services.GetService<AgroFoodShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = _agroFoodShopDbContext.ShoppingCartItems.SingleOrDefault(s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                _agroFoodShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _agroFoodShopDbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _agroFoodShopDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);

            _agroFoodShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _agroFoodShopDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                _agroFoodShopDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Product)
                .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _agroFoodShopDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount)
                .Sum();

            return total;
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _agroFoodShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _agroFoodShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _agroFoodShopDbContext.SaveChanges();
            return localAmount;
        }
    }
}
