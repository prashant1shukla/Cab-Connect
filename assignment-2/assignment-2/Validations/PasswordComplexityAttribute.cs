using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class PasswordComplexityAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (string.IsNullOrWhiteSpace(password))
        {
            return new ValidationResult("Password is required.");
        }

        // Add your password complexity rules here
        var hasDigit = new Regex(@"[0-9]+");
        var hasLowercase = new Regex(@"[a-z]+");
        var hasUppercase = new Regex(@"[A-Z]+");
        var hasNonAlphanumeric = new Regex(@"\W+");

        if (!hasDigit.IsMatch(password) || !hasLowercase.IsMatch(password) || !hasUppercase.IsMatch(password) || !hasNonAlphanumeric.IsMatch(password))
        {
            return new ValidationResult("Password must contain at least one digit, one lowercase letter, one uppercase letter, and one non-alphanumeric character.");
        }

        return ValidationResult.Success;
    }
}
