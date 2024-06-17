namespace AllBuyMyself.Models.Shopping
{
    public class AddShoppingCartReq
    {
        public string Username { get; set; } = string.Empty;
        public int ProductId { get; set; } = 0;
        public int Amount { get; set; } = 0;
    }
}
