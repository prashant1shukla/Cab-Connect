namespace BookTaxi.CustomExceptions
{
    public class RideNotStartedException: Exception
    {
        public RideNotStartedException() : base("Cannot end a ride that has not started.") { }

        public RideNotStartedException(string message) : base(message) { }
    }
}
