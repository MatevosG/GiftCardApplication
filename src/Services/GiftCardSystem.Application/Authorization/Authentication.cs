using GiftCardSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Authorization
{
    public class Authentication : IAuthentication
    {
        private readonly AuthOptions _authOptions;
        public Authentication(IConfiguration configuration)
        {
            _authOptions = new AuthOptions();
            configuration.GetSection("AuthSettings").Bind(_authOptions);
        }
        private List<Claim> GetClientClaims(Client client)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
                new Claim(nameof(client.Email), client.Email),
                new Claim(nameof(client.FirstName), client.FirstName),
                new Claim(nameof(client.LastName), client.LastName),
                new Claim(nameof(client.PhoneNumber), client.PhoneNumber),
            };
            return claims;
        }
        private JwtSecurityToken GenerateJwtToken(List<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Key));
            var jwt = new JwtSecurityToken(
                       issuer: _authOptions.Issuer,
                       audience: _authOptions.Audience,
                       notBefore: now,
                       claims: claims,
                       expires: now.Add(TimeSpan.FromMinutes(_authOptions.Lifetime)),
                       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            return jwt;
        }
        public string CreateJwtToken(Client client)
        {
            var Claims = GetClientClaims(client);
            var jwt = GenerateJwtToken(Claims);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
