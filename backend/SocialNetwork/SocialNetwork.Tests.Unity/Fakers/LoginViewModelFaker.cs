using Bogus;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Tests.Unity.Fakers
{
    public static class LoginViewModelFaker
    {
        public static LoginViewModel LoginViewModelFake()
        {
            var faker = new Faker("pt_BR");

            return new LoginViewModel()
            {
                Email = faker.Person.Email,
                Password = faker.Random.AlphaNumeric(8)
            };
        }
    }
}
