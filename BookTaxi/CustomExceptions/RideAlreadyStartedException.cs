namespace BookTaxi.CustomExceptions
{
    public class RideAlreadyStartedException: Exception
    {
        public RideAlreadyStartedException() : base("Cannot cancel a ride that has already started.") { }

        public RideAlreadyStartedException(string message) : base(message) { }
    }
}
