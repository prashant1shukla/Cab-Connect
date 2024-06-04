using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.ViewModels.RequestViewModels
{
    public class RiderRequestViewModel
    {
        [Required]
        [NoSpecialCharactersValidation]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [EmailUniquenessValidation]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [PasswordComplexityValidation]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
