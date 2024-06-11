using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVault.CustomException;
using KeyVault.IServices;
using KeyVault.Models.Request;

namespace KeyVault.Services
{
    public class CreateSecretService : ICreateSecretService
    {
        private readonly SecretClient _client;

        public CreateSecretService()
        {
            var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            _client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public async Task CreateSecretAsync(SecretsRequest secretsRequest)
        {
            try
            {
                await _client.SetSecretAsync(secretsRequest.SecretName, secretsRequest.SecretValue);
            }
            catch (Exception ex)
            {
                throw new FailedToCreateSecretException($"Failed to create secret: {ex.Message}");
            }
        }
    }
}
