using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialNetwork.Application.Services.Interface
{
    public interface ITokenService
    {
        int ExpiredTimeToken();
        DateTime ExpireIn();
        JwtSecurityToken? FromToken(string token);
        string GenerateJWTToken(string userName, int userId);
        ClaimsPrincipal? ValidateToken(string token);
    }
}