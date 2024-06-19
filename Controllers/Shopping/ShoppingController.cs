using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Shopping;
using AllBuyMyself.Services.Shopping;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Shopping
{
    public class ShoppingController : ControllerBase
    {
        private readonly ShoppingService _shoppingService;
        public ShoppingController(ShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<GetProductListResp>> GetProductList(string username)
        {
            IEnumerable<GetProductListResp> resp = _shoppingService.GetProductList(username);
            return new(resp);
        }

        [HttpGet]
        public ApiResult<GetProductInfoResp?> GetProductInfo(int id, string username)
        {
            GetProductInfoResp? resp = _shoppingService.GetProductInfo(id, username);
            return new(resp);
        }

        [HttpPost]
        public ApiResult<bool> AddShoppingCart([FromBody] AddShoppingCartReq req)
        {
            bool isSuccess = _shoppingService.AddShoppingCart(req);
            return new(isSuccess);
        }
    }
}
