namespace BookTaxi.CustomExceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Invalid password or username.") { }

        public InvalidPasswordException(string message) : base(message) { }
    }
}
