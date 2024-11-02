using SocialNetwork.Api.Services;
using SocialNetwork.Api.Services.Interface;

namespace SocialNetwork.Api.Middleware
{
    public class JwtUserMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUser currentUser)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                var token = authorizationHeader.ToString().Replace("Bearer ", string.Empty);
                var jwtToken = TokenService.FromToken(token);
                var userId = jwtToken?.Claims.FirstOrDefault(t => t.Type == "userId")?.Value;
                if (userId != null)
                    currentUser.IdPersonCurrent = Convert.ToInt32(userId);
            }

            await _next(context);
        }
    }
}
