using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmacyManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PharmacyManagementSystem.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual string GenerateToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Role, user.Role!)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}