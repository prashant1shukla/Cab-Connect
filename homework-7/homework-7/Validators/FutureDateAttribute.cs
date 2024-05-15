using System.ComponentModel.DataAnnotations;

namespace homework_7.Validators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string date))
                return ValidationResult.Success;

            if (!DateTime.TryParseExact(date, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return new ValidationResult("Expiration Date must be in the format MM/YYYY.");
            }

            if (parsedDate <= DateTime.Now)
            {
                return new ValidationResult("Expiration Date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
