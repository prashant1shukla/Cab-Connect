using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Validations
{
    public class UserTypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] validUsers = new string[] { "Rider", "Driver" };

            if (value == null || !validUsers.Contains(value.ToString()))
            {
                return new ValidationResult("user must be 'Rider' or 'Driver'");
            }

            return ValidationResult.Success;
        }
    }
}
