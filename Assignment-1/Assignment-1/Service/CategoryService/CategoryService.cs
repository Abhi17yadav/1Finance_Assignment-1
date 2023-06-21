using Assignment_1.Models;
using Assignment_1.Repository.CategoryRepository;

namespace Assignment_1.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public int AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public int DeleteCategory(Category category)
        {
            return _categoryRepository.DeleteCategory(category);
        }

        public int EditCategory(Category category)
        {
            return _categoryRepository.EditCategory(category);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
    }
}
