using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Context;
using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.Services;
using SocialNetwork.Infrastructure.Repositories;

namespace SocialNetwork.Api.Configurations
{
    public static class IOCConfiguration
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddScoped<ISocialNetworkDataContext, SocialNetworkDataContext>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonFeedRepository, PersonFeedRepository>();

            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IPersonFeedService, PersonFeedService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddSingleton<ITokenService, TokenService>();
        }
    }
}
