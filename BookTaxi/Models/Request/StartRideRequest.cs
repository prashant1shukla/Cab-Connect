namespace BookTaxi.Models.Request
{
    public class StartRideRequest
    {
        public Guid RideId { get; set; }
        public string OTP { get; set; }
    }
}
