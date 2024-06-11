using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVault.Models.Request;
using KeyVault.IServices;
using KeyVault.CustomException;

namespace KeyVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly ICreateSecretService _createSecretService;
        private readonly IGetSecretService _getSecretService;
        private readonly IDeleteSecretService _deleteSecretService;
        private readonly IPurgeSecretService _purgeSecretService;

        public KeyVaultController(ICreateSecretService createSecretService, IGetSecretService getSecretService,
            IDeleteSecretService deleteSecretService, IPurgeSecretService purgeSecretService)
        {
            _createSecretService = createSecretService;
            _getSecretService = getSecretService;
            _deleteSecretService = deleteSecretService;
            _purgeSecretService = purgeSecretService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSecret(SecretsRequest secretsRequest)
        {
            try
            {
                await _createSecretService.CreateSecretAsync(secretsRequest);
                return Ok("Secret created successfully.");
            }
            catch (FailedToCreateSecretException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{secretName}")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {
                var secret = await _getSecretService.GetSecretAsync(secretName);
                return Ok(secret);
            }
            catch (InvalidSecretException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{secretName}")]
        public async Task<IActionResult> DeleteSecret(string secretName)
        {
            try
            {
                await _deleteSecretService.DeleteSecretAsync(secretName);
                return Ok($"Secret '{secretName}' deleted successfully.");
            }
            catch (InvalidSecretException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{secretName}/purge")]
        public async Task<IActionResult> PurgeSecret(string secretName)
        {
            try
            {
                await _purgeSecretService.PurgeSecretAsync(secretName);
                return Ok($"Secret '{secretName}' purged successfully.");
            }
            catch (InvalidSecretException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
