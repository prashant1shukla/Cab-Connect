namespace BookTaxi.ViewModels.ResponseViewModels
{
    public class RequestRideResponse
    {
        public Guid RideId { get; set; }
        public string DriverName { get; set; }
        public string DriverNumberPlate { get; set; }
        public string DriverVehicleType { get; set; }
        public string OTP { get; set; }
        public string RideStatus { get; set; }

    }
}
