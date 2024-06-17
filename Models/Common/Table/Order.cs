using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AllBuyMyself.Models.Common.Table
{
    [Table("Order")]
    [PrimaryKey(nameof(Username), nameof(Id), nameof(ProductId))]
    public class Order
    {
        public string Username { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public int ProductId { get; set; } = 0;

        [Required]
        public int Amount { get; set; } = 0;

        [Required]
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
