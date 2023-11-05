using Application.Auth.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MauRealEstateCompany.Api.Auth
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GetToken(UserDto user) {
            string token = string.Empty;
            var jwtSecretKetBytes = Encoding.UTF8.GetBytes(_configuration["JwtSetting:SecretKey"] ?? string.Empty);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecretKetBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }
    }
}
