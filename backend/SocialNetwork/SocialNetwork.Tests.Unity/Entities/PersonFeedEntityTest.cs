using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Resources;

namespace SocialNetwork.Tests.Unity.Entities
{
    public class PersonFeedEntityTest
    {
        [Fact]
        public void Create_PersonFeed_Sucess()
        {
            //Arrange & Act
            var newPersonFeed = new PersonFeedEntity(1, "message");

            //Assert
            Assert.NotNull(newPersonFeed);
            Assert.NotEmpty(newPersonFeed.Message);
        }

        [Fact]
        public void Message_Not_Empty()
        {
            //Arrange && Act
            var exception = Record.Exception(() => new PersonFeedEntity(1, string.Empty));

            //Assert
            Assert.Equal(exception.Message, DomainValidationsResource.FeedMessageNotEpty);
        }

        [Fact]
        public void Message_IdPerson_Not_Zero()
        {
            //Arrange && Act
            var exception = Record.Exception(() => new PersonFeedEntity(0, "mensagem"));

            //Assert
            Assert.Equal(exception.Message, DomainValidationsResource.FeedIdPersonNotNull);
        }
    }
}
