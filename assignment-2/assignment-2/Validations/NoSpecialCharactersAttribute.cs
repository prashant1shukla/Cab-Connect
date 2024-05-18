using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class NoSpecialCharactersAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var stringValue = value as string;
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return ValidationResult.Success;
        }

        var hasSpecialCharacters = new Regex(@"[^a-zA-Z0-9]+");
        if (hasSpecialCharacters.IsMatch(stringValue))
        {
            return new ValidationResult("The field cannot contain special characters.");
        }

        return ValidationResult.Success;
    }
}
