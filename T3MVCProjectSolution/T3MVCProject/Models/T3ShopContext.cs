using Microsoft.EntityFrameworkCore;

namespace T3MVCProject.Models
{
    public class T3ShopContext : DbContext
    {
        public T3ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
