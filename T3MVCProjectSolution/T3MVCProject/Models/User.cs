using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T3MVCProject.Models
{
    public class User
    {
        //[Key]
        //[Display (Name = "User ID")]
        //public int UserId { get; set; }

        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }


        //two inherited model Admin and Shopper

        [ForeignKey("ShopperId")]
        public int ShopperId { get; set; }
        public Shopper Shopper { get; set; }



        //[ForeignKey("AdminId")]
        //public int AdminId { get; set; }
        //public Admin Admin { get; set; }

    }
}
