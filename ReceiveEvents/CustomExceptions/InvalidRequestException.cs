namespace ReceiveEvents.CustomExceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string? message) : base(message)
        {
        }
    }
}
