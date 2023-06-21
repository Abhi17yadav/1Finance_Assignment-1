using Assignment_1.Models;

namespace Assignment_1.Service.CategoryService
{
    public interface ICategoryService
    {
        int AddCategory(Category category);
        int DeleteCategory(Category category);
        int EditCategory(Category category);
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        //List<Category> GetCategoryDropdown();
    }
}
