namespace AgroFoodShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AgroFoodShopDbContext _agroFoodShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(AgroFoodShopDbContext agroFoodShopDbContext, IShoppingCart shoppingCart)
        {
            _agroFoodShopDbContext = agroFoodShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _agroFoodShopDbContext.Orders.Add(order);

            _agroFoodShopDbContext.SaveChanges();
        }
    }
}
