namespace AllBuyMyself.Models.Shopping.Order
{
    public class OrderItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Image_path { get; set; } = null;
        public int Price { get; set; } = 0;
        public int Amount { get; set; } = 0;
    }
}
