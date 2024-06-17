namespace AllBuyMyself.Models.Shopping.Order
{
    public class GetOrdersResp
    {
        public string Id { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();
        public DateTime Time { get; set; } = DateTime.Now;
        public int TotalPrice { get; set; } = 0;
    }
}
