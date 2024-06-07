using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Validations
{
    public class PasswordComplexityValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
            }

            string password = value.ToString();
            if (password == null)
            {
                return new ValidationResult("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
            }

            // Check if password contains at least one uppercase letter, one lowercase letter, and one digit
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                return new ValidationResult("Password must contain at least one uppercase letter, one lowercase letter, and one digit");
            }

            return ValidationResult.Success;
        }
    }
}
