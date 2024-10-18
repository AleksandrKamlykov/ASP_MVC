using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
