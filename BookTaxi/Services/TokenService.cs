using BookTaxi.IServices;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookTaxi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }

        /// <summary>
        /// Generates the JWT token
        /// </summary>
        public string GenerateToken(LoginResponse user)
        {
            // providing the security key and credentials for token generation
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Taking data from appsettings.json
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.Email, user.Email), // Added Email claim
                    new Claim("UserType", user.UserType) // Add UserType claim
                },
                expires: DateTime.UtcNow.AddMinutes(30), // Token expires in 30 minutes
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
