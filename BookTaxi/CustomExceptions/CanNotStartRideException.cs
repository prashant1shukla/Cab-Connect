namespace BookTaxi.CustomExceptions
{
    public class CanNotStartRideException: Exception
    {
        public CanNotStartRideException() : base("Start ride failed due to invalid credentials or wrong rider") { }
        public CanNotStartRideException(string message) : base(message) { }
    }
}
