using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly TMDbService _tmdbService;

        public MovieController(TMDbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = await _tmdbService.GetPopularMoviesAsync(page);
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _tmdbService.GetMovieDetailsAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public async Task<IActionResult> Search(string query, int page = 1)
        {
            var movies = await _tmdbService.SearchMoviesAsync(query, page);
            return View("Index", movies);
        }
    }
}
