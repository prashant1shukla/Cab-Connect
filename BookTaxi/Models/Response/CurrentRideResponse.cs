using BookTaxi.Enums;
using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Models.Response
{
    public class CurrentRideResponse
    {
        public string DriverName { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleRTONumber { get; set; }
        public string OTP {  get; set; }
        public string rideStatus { get; set; }
    }
}
