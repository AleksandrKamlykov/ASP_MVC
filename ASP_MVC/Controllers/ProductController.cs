using ASP_MVC.Models;
using ASP_MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Repository;

namespace ASP_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productService)
        {
            _productsRepository = productService;
        }

        [HttpGet]
        public JsonResult Index()
        {
            var products = _productsRepository.GetAllProducts();
            return Json(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productsRepository.CreateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Search(string keyword)
        {
            var products = _productsRepository.GetProductByName(keyword);
            return Json(products);
        }

        [HttpGet]
        public JsonResult Details(int id)
        {
            var product = _productsRepository.GetProductById(id);
            return Json(product);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var product = _productsRepository.DeleteProduct(id);
            return Json(product);
        }

    }
}
