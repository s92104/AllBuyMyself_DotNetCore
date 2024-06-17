using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AllBuyMyself.Models.Common.Table
{
    [Table("ShoppingCart")]
    [PrimaryKey(nameof(Username), nameof(ProductId))]
    public class ShoppingCart
    {
        public string Username { get; set; } = string.Empty;

        public int ProductId { get; set; } = 0;

        [Required]
        public int Amount { get; set; } = 0;
    }
}
