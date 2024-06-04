using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllBuyMyself.Models.Common.Table
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; } = 0;

        public string? Image_path { get; set; } = null;

        public string? Description { get; set; } = string.Empty;
    }
}
