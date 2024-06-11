using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVault.CustomException;
using KeyVault.IServices;

namespace KeyVault.Services
{
    public class PurgeSecretService : IPurgeSecretService
    {
        private readonly SecretClient _client;

        public PurgeSecretService()
        {
            var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            _client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public async Task PurgeSecretAsync(string secretName)
        {
            try
            {
                await _client.PurgeDeletedSecretAsync(secretName);
            }
            catch (Exception ex)
            {
                throw new InvalidSecretException($"Failed to purge secret: {ex.Message}");
            }
        }
    }
}
