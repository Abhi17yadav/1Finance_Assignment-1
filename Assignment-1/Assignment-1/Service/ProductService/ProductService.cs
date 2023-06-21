using Assignment_1.Models;
using Assignment_1.Repository.ProductRepository;

namespace Assignment_1.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }

        public int EditProduct(Product product)
        {
            return _productRepository.EditProduct(product);
        }

        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
