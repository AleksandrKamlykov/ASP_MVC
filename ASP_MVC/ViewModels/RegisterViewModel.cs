using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ASP_MVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^\w+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        [Remote(action: "IsUsernameAvailable", controller: "Account")]
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
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Url]
        public string Website { get; set; }

        [ValidateNever]
        public bool TermsOfService { get; set; }
    }
}
