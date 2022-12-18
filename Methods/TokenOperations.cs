using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmbroidaryManagementSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace EmbroidaryManagementSystem.Methods
{
    public class TokenOperations
    {
        private IConfiguration _configuration;

        public TokenOperations(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(object data)
        {
            jwtSettings jwt_settings = _configuration.GetSection("JWT").Get<jwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwt_settings.SecurityKey);

            var expiresTime = DateTime.UtcNow.AddMinutes(double.Parse(jwt_settings.ExpiresTime.ToString()));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = jwt_settings.Audience,
                Issuer = jwt_settings.Issuer,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Data", data.ToString())
                    //new Claim("Data", data.Username.ToString()),
                    //new Claim("Data", data.ToString()),
                    //new Claim("Data", data.ToString()),
                    //new Claim("Data", data.ToString()),
                    //new Claim("Data", data.ToString())
                }),
                Expires = expiresTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public string DecodeToken(string token)
        {
            var tokenClaimUser = string.Empty;
            var handler = new JwtSecurityTokenHandler();
            if (handler.ReadToken(token.Substring(7)) is JwtSecurityToken jwtToken)
            {
                tokenClaimUser = jwtToken.Claims.First(claim => claim.Type == "User").Value;
            }
            return tokenClaimUser;
        }

    }
}
