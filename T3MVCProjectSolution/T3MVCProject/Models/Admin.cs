using System.ComponentModel.DataAnnotations;

namespace T3MVCProject.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string NRIC { get; set; }
    }
}
