using ASP_MVC.Models;
using ASP_MVC.Interfaces;

namespace ASP_MVC.Repository
{


    public class ProductsRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100, Description = "Description 1" },
            new Product { Id = 2, Name = "Product 2", Price = 200, Description = "Description 2" },
            new Product { Id = 3, Name = "Product 3", Price = 300, Description = "Description 3" },
            new Product { Id = 4, Name = "Product 4", Price = 400, Description = "Description 4" },
            new Product { Id = 5, Name = "Product 5", Price = 500, Description = "Description 5" }
        };


        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public Product CreateProduct(Product product)
        {
            _products.Add(product);
            return product;
        }
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }
        public Product DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            _products.Remove(product);
            return product;
        }
    }

}
