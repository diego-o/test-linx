using Bogus;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Tests.Unity.Fakers
{
    public static class TokenViewModelFaker
    {
        public static TokenViewModel TokenViewModelFake()
        {
            var faker = new Faker("pt_BR");
            return new TokenViewModel()
            {
                Expires = DateTime.UtcNow,
                ExpiresIn = 600,
                Issued = DateTime.UtcNow,
                Token = faker.Random.AlphaNumeric(200)
            };
        }
    }
}
