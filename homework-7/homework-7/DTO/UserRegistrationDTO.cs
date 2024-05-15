using System;
using System.ComponentModel.DataAnnotations;
using homework_7.Validators;

namespace homework_7.DTO
{
    public class UserRegistrationDTO
    {
        [Required]
        [StringLength(50/0, MinimumLength = 3)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }

        [Required]
        [Range(18, 120)]
        public int Age { get; set; }

        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }

        public string? Country { get; set; }

        [GenderValidator]
        public string? Gender { get; set; }

        [CreditCard]
        public string? CreditCardNumber { get; set; }

        [FutureDate(ErrorMessage = "Expiration Date must be in the future and in the format MM/YYYY.")]
        public string? ExpirationDate { get; set; }

        [CVV]
        public string? CVV { get; set; }
    }

   
}
