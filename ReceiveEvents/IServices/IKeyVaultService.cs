using ReceiveEvents.Configuration;

namespace ReceiveEvents.IServices
{
    public interface IKeyVaultService
    {
        Task<SecretsConfigurations> GetSecretConfigurationsAsync();
    }
}
