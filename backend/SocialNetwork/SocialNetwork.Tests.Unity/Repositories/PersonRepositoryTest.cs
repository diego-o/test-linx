using NSubstitute;
using SocialNetwork.Application.Repositories;
using SocialNetwork.Domain.Resources;
using SocialNetwork.Tests.Unity.Fakers;

namespace SocialNetwork.Tests.Unity.Repositories
{
    public class PersonRepositoryTest
    {
        private readonly IPersonRepository _personRepository = Substitute.For<IPersonRepository>();

        [Fact]
        public void Insert_Sucess()
        {
            //Arrange
            var newPerson = PersonFaker.NewPersonEntity();
            _personRepository.Insert(newPerson).Returns(newPerson);

            //Act
            var exception = Record.Exception(() => _personRepository.Insert(newPerson));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void GetByEmail_Sucess() 
        {
            //Arrange
            var newPerson = PersonFaker.NewPersonEntity();
            _personRepository.GetByEmail(newPerson.Email).Returns(newPerson);

            //Act
            var person = _personRepository.GetByEmail(newPerson.Email);

            //Assert
            Assert.NotNull(person);
        }
    }
}
