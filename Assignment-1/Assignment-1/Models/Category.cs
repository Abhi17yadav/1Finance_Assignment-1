using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required]
        public string Category_Name { get; set; }
        [Required]
        public string Category_Description { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
