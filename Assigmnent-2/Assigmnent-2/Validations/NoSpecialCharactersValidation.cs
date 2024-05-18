using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assigmnent_2.Validations
{
    public class NoSpecialCharactersValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value as string;

            // Check if password contains any special characters
            if (password.Any(char.IsPunctuation) || password.Any(char.IsSymbol))
            {
                return new ValidationResult("Password cannot contain special characters");
            }

            return ValidationResult.Success;
        }
    }
}
