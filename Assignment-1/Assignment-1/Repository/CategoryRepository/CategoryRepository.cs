using Assignment_1.Context;
using Assignment_1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment_1.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            _context.categories.Add(category);
            return _context.SaveChanges();
        }

        public int DeleteCategory(Category category)
        {
            _context.categories.Remove(category);
            return _context.SaveChanges();
        }

        public int EditCategory(Category category)
        {
            _context.Update(category);
            return _context.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return _context.categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.categories.Where(x => x.Category_Id == id).SingleOrDefault();
        }

        //public IEnumerable<Category> GetCategoryDropdown()
        //{
        //    return _context.categories.Select(row => new { row.Category_Id, row.Category_Name })..ToList();
        //}
    }
}
