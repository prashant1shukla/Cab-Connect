namespace BookTaxi.Models.Response
{
    public class DriverCurrentRideResponse
    {
        public string RiderName { get; set; }
        public string RiderPhoneNumber { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public string RideStatus { get; set; }
    }
}
