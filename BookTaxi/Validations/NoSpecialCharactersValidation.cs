using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Validations
{
    public class NoSpecialCharactersValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; 
            }

            string? name = value.ToString();
            if (name == null)
            {
                return new ValidationResult("Name cannot contain special characters");
            }

            // Check if name contains any special characters
            if (name.Any(char.IsPunctuation) || name.Any(char.IsSymbol))
            {
                return new ValidationResult("Name cannot contain special characters");
            }

            return ValidationResult.Success;
        }
    }
}
