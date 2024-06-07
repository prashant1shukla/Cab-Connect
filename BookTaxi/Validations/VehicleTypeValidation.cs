using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Validations
{
    public class VehicleTypeValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] validVehicles = new string[] { "Bike", "Car", "Auto" };

            if (value == null || !validVehicles.Contains(value.ToString()))
            {
                return new ValidationResult("Vehicle must be 'Bike' or 'Car' or 'Auto");
            }

            return ValidationResult.Success;
        }
    }
}
