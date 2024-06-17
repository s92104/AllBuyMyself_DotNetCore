using AllBuyMyself.Models.Common;
using AllBuyMyself.Models.Common.Table;
using AllBuyMyself.Models.Shopping.Order;

namespace AllBuyMyself.Services.Shopping
{
    public class OrderService
    {
        private readonly AllBuyMyselfDbContext _context;
        public OrderService(AllBuyMyselfDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetOrdersResp> GetOrders(string username)
        {
            List<GetOrdersResp> orderItems = _context.Orders
                .Where(x => x.Username == username)
                .Join(_context.Products, order => order.ProductId, product => product.Id, (order, product) => new
                {
                    Id = order.Id,
                    ProductName = product.Name,
                    Image_path = product.Image_path,
                    Price = product.Price,
                    Amount = order.Amount,
                    Time = order.Time
                })
                .GroupBy(x => x.Id, (id, orders) => new GetOrdersResp
                {
                    Id = id,
                    Items = orders.Select(order => new OrderItem
                    {
                        Name = order.ProductName,
                        Image_path = order.Image_path,
                        Price = order.Price,
                        Amount = order.Amount,
                    }).ToList(),
                    Time = orders.First().Time,
                    TotalPrice = orders.Sum(x => x.Price * x.Amount)
                })
                .OrderByDescending(x => x.Time)
                .ToList();

            return orderItems;
        }

        public bool DeleteOrder(string username, string id)
        {
            IEnumerable<Order> orders = _context.Orders
                .Where(x => x.Username == username && x.Id == id);

            _context.RemoveRange(orders);
            _context.SaveChanges();

            return true;
        }
    }
}
