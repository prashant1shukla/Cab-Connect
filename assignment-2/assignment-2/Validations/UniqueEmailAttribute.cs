using System.ComponentModel.DataAnnotations;
using System.Linq;
using assignment_2.DTO;
using assignment_2.Services;

namespace assignment_2.DTO
{
    public class UniqueEmailValidationAttribute : ValidationAttribute
    {
        private readonly IUserService _userService;

        public UniqueEmailValidationAttribute()
        {
            // If you prefer to use constructor injection, 
            // make sure to provide IUserService instance externally when using this attribute.
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userService = (IUserService)validationContext
                .GetService(typeof(IUserService)); // Get IUserService instance from validation context

            var email = value as string;
            if (string.IsNullOrWhiteSpace(email))
            {
                return ValidationResult.Success;
            }

            var users = userService.GetUsers();
            if (users == null || !users.Any(u => u.Email == email))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Email is already in use.");
        }
    }
}
