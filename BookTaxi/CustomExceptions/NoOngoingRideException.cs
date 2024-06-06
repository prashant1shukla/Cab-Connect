namespace BookTaxi.CustomExceptions
{
    public class NoOngoingRideException: Exception
    {
        public NoOngoingRideException() : base("No ongoing ride available.") { }

        public NoOngoingRideException(string message) : base(message) { }
    }
}
