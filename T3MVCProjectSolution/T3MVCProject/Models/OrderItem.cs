using System.ComponentModel.DataAnnotations;

namespace T3MVCProject.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
