using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T3MVCProject.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int Qty { get; set; }

        public Product Product { get; set; }
        //not sure want to store amt, as it would be calculated anyway
        public double Amount { get; set; }  //per item

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
