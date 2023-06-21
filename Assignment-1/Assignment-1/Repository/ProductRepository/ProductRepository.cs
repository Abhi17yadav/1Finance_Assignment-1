using Assignment_1.Context;
using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text;

namespace Assignment_1.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.products.Add(product);
            return _context.SaveChanges();
        }

        public int DeleteProduct(Product product)
        {
            _context.products.Remove(product);
            return _context.SaveChanges();
        }

        public int EditProduct(Product product)
        {
            _context.products.Update(product);
            return _context.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
            return _context.products.Include(p=>p.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.products.Include(x => x.Category).SingleOrDefault(p => p.Product_Id == id);
        }
    }
}

