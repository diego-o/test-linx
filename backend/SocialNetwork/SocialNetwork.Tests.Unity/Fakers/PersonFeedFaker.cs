using Bogus;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Tests.Unity.Fakers
{
    internal static class PersonFeedFaker
    {
        public static PersonFeedEntity NewPersonFeedEntity(PersonEntity person)
        {
            var faker = new Faker("pt_BR");
            return new PersonFeedEntity(person.Id, faker.Lorem.Paragraph());
        }

        public static List<PersonFeedEntity> NewListPersonFeedEntity(PersonEntity person)
        {
            return new Faker<PersonFeedEntity>("pt_BR").Rules((faker, obj) =>
            {
                obj = new PersonFeedEntity(person.Id, faker.Lorem.Paragraph());
            }).Generate(10);
        }
    }
}
