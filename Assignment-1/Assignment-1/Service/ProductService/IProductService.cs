using Assignment_1.Models;

namespace Assignment_1.Service.ProductService
{
    public interface IProductService
    {
        int AddProduct(Product product);
        int DeleteProduct(Product product);
        int EditProduct(Product product);
        List<Product> GetAllProduct();
        Product GetProductById(int id);
    }
}
