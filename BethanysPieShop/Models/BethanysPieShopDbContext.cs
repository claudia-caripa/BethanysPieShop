using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class BethanysPieShopDbContext : DbContext
    {
        //Add constructor 
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options)
        {
        }

        //Add properties
        public DbSet<Category> Categories { get; set; }

        public DbSet<Pie> Pies { get; set; }
    }
}
