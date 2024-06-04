using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Validations
{
    //Validation for finding the email address is unique or not
    public class EmailUniquenessValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;
            //if (UserDataStore.Users.Any(u => u.Email == email))
            //{
            //    return new ValidationResult("Email already exists");
            //}

            return ValidationResult.Success;
        }
    }
}
