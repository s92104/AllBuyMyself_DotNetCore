using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Shopping.ShoppingCart;
using AllBuyMyself.Services.Shopping;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Shopping
{
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<GetShoppingCartItemResp>> GetShoppingCartItems(string username)
        {
            IEnumerable<GetShoppingCartItemResp> resp = _shoppingCartService.GetShoppingCartItems(username);
            return new(resp);
        }

        [HttpDelete]
        public ApiResult<bool> DeleteShoppingCartItem(DeleteShoppingCartItemReq req)
        {
            bool isSuccess = _shoppingCartService.DeleteShoppingCartItem(req);
            return new(isSuccess);
        }

        [HttpPost]
        public ApiResult<bool> Checkout([FromBody] CheckoutReq req)
        {
            bool isSuccess = _shoppingCartService.Checkout(req);
            return new(isSuccess);
        }
    }
}
