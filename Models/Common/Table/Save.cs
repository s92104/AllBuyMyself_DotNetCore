using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AllBuyMyself.Models.Common.Table
{
    [Table("Saves")]
    [PrimaryKey(nameof(Username), nameof(ProductId))]
    public class Save
    {
        public string Username { get; set; } = string.Empty;
        public int ProductId { get; set; } = 0;
    }
}
