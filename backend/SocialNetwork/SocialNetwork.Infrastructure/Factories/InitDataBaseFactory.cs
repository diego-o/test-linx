using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialNetwork.Infrastructure.Configurations;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.Infrastructure.Factories
{
    internal class InitDataBaseFactory : IDesignTimeDbContextFactory<SocialNetworkDataContext>
    {
        public SocialNetworkDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SocialNetworkDataContext>();

            var strConnection = AppSettings.ConnectionString("DbSocialNetwork");
            Console.WriteLine("Connection string: {0}", strConnection);

            optionsBuilder.UseNpgsql(strConnection);

            return new SocialNetworkDataContext(optionsBuilder.Options);
        }
    }
}
