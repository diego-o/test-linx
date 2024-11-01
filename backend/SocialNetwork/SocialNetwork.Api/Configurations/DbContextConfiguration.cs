using Microsoft.EntityFrameworkCore;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.Api.Configurations
{
    public static class DbContextConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialNetworkDataContext>(opitons =>
            {
                opitons.UseNpgsql(configuration.GetConnectionString("DbSocialNetwork"));
            });
        }
    }
}
