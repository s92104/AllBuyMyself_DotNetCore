using AllBuyMyself.Models.Common.Table;
using AllBuyMyself.Models.Shopping;

namespace AllBuyMyself.Services.Shopping
{
    public class ShoppingService
    {
        private readonly AllBuyMyselfDbContext _context;
        public ShoppingService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetProductListResp> GetProductList(string username)
        {
            List<Save> saves = _context.Saves
                .Where(x => x.Username == username)
                .ToList();

            List<GetProductListResp> resp = _context.Products
                .Select(x => new GetProductListResp(x))
                .ToList();

            resp.ForEach(x => x.IsSave = saves.Any(save => save.ProductId == x.Id));

            return resp;
        }

        public GetProductInfoResp? GetProductInfo(int id, string username)
        {
            Save? save = _context.Saves
                .Where(x => x.Username == username && x.ProductId == id)
                .FirstOrDefault();

            GetProductInfoResp? resp = _context.Products
                .Where(x => x.Id == id)
                .Select(x => new GetProductInfoResp(x)
                {
                    IsSave = save != null
                })
                .FirstOrDefault();

            return resp;
        }

        public bool AddShoppingCart(AddShoppingCartReq req)
        {
            ShoppingCart? shoppingCart = GetShoppingCartItem(req.Username, req.ProductId);

            if (shoppingCart is not null)
            {
                shoppingCart.Amount = req.Amount;
            }
            else
            {
                ShoppingCart newShoppingCart = new()
                {
                    Username = req.Username,
                    ProductId = req.ProductId,
                    Amount = req.Amount,
                };
                _context.ShoppingCarts.Add(newShoppingCart);
            }

            _context.SaveChanges();

            return true;
        }

        public ShoppingCart? GetShoppingCartItem(string username, int productId)
        {
            ShoppingCart? item = _context.ShoppingCarts
                .Where(x => x.Username == username && x.ProductId == productId)
                .FirstOrDefault();

            return item;
        }
    }
}
