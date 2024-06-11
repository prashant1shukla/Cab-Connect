namespace KeyVault.IServices
{
    public interface IDeleteSecretService
    {
        Task DeleteSecretAsync(string secretName);
    }
}
