using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNetwork.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string _secret => _configuration.GetValue<string>("JWT:Secret");

        public byte[] Key => Encoding.ASCII.GetBytes(_secret);

        public string GenerateJWTToken(string UserName, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new(ClaimTypes.Name, UserName),
                    new("userId", userId.ToString())
                ]),
                Expires = ExpireIn(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken? FromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            handler.ReadToken(token);
            return handler.ReadToken(token) as JwtSecurityToken;
        }

        public DateTime ExpireIn() =>
            DateTime.UtcNow.AddMinutes(ExpiredTimeToken());

        public int ExpiredTimeToken() =>
            _configuration.GetValue<int>("JWT:ExpiredTimeToken");
    }
}
