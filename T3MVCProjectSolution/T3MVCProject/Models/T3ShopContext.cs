using Microsoft.EntityFrameworkCore;

namespace T3MVCProject.Models
{
    public class T3ShopContext : DbContext
    {
        public T3ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

    }
}
