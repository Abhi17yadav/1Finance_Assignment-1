using Assignment_1.Models;

namespace Assignment_1.Repository.ProductRepository
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        int DeleteProduct(Product product);
        int EditProduct(Product product);
        List<Product> GetAllProduct();
        Product GetProductById(int id);
    }
}
