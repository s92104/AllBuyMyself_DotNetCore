using AllBuyMyself.Models.Common.Table;
using AllBuyMyself.Models.Shopping.ShoppingCart;

namespace AllBuyMyself.Services.Shopping
{
    public class ShoppingCartService
    {
        private readonly AllBuyMyselfDbContext _context;
        public ShoppingCartService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetShoppingCartItemResp> GetShoppingCartItems(string username)
        {
            List<GetShoppingCartItemResp> resp = _context.ShoppingCarts
            .Where(x => x.Username == username)
                .Join(_context.Products, shoppingCart => shoppingCart.ProductId, product => product.Id, (shoppingCart, product) => new GetShoppingCartItemResp
                {
                    Id = shoppingCart.ProductId,
                    Name = product.Name,
                    Image_path = product.Image_path,
                    Price = product.Price,
                    Amount = shoppingCart.Amount
                })
                .ToList();
            return resp;
        }

        public bool DeleteShoppingCartItem(DeleteShoppingCartItemReq req)
        {
            ShoppingCart shoppingCart = _context.ShoppingCarts
                .Where(x => x.Username == req.Username && x.ProductId == req.ProductId)
                .First();

            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();

            return true;
        }

        public bool Checkout(CheckoutReq req)
        {
            AddOrder(req.Username);
            DeleteShoppingCartAllItem(req.Username);

            _context.SaveChanges();

            return true;
        }

        public void AddOrder(string username)
        {
            List<ShoppingCart> shoppingCarts = _context.ShoppingCarts
                .Where(x => x.Username == username)
                .ToList();

            string guid = Guid.NewGuid().ToString();
            DateTime now = DateTime.Now;
            shoppingCarts.ForEach(x =>
            {
                Order order = new()
                {
                    Username = username,
                    Id = guid,
                    ProductId = x.ProductId,
                    Amount = x.Amount,
                    Time = now
                };

                _context.Orders.Add(order);
            });
        }

        public void DeleteShoppingCartAllItem(string username)
        {
            IEnumerable<ShoppingCart> shoppingCarts = _context.ShoppingCarts
                .Where(x => x.Username == username)
                .ToList();

            _context.ShoppingCarts.RemoveRange(shoppingCarts);
        }
    }
}
