using Bogus;
using SocialNetwork.Application.Structures;
using SocialNetwork.Application.ViewModel;
using SocialNetwork.Tests.Integration.Configurations;
using SocialNetwork.Tests.Integration.Mocks;
using SocialNetwork.Tests.Integration.Share;
using System.Net;
using System.Net.Http.Headers;

namespace SocialNetwork.Tests.Integration.Tests
{
    public class FeedControllerTest : ApiTestsBase
    {
        private TokenViewModel _token;

        public FeedControllerTest(ApiTestFixture factory) : base(factory)
        {
            GetToken().Wait();
        }

        [Fact]
        public async Task PostMessageAsync_Sucess()
        {
            //Arrange
            var newMessage = NewPost();

            //Act
            var response = await Client.PostAsync("/api/Feed", CreateContent(newMessage));

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task FeedPaged_SUcess()
        {
            //Arrange
            var newMessage = NewPost();
            await Client.PostAsync("/api/Feed", CreateContent(newMessage));

            var query = new PageQuery() { Page = 1, Size = 10 };

            //Act
            var response = await Client.PostAsync("/api/Feed/Paged", CreateContent(query));
            var contentResponse = await response.Content.ReadAsStringAsync();

            var pagedResult = DeserializeObject<PageResult>(contentResponse);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(pagedResult.DataSource);
        }

        private static PostMessageViewModel NewPost()
        {
            var faker = new Faker(TestConfiguration.FAKER_LANGUAGE);
            var newMessage = new PostMessageViewModel()
            {
                Message = faker.Lorem.Paragraph()
            };
            return newMessage;
        }

        private async Task GetToken()
        {
            var personMock = PersonEntityMock.PersonMock();
            var tokenRequest = new LoginViewModel() { Email = personMock.Email, Password = TestConfiguration.PERSON_PASSWORD };

            var response = await Client.PostAsync("/api/Login", CreateContent(tokenRequest));
            var stringContent = await response.Content.ReadAsStringAsync();

            _token = DeserializeObject<TokenViewModel>(stringContent);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.Token);
        }
    }
}
