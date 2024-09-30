using ASP_MVC.Models;
using ASP_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class FeedbackController : Controller
    {
        List<string> subjects = new List<string> { "General", "Complaint", "Suggestion", "Other" };
        public IActionResult Index(Feedback? feedback)
        {

            FeedbackViewModel feedbackViewModel = new FeedbackViewModel
            {
                Feedback = feedback,
                Subjects = subjects
            };

            return View(feedbackViewModel);
        }

        public IActionResult SendMail(Feedback feedback)
        {
            FeedbackViewModel feedbackViewModel = new FeedbackViewModel
            {
                Feedback = feedback,
                Subjects = null
            };

            if (ModelState.IsValid)
            {
                feedbackViewModel.Subjects = subjects;
                // Save feedback to database
                return RedirectToAction("Index",feedback);
            }
            return RedirectToAction("Index");
        }
    }

}
