using Assignment_1.Models;
using Assignment_1.Repository.CategoryRepository;
using Assignment_1.Service.CategoryService;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Assignment_1.Controllers
{
   
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
      
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
           List<Category>CategoryList= _categoryService.GetAllCategory();
            return View(CategoryList);
        }
        public IActionResult GetCategoryById(int id)
        {
            var details= _categoryService.GetCategoryById(id);
            return View(details);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {

            int id = _categoryService.AddCategory(category);
            if (id == 1)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var details = _categoryService.GetCategoryById(id);
            return View(details);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
          
                int id = _categoryService.EditCategory(category);
                if (id == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var details = _categoryService.GetCategoryById(id);
            return View(details);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
           var Details= _categoryService.DeleteCategory(category);
            if (Details == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
            
        }
        public IActionResult ExportExcel()
        {
            List<Category> CategoryList = _categoryService.GetAllCategory();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Category");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Category Id";
                worksheet.Cell(currentRow, 2).Value = "Category Name";
                worksheet.Cell(currentRow, 3).Value = "Category Description";
                foreach (var item in CategoryList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Category_Id;
                    worksheet.Cell(currentRow, 2).Value = item.Category_Name;
                    worksheet.Cell(currentRow, 3).Value = item.Category_Description;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Category.xlsx");
                }
            }
        }

        public IActionResult ExportToCsv()
        {
            List<Category> CategoryList = _categoryService.GetAllCategory();
            var builder = new StringBuilder();
            builder.AppendLine("Category Id,Category Name,Category Description");
            foreach (var item in CategoryList)
            {
                builder.AppendLine($"{item.Category_Id},{item.Category_Name},{item.Category_Description}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Category.csv");
        }
    }

}
