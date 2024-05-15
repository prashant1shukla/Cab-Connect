using System.ComponentModel.DataAnnotations;

namespace homework_7.Validators
{
    public class CVVAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string cvv))
                return ValidationResult.Success;

            if (cvv.Length < 3 || cvv.Length > 4 || !int.TryParse(cvv, out _))
            {
                return new ValidationResult("CVV must be a 3 or 4-digit number.");
            }

            return ValidationResult.Success;
        }
    }

}
