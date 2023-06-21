using Assignment_1.Models;
using Assignment_1.Service.CategoryService;
using Assignment_1.Service.ProductService;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Assignment_1.Controllers
{
   
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Product> ProductList = _productService.GetAllProduct();
            return View(ProductList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAllCategory(), "Category_Id", "Category_Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            
                int id = _productService.AddProduct(product);
                if (id == 1)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                } 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var details = _productService.GetProductById(id);
            ViewBag.Categories = new SelectList(_categoryService.GetAllCategory(), "Category_Id", "Category_Name");
            return View(details);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
           
                int id = _productService.EditProduct(product);
                if (id == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
        }

        public IActionResult Delete(int id)
        {
            var details= _productService.GetProductById(id);
            return View(details);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            int id=_productService.DeleteProduct(product);
            if (id == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Details(int id)
        {
            var details = _productService.GetProductById(id);
            return View(details);
        }

       public IActionResult ExportExcel()
        {
            List<Product> ProductList = _productService.GetAllProduct();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Product");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Product Id";
                worksheet.Cell(currentRow, 2).Value = "Product Name";
                worksheet.Cell(currentRow, 3).Value = "Product Quantity";
                worksheet.Cell(currentRow, 4).Value = "Product Price";
                worksheet.Cell(currentRow, 5).Value = "Category Name";
                foreach(var item in ProductList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Product_Id;
                    worksheet.Cell(currentRow, 2).Value = item.Product_Name;
                    worksheet.Cell(currentRow, 3).Value = item.Product_Quantity;
                    worksheet.Cell(currentRow, 4).Value = item.Product_Price;
                    worksheet.Cell(currentRow, 5).Value = item.Category.Category_Name;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Product.xlsx");
                }
            }
        }

       public IActionResult ExportToCsv()
        {
            List<Product> ProductList = _productService.GetAllProduct();
            var builder = new StringBuilder();
            builder.AppendLine("Product Id,Product Name,Product Quantity,Product Price,Category Name");
            foreach(var item in ProductList)
            {
                builder.AppendLine($"{item.Product_Id},{item.Product_Name},{item.Product_Quantity},{item.Product_Price},{item.Category.Category_Name}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()),"text/csv","Product.csv");
        }
    }
}
