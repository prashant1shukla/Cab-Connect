namespace BookTaxi.CustomExceptions
{
    public class DriverInRideExcpetion: Exception
    {
        public DriverInRideExcpetion() : base("The driver in currently in a ride, so availablity cant not be toggled.") { }

        public DriverInRideExcpetion(string message) : base(message) { }
    }
}
