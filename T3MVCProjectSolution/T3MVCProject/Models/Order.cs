using System.ComponentModel.DataAnnotations;

namespace T3MVCProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public int DeliveryId { get; set; }

    }
}
