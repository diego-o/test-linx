using SocialNetwork.Api.Services;
using SocialNetwork.Api.Services.Interface;

namespace SocialNetwork.Api.Configurations
{
    public static class IOCConfiguration
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IPersonFeedService, PersonFeedService>();
        }
    }
}
