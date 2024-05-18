using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assigmnent_2.Validations
{
    public class PasswordComplexityValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value as string;

            // Check if password contains at least one uppercase letter, one lowercase letter, and one digit
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                return new ValidationResult("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
            }

            return ValidationResult.Success;
        }
    }
}
