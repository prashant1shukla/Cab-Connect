namespace BookTaxi.CustomExceptions
{
    public class NoDriverFoundException: Exception
    {
        public NoDriverFoundException() : base("No available driver found") { }
        public NoDriverFoundException(string message) : base(message) { }
    }
}
