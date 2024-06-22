namespace BookTaxi.CustomExceptions
{
    public class RideNotFoundException: Exception
    {
        public RideNotFoundException() : base("Ride Not Found") { }

        public RideNotFoundException(string message) : base(message) { }
    }
}
