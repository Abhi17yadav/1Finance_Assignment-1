using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required(ErrorMessage ="Please enter product name")]

        public string Product_Name { get; set; }
        [Required(ErrorMessage = "Please enter product name")]

        public int Product_Quantity { get; set; }
        [Required(ErrorMessage = "Please enter product quantity")]

        public decimal Product_Price { get; set; }
        [Required(ErrorMessage = "Please enter product price")]

        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
}
