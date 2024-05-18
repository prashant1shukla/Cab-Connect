using System.ComponentModel.DataAnnotations;
using Assigmnent_2.Data;
using System.Linq;

namespace Assigmnent_2.Validations
{
    public class EmailUniquenessValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            if (UserDataStore.Users.Any(u => u.Email == email))
            {
                return new ValidationResult("Email already exists");
            }

            return ValidationResult.Success;
        }
    }
}
