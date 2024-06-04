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

        public IEnumerable<GetProductListResp> GetProductList()
        {
            List<GetProductListResp> resp = _context.Products.Select(x => new GetProductListResp(x)).ToList();
            return resp;
        }

        public GetProductInfoResp? GetProductInfo(int id)
        {
            GetProductInfoResp? resp = _context.Products.Where(x => x.Id == id).Select(x => new GetProductInfoResp(x)).FirstOrDefault();
            return resp;
        }
    }
}
