using KeyVault.Models.Request;

namespace KeyVault.IServices
{
    public interface ICreateSecretService
    {
        Task CreateSecretAsync(SecretsRequest secretsRequest);
    }
}
