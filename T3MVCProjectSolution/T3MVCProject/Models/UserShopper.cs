using System.ComponentModel.DataAnnotations;

namespace T3MVCProject.Models
{
    public class UserShopper
    {

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Re-Type Password")]
        [Compare("Password", ErrorMessage = "Re-type Password and Password are different.")]
        public string RetypePassword { get; set; }

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
    }
}
