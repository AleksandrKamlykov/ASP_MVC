using ASP_MVC.Models;

namespace ASP_MVC.ViewModel
{
    public class FeedbackViewModel
    {
        public Feedback? Feedback { get; set; }
        public List<string> Subjects { get; set; }
    }
}
