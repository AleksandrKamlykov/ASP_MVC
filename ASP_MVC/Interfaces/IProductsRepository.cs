using ASP_MVC.Models;

namespace ASP_MVC.Interfaces
{
    public interface IProductsRepository
    {
        Product CreateProduct(Product product);
        Product DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
    }
}
