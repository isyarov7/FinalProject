using System.ComponentModel.DataAnnotations;

namespace YVN.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MinLength(2), MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
