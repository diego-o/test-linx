using Bogus;
using SocialNetwork.Application.ViewModel;
using SocialNetwork.Tests.Integration.Configurations;

namespace SocialNetwork.Tests.Integration.Fakers
{
    public static class NewPersonViewModelFaker
    {
        public static NewPersonViewModel NewPersonViewModelFake()
        {
            var faker = new Faker(TestConfiguration.FAKER_LANGUAGE);

            return new NewPersonViewModel()
            {
                Birth = faker.Person.DateOfBirth,
                Email = faker.Person.Email,
                Name = faker.Person.FullName,
                Password = TestConfiguration.PERSON_PASSWORD
            };
        }
    }
}
