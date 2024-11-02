using NSubstitute;
using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Structures;
using SocialNetwork.Tests.Unity.Fakers;

namespace SocialNetwork.Tests.Unity.Repositories
{
    public class PersonFeedRepositoryTest
    {
        private readonly IPersonFeedRepository _personFeedRepository = Substitute.For<IPersonFeedRepository>();

        [Fact]
        public async Task InsertAsync_Sucess()
        {
            //Arrange
            var newPerson = PersonFaker.NewPersonEntity();
            var newPersonFeed = PersonFeedFaker.NewPersonFeedEntity(newPerson);

            //Act
            var exception = Record.ExceptionAsync(async () => await _personFeedRepository.InsertAsync(newPersonFeed));

            Assert.NotNull(exception);
            Assert.Null(exception.Exception);
        }

        [Fact]
        public async Task GetPaginatedAllAsync_Sucess()
        {
            //Arrange
            var page = new PageQuery() { Page = 1, Size = 10 };

            var newPerson = PersonFaker.NewPersonEntity();
            var feeds = PersonFeedFaker.NewListPersonFeedEntity(newPerson);

            _personFeedRepository.GetPaginatedAllAsync(page).Returns(new PageResult()
            {
                CurrentPage = 1,
                Lines = 10,
                Pages = 1,
                Total = 10,
                DataSource = feeds
            });

            //Act
            var paged = await _personFeedRepository.GetPaginatedAllAsync(page);

            //Assert
            Assert.NotEmpty(paged.DataSource);
        }
    }
}
