using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Url]
        public string Website { get; set; }
    }
}
