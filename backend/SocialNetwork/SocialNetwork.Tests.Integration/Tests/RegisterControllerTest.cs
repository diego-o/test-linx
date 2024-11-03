using SocialNetwork.Tests.Integration.Fakers;
using SocialNetwork.Tests.Integration.Share;
using System.Net;

namespace SocialNetwork.Tests.Integration.Tests
{
    public class RegisterControllerTest : ApiTestsBase
    {
        public RegisterControllerTest(ApiTestFixture factory) : base(factory)
        {
        }

        [Fact]
        public async Task NewAccountAsync()
        {
            //Arrange
            var newPerson = NewPersonViewModelFaker.NewPersonViewModelFake();

            //Act
            var response = await Client.PostAsync("/api/Register", CreateContent(newPerson));

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
