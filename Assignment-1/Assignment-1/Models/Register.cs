using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Register
    {
        [Key]
        public int RegId { get; set; }


        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50, ErrorMessage = "Length should not be greater then 50")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter email in correct format")]
        [MaxLength(30, ErrorMessage = "Length should not be greater then 30")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter contact")]
        [MaxLength(10, ErrorMessage = "Length should not be greater then 10")]
        public string Contact { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [MaxLength(8, ErrorMessage = "Length should not be greater then 8")]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
