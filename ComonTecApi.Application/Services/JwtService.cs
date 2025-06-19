using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ComonTecApi.Domain.Entities;
using ComonTecApi.Application.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ComonTecApi.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var issuerKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Schemes:IssuerKey"]!));

            var creds = new SigningCredentials(issuerKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Authentication:Schemes:ValidIssuer"]!,
                audience: _configuration["Authentication:Schemes:ValidIssuer"]!,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
