using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ReceiveEvents.Configuration;
using ReceiveEvents.IServices;

namespace ReceiveEvents.Services
{
    public class KeyVaultService: IKeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(Uri keyVaultUri)
        {
            var credential = new DefaultAzureCredential();
            _secretClient = new SecretClient(keyVaultUri, credential);
        }

        public async Task<SecretsConfigurations> GetSecretConfigurationsAsync()
        {
            var secretConfigurations = new SecretsConfigurations();

            secretConfigurations.ReceiverEventHubConnectionString = await GetSecretAsync("ReceiverEventHubConnectionString");
            secretConfigurations.EventHubName = await GetSecretAsync("EventHubName");
            secretConfigurations.BlobStorageConnectionString = await GetSecretAsync("BlobStorageConnectionString");
            secretConfigurations.BlobContainerName = await GetSecretAsync("BlobContainerName");
            secretConfigurations.SenderEventHubConnectionString = await GetSecretAsync("SenderEventHubConnectionString");

            return secretConfigurations;
        }

        private async Task<string> GetSecretAsync(string secretName)
        {
            try
            {
                var secret = await _secretClient.GetSecretAsync(secretName);
                return secret.Value.Value;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to retrieve secret '{secretName}' from Key Vault.", ex);
            }
        }
    }
}
