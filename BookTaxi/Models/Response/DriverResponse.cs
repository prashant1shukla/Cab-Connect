using BookTaxi.Enums;
using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.ViewModels.ResponseViewModels
{
    public class DriverResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleRTONumber { get; set; }
        public string UserRole { get; set; }
    }
}
