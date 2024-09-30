using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models
{
    public class User
    {
        public  Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Range(0, 100000)]
        public decimal Salary { get; set; }
    }
}
