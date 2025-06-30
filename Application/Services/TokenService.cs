using FamilyStoryApi.Core.Configurations;
using FamilyStoryApi.Infra.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamilyStoryApi.Application.Services
{
    public class TokenService
    {
        public string GenerateToken(UserInfo user)
        {
            var handler = new JwtSecurityTokenHandler();
 
            var credentials = new SigningCredentials
                (
                     key: new SymmetricSecurityKey(TokenConfiguration.Key), 
                     SecurityAlgorithms.HmacSha256
                 );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserInfo user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(type: "Id", value: user.UserId.ToString()));
            ci.AddClaim(new Claim(type: ClaimTypes.Name, value: user.Email));
            ci.AddClaim(new Claim(type: ClaimTypes.Email, value: user.Email));
            ci.AddClaim(new Claim(type: ClaimTypes.GivenName, value: user.Name));

            ci.AddClaim(new Claim(type: ClaimTypes.Role, value: "admin"));

            return ci;
        }
    }
}
