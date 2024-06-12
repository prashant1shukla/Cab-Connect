﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Assigmnent_2.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assigmnent_2.Services.IServices;

namespace Assigmnent_2.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }

        //Generating the JWT Token
        public string GenerateToken(UserModel user)
        {
            // providing the security key and credentials for token generation
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Taking data from appsettings.json
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                    // Add additional claims if needed (e.g., user roles)
                },
                expires: DateTime.UtcNow.AddMinutes(30), // Token expires in 30 minutes
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
