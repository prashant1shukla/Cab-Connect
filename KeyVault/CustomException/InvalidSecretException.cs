namespace KeyVault.CustomException
{
    public class InvalidSecretException:  Exception
    {
        public InvalidSecretException() : base("The secret is invlaid") { }
        public InvalidSecretException(string message) : base(message) { }
    }
}
