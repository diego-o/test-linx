using SocialNetwork.Application.ViewModel;
using SocialNetwork.Tests.Integration.Fakers;
using SocialNetwork.Tests.Integration.Share;
using System.Net;

namespace SocialNetwork.Tests.Integration.Tests
{
    public class LoginControllerTest : ApiTestsBase
    {
        public LoginControllerTest(ApiTestFixture factory) : base(factory)
        {
        }

        [Fact]
        public async Task LoginAsync()
        {
            //Arrange
            var newPerson = NewPersonViewModelFaker.NewPersonViewModelFake();
            await Client.PostAsync("/api/Register", CreateContent(newPerson));

            var loginRequest = new LoginViewModel() { Email = newPerson.Email, Password = newPerson.Password };

            //Act
            var loginResponse = await Client.PostAsync("/api/Login", CreateContent(loginRequest));
            var responseContent = await loginResponse.Content.ReadAsStringAsync();
            var token = DeserializeObject<TokenViewModel>(responseContent);

            //Assert
            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
            Assert.False(string.IsNullOrWhiteSpace(token.Token));
        }
    }
}
