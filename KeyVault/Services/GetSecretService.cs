using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVault.CustomException;
using KeyVault.IServices;

namespace KeyVault.Services
{
    public class GetSecretService : IGetSecretService
    {
        private readonly SecretClient _client;

        public GetSecretService()
        {
            var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            _client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            try
            {
                var secret = await _client.GetSecretAsync(secretName);
                return secret.Value.Value;
            }
            catch (Exception ex)
            {
                throw new InvalidSecretException($"Failed to get secret: {ex.Message}");
            }
        }
    }
}
