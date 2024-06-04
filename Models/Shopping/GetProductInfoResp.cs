﻿using AllBuyMyself.Models.Common.Table;

namespace AllBuyMyself.Models.Shopping
{
    public class GetProductInfoResp
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public string? Image_path { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public GetProductInfoResp() { }
        public GetProductInfoResp(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Image_path = product.Image_path;
            Description = product.Description;
        }
    }
}