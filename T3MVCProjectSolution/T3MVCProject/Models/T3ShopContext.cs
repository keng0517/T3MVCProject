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

        public DbSet<OrderItem> OrderItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>().HasData(
        //        new Order()
        //        {
        //            OrderId = 101,
        //            UserId = 101,
        //            OrderDate = DateTime.Now,
        //            TotalAmount = 25,
        //            Status = "Delivered",
        //            DeliveryId = 21
        //        },
        //        new Order()
        //        {
        //            OrderId = 102,
        //            UserId = 101,
        //            OrderDate = DateTime.Now,
        //            TotalAmount = 30,
        //            Status = "Delivered",
        //            DeliveryId = 21
        //        });

        //    modelBuilder.Entity<OrderItem>().HasData(
        //        new OrderItem()
        //        {
        //            OrderItemId = 101,
        //            OrderId = 101,
        //            ProductId = 101,
        //            Quantity = 5,
        //            Price = 1
        //        },
        //        new OrderItem()
        //        {
        //            OrderItemId = 102,
        //            OrderId = 101,
        //            ProductId = 102,
        //            Quantity = 1,
        //            Price = 20
        //        });
        //}

    }
}
