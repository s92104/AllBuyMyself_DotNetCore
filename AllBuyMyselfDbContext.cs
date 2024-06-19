using AllBuyMyself.Models.Common.Table;
using Microsoft.EntityFrameworkCore;

namespace AllBuyMyself
{
    public class AllBuyMyselfDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Save> Saves { get; set; }

        public AllBuyMyselfDbContext(DbContextOptions<AllBuyMyselfDbContext> options) : base(options) { }
    }
}
