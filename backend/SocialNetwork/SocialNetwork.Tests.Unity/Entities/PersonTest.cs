using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Resources;

namespace SocialNetwork.Tests.Unity.Entities
{
    public class PersonTest
    {
        [Fact]
        public void Create_Person_Sucess() 
        {
            //Arrange & Act
            var newPerson = new PersonEntity("Diego de Souza", "diego_1souza@hotmail.com", Convert.ToDateTime("1992-03-10"), "Diego@123");

            //Assert
            Assert.NotNull(newPerson);
            Assert.NotEmpty(newPerson.Name);
            Assert.NotEmpty(newPerson.Email);
            Assert.NotEmpty(newPerson.Password);
        }

        [Fact]
        public void Name_Not_Empty()
        {
            //Arrange && Act
            var exception = Record.Exception(() => new PersonEntity(string.Empty, "diego_1souza@hotmail.com", Convert.ToDateTime("1992-10-03"), ""));

            //Assert
            Assert.Equal(exception.Message, DomainValidationsResource.PersonNameEmpty);
        }

        [Fact]
        public void Email_Invalid()
        {
            //Arrange && Act
            var exception = Record.Exception(() => new PersonEntity("Diego", "diego_1souza", Convert.ToDateTime("1992-10-03"), ""));

            //Assert
            Assert.Equal(exception.Message, DomainValidationsResource.EmailInvalid);
        }

        [Theory]
        [InlineData("2023-10-03", "Data de nascimento invalida, necessário ter mais que 16 anos")]
        [InlineData("1500-10-03", "Data de nascimento invalida, pessoa com mais de 150 anos")]
        public void Validate_Birth_Invalid(string date, string messageValidation)
        {
            //Arrange && Act
            var exception = Record.Exception(() => new PersonEntity("Diego", "diego_1souza@hotmail.com", Convert.ToDateTime(date), ""));

            //Assert
            Assert.Equal(exception.Message, messageValidation);
        }

        [Fact]
        public void Validate_Password()
        {
            //Arrange & Act
            var exception = Record.Exception(() => new PersonEntity("Diego", "diego_1souza@hotmail.com", Convert.ToDateTime("1992-03-10"), "123abc"));

            //Assert
            Assert.Equal(exception.Message, DomainValidationsResource.PasswordInvalid);
        }
    }
}
