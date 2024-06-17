using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Shopping.Order;
using AllBuyMyself.Services.Shopping;
using Microsoft.AspNetCore.Mvc;

namespace AllBuyMyself.Controllers.Shopping
{
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ApiResult<IEnumerable<GetOrdersResp>> GetOrders(string username)
        {
            IEnumerable<GetOrdersResp> resp = _orderService.GetOrders(username);
            return new(resp);
        }

        [HttpDelete]
        public ApiResult<bool> DeleteOrder(string username, string id)
        {
            bool isSuccess = _orderService.DeleteOrder(username, id);
            return new(isSuccess);
        }
    }
}
