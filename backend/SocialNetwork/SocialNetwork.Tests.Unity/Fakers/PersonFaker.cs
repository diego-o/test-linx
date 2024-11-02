using Bogus;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Tests.Unity.Fakers
{
    public static class PersonFaker
    {
        public static PersonEntity NewPersonEntity()
        {
            var faker = new Faker("pt_BR");
            var person = new PersonEntity(
                faker.Person.FullName, 
                faker.Person.Email, 
                faker.Person.DateOfBirth, 
                "asb123#$12B");

            person.SetId(faker.Random.Number(1, 1000));

            return person;
        }
    }
}
