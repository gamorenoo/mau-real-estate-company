using Application.Auth.Login;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public bool Login(string username, string password)
        {
            var userIdValid = username.Equals("gustavoamoreno@outlook.com") && password.Equals("0123456789");
            return userIdValid;
        }

        /// <inheritdoc/>
        public string GetToken(string username)
        {
            string token = string.Empty;
            var jwtSecretKetBytes = Encoding.UTF8.GetBytes(_configuration["JwtSetting:SecretKey"] ?? string.Empty);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));

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
