using NSubstitute;
using SocialNetwork.Application.Repositories;
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
            _personRepository.InsertAsync(newPerson).Returns(newPerson);

            //Act
            var exception = Record.ExceptionAsync(async () => await _personRepository.InsertAsync(newPerson));

            //Assert
            Assert.Null(exception.Exception);
        }

        [Fact]
        public async Task GetByEmail_SucessAsync() 
        {
            //Arrange
            var newPerson = PersonFaker.NewPersonEntity();
            _personRepository.GetByEmailAsync(newPerson.Email).Returns(newPerson);

            //Act
            var person = await _personRepository.GetByEmailAsync(newPerson.Email);

            //Assert
            Assert.NotNull(person);
        }
    }
}
