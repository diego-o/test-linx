using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Context;
using SocialNetwork.Infrastructure.Repositories;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

namespace SocialNetwork.Infrastructure.Configurations
{
    public static class InfrastructureIOCConfiguration
    {
        public static void ConfigureIOCInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISocialNetworkDataContext, SocialNetworkDataContext>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonFeedRepository, PersonFeedRepository>();
        }
    }
}
