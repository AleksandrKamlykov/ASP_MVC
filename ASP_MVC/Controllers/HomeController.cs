using ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int size)
        {
            var model = new MatrixModel
            {
                Size = size,
                Matrix1 = new int[size, size],
                Matrix2 = new int[size, size]
            };
            return View("MatrixInput", model);
        }

        [HttpPost]
        public IActionResult Calculate(int size, int[][] matrix1, int[][] matrix2, string operation)
        {
            var model = new MatrixModel
            {
                Size = size,
                Matrix1 = new int[size, size],
                Matrix2 = new int[size, size],
                Result = new int[size, size]
            };

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    model.Matrix1[i, j] = matrix1[i][j];
                    model.Matrix2[i, j] = matrix2[i][j];
                }
            }

            if (operation == "Add")
            {
                for (int i = 0; i < model.Size; i++)
                {
                    for (int j = 0; j < model.Size; j++)
                    {
                        model.Result[i, j] = model.Matrix1[i, j] + model.Matrix2[i, j];
                    }
                }
            }
            else if (operation == "Multiply")
            {
                for (int i = 0; i < model.Size; i++)
                {
                    for (int j = 0; j < model.Size; j++)
                    {
                        model.Result[i, j] = 0;
                        for (int k = 0; k < model.Size; k++)
                        {
                            model.Result[i, j] += model.Matrix1[i, k] * model.Matrix2[k, j];
                        }
                    }
                }
            }

            return View("Result", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
