using System.ComponentModel.DataAnnotations;

namespace homework_7.Validators
{
    public class GenderValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] validGenders = new string[] { "Male", "Female", "Other" };

            if (value == null || !validGenders.Contains(value.ToString()))
            {
                return new ValidationResult("Gender must be 'Male', 'Female', or 'Other'.");
            }

            return ValidationResult.Success;
        }
    }
}
