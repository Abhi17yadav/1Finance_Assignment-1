using Assignment_1.Models;

namespace Assignment_1.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        int AddCategory(Category category);
        int DeleteCategory(Category category);
        int EditCategory(Category category);
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        //List<Category> GetCategoryDropdown();
    }
}
