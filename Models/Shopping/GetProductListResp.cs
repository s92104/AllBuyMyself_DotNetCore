using AllBuyMyself.Models.Common.Table;

namespace AllBuyMyself.Models.Shopping
{
    public class GetProductListResp
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public string? Image_path { get; set; } = string.Empty;
        public bool IsSave { get; set; } = false;

        public GetProductListResp(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Image_path = product.Image_path;
        }
    }
}
