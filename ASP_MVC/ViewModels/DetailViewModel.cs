using ASP_MVC.Models;

namespace ASP_MVC.ViewModels
{
    public class DetailViewModel
    {
        public Product Product { get; set; }
        public List<Review> Reviews { get; set; }
        public double AverageRating { get; set; }
    }
}
