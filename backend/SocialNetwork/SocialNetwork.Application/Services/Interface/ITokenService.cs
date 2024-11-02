using System.IdentityModel.Tokens.Jwt;

namespace SocialNetwork.Application.Services.Interface
{
    public interface ITokenService
    {
        int ExpiredTimeToken();
        DateTime ExpireIn();
        JwtSecurityToken? FromToken(string token);
        string GenerateJWTToken(string UserName, int userId);
    }
}