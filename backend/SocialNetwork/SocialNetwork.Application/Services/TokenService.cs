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

        public string GenerateJWTToken(string userName, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new(ClaimTypes.Name, userName),
                    new("userId", userId.ToString())
                ]),
                Expires = ExpireIn(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Convert.FromBase64String(_secret);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if (validatedToken is not JwtSecurityToken jwtToken ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("token invalido");

                return principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token inválido: {ex.Message}");
                throw new SecurityTokenException("token invalido");
            }
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
