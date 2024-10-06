using ASP_MVC.Models;
using ASP_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASP_MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<Review> reviews = new List<Review>
        {
            new Review { Id = 1, ProductId = 1, Rating = 5, Comment = "Excellent product!", Date = DateTime.Now.AddDays(-1) },
            new Review { Id = 2, ProductId = 1, Rating = 4, Comment = "Very good, but could be improved.", Date = DateTime.Now.AddDays(-2) },
            new Review { Id = 3, ProductId = 1, Rating = 3, Comment = "Average product.", Date = DateTime.Now.AddDays(-3) },
            new Review { Id = 4, ProductId = 1, Rating = 2, Comment = "Not satisfied.", Date = DateTime.Now.AddDays(-4) },
            new Review { Id = 5, ProductId = 2, Rating = 5, Comment = "Excellent product!", Date = DateTime.Now.AddDays(-1) },
            new Review { Id = 6, ProductId = 2, Rating = 4, Comment = "Very good, but could be improved.", Date = DateTime.Now.AddDays(-2) },
            new Review { Id = 7, ProductId = 2, Rating = 3, Comment = "Average product.", Date = DateTime.Now.AddDays(-3) },
            new Review { Id = 8, ProductId = 2, Rating = 2, Comment = "Not satisfied.", Date = DateTime.Now.AddDays(-4) },
            new Review { Id = 9, ProductId = 3, Rating = 5, Comment = "Excellent product!", Date = DateTime.Now.AddDays(-1) },
            new Review { Id = 10, ProductId = 3, Rating = 4, Comment = "Very good, but could be improved.", Date = DateTime.Now.AddDays(-2) },
            new Review { Id = 11, ProductId = 3, Rating = 3, Comment = "Average product.", Date = DateTime.Now.AddDays(-3) },
            new Review { Id = 12, ProductId = 3, Rating = 2, Comment = "Not satisfied.", Date = DateTime.Now.AddDays(-4) },
            new Review { Id = 13, ProductId = 4, Rating = 5, Comment = "Excellent product!", Date = DateTime.Now.AddDays(-1) },
            new Review { Id = 14, ProductId = 4, Rating = 4, Comment = "Very good, but could be improved.", Date = DateTime.Now.AddDays(-2) },
            new Review { Id = 15, ProductId = 4, Rating = 3, Comment = "Average product.", Date = DateTime.Now.AddDays(-3) },
            new Review { Id = 16, ProductId = 4, Rating = 2, Comment = "Not satisfied.", Date = DateTime.Now.AddDays(-4) }
        };

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Iphone 15 Pro", Description = "The best smartphone in the world" },
            new Product { Id = 2, Name = "Asus ROG strix 27", Description = "UHD monitor 27, IPS" },
            new Product { Id = 3, Name = "Logitect MX 3S", Description = "The most innovation mouse for pc" },
            new Product { Id = 4, Name = "Keycrone K4", Description = "Mechanic keyboard" }
        };


        [HttpPost]
        public IActionResult Create(int productId, int rating, string comment)
        {
            var review = new Review
            {
                Id = reviews.Count + 1,
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                Date = DateTime.Now
            };

            reviews.Add(review);
            return RedirectToAction("ProductDetails", new { productId });
        }

        public IActionResult Products()
        {
            return View(products);
        }

        public IActionResult ProductDetails(int productId)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var productReviews = reviews.Where(r => r.ProductId == productId).ToList();
            var averageRating = productReviews.Any() ? productReviews.Average(r => r.Rating) : 0;

     
            return View(new DetailViewModel() { Product = product, Reviews = productReviews, AverageRating = averageRating});
        }
    }
}
