using BookTaxi.Enums;
using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.ViewModels.RequestViewModels
{
    public class DriverRequest
    {
        [Required]
        [NoSpecialCharactersValidation]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [PasswordComplexityValidation]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [VehicleTypeValidation]
        public string VehicleType {  get; set; }

        [Required]
        public string VehicleRTONumber { get; set; }
    }
}
