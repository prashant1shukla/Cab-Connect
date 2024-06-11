using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVault.CustomException;
using KeyVault.IServices;

namespace KeyVault.Services
{
    public class DeleteSecretService : IDeleteSecretService
    {
        private readonly SecretClient _client;

        public DeleteSecretService()
        {
            var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            _client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public async Task DeleteSecretAsync(string secretName)
        {
            try
            {
                await _client.StartDeleteSecretAsync(secretName);
            }
            catch (Exception ex)
            {
                throw new InvalidSecretException($"Failed to delete secret: {ex.Message}");
            }
        }
    }
}
