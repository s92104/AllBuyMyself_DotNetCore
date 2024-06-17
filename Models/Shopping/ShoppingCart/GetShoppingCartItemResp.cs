namespace AllBuyMyself.Models.Shopping.ShoppingCart
{
    public class GetShoppingCartItemResp
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string? Image_path { get; set; } = null;
        public int Price { get; set; } = 0;
        public int Amount { get; set; } = 0;
    }
}
