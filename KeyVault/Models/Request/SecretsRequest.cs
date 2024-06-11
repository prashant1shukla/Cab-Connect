using System.ComponentModel.DataAnnotations;

namespace KeyVault.Models.Request
{
    public class SecretsRequest
    {
        [Required]
        public string SecretName { get; set; }
        [Required]
        public string SecretValue { get; set; }

    }
}
