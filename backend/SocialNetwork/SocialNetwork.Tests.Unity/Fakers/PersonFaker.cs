using Bogus;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Tests.Unity.Fakers
{
    public static class PersonFaker
    {
        public static PersonEntity NewPersonEntity()
        {
            var faker = new Faker("pt_BR");
            return new PersonEntity(
                faker.Person.FullName, 
                faker.Person.Email, 
                faker.Person.DateOfBirth, 
                "asb123#$12B");
        }
    }
}
