using Assigmnent_2.Validations;
using System.ComponentModel.DataAnnotations;

namespace Assigmnent_2.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [EmailUniquenessValidation]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [PasswordComplexityValidation]
        public string Password { get; set; }

        [Required]
        [NoSpecialCharactersValidation]

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
