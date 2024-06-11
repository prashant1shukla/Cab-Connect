namespace KeyVault.IServices
{
    public interface IPurgeSecretService
    {
        Task PurgeSecretAsync(string secretName);
    }
}
