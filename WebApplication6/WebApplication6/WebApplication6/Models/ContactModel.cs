using System.ComponentModel.DataAnnotations;

namespace FoodWebsite.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}
