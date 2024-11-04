using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.Context;
using SocialNetwork.Tests.Integration.Mocks;

namespace SocialNetwork.Tests.Integration.Share
{
    public class ApiTestFixture : WebApplicationFactory<Program>, IDisposable
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<SocialNetworkDataContext>(options => options.UseSqlite("DataSource=:memory:"));

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<SocialNetworkDataContext>();

                dbContext.Database.OpenConnection();
                dbContext.Database.EnsureCreated();                

                ConfigurePersonMock(dbContext);
            });
        }

        private static void ConfigurePersonMock(SocialNetworkDataContext dbContext)
        {
            dbContext.Persons.ExecuteDelete();

            dbContext.Persons.Add(PersonEntityMock.PersonMock());
            dbContext.SaveChanges();
        }
    }
}
