using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.ViewModels.RequestViewModels
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [UserTypeValidation]
        public string UserType { get; set; }
        
    }
}
