using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNetwork.Api.Services
{
    public static class TokenService
    {
        private static string _secret => "ldh587143luortyq659dhf01mgh624zx";

        public static byte[] Key => Encoding.ASCII.GetBytes(_secret);
        public static int ExpiredTimeToken { get; set; } = 30;

        public static string GenerateJWTToken(string UserName, int userId)
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

        public static JwtSecurityToken? FromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);

            return handler.ReadToken(token) as JwtSecurityToken;
        }

        public static DateTime ExpireIn()
        {
            return DateTime.UtcNow.AddMinutes(ExpiredTimeToken);
        }
    }
}
