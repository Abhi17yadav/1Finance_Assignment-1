using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models.DTO
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter email in correct format")]
        [MaxLength(30, ErrorMessage = "Length should not be greater then 30")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [MaxLength(8, ErrorMessage = "Length should not be greater then 8")]
        public string Password { get; set; }
    }
}
