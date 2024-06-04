namespace BookTaxi.CustomExceptions
{
    public class UserAlreadyExistException: Exception
    {
        public UserAlreadyExistException() : base("User Already Exist") { }

        public UserAlreadyExistException(string message) : base(message) { }
    }
}
