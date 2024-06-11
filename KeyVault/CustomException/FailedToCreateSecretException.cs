namespace KeyVault.CustomException
{
    public class FailedToCreateSecretException: Exception
    {
        public FailedToCreateSecretException() : base("Failed to create secret") {}
        public FailedToCreateSecretException(string message) : base(message) { }
    }
}
