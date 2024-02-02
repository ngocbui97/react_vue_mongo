using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JobVietAPI.Services
{
    public class JwtService
    {

        private readonly string _secret;
        private readonly string _expDate;
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        public JwtService(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public string GenerateSecurityToken(string email, Boolean isRefreshToken)
        {
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = !isRefreshToken ? DateTime.UtcNow.AddMinutes(double.Parse(_expDate)) : DateTime.UtcNow.AddMinutes(double.Parse(_expDate)*10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
        public string DecodeToken(string token)
        {
            var jwtSecurityToken = _tokenHandler.ReadJwtToken(token);

            var emailClaim = jwtSecurityToken.Claims.First(claim => claim.Type == "email");
            if (emailClaim != null) return emailClaim.Value;
            return null;
        }
    }
}
