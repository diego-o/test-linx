using SocialNetwork.Application.Services;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Tests.Integration.Configurations;

namespace SocialNetwork.Tests.Integration.Mocks
{
    internal static class PersonEntityMock
    {
        public static PersonEntity PersonMock()
        {
            var userName = "integrationtest@integrationtest.com";
            var user = new User() { UserName = userName };
            var password = PasswordService.HashPassword(user, TestConfiguration.PERSON_PASSWORD);

            return new PersonEntity(
                "Integration Test",
                userName,
                Convert.ToDateTime("2000-01-01"),
                password);
        }
    }
}
