using Bogus;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Tests.Integration.Fakers
{
    public static class NewPersonViewModelFaker
    {
        public static NewPersonViewModel NewPersonViewModelFake()
        {
            var faker = new Faker("pt_BR");

            return new NewPersonViewModel()
            {
                Birth = faker.Person.DateOfBirth,
                Email = faker.Person.Email,
                Name = faker.Person.FullName,
                Password = "asdGW213@"
            };
        }
    }
}
