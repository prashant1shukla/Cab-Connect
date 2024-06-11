namespace KeyVault.IServices
{
    public interface IGetSecretService
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
