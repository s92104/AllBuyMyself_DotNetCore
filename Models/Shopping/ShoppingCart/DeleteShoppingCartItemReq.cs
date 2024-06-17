namespace AllBuyMyself.Models.Shopping.ShoppingCart
{
    public class DeleteShoppingCartItemReq
    {
        public string Username { get; set; } = string.Empty;
        public int ProductId { get; set; } = 0;
    }
}
