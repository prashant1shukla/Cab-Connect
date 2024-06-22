using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.ViewModels.RequestViewModels
{
    public class RequestRideRequest
    {
        [Required]
        public string PickupLocation { get; set; }
        [Required]
        public string DropLocation { get; set; }
        [Required]
        [VehicleTypeValidation]
        public string TypeOfRide { get; set; }

    }
}
