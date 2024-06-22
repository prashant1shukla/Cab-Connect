namespace BookTaxi.CustomExceptions
{
    public class RideNotCompletedException: Exception
    {
        public RideNotCompletedException() : base("Ride is not completed yet, so you can not rate") { }
        public RideNotCompletedException(string message) : base(message) { }
    }
}
