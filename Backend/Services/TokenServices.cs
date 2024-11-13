using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.Extensions.Configuration;
using NuGet.Common;

namespace Backend.Services
{
    public class TokenServices
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _ExpiryMinute;

        public TokenServices(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Key"]!;
            _issuer = configuration["Jwt:Issuer"]!;
            _audience = configuration["Jwt:Audience"]!;
            _ExpiryMinute = configuration["Jwt:ExpiryMinute"]!;
        }

        public string GenerateToken(Users users)
        {
            var claims = new [] {
                new Claim(JwtRegisteredClaimNames.Sub, users.Username),
                new Claim(JwtRegisteredClaimNames.Sub, users.Password),

            };
            return JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
