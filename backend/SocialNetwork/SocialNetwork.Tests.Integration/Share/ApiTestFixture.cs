using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.Tests.Integration.Share
{
    [Collection("ApiInstance")]
    public class ApiTestFixture : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<SocialNetworkDataContext>(options => options.UseSqlite("datasource=:memory:"));

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<SocialNetworkDataContext>();

                dbContext.Database.OpenConnection();
                var sql = dbContext.Database.GenerateCreateScript();
                dbContext.Database.EnsureCreated();
            });
        }
    }
}
