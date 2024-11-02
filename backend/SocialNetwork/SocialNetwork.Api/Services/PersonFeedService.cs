using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Interfaces;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Api.Services
{
    public class PersonFeedService : IPersonFeedService
    {
        private readonly IPersonFeedRepository _personFeedRepository;
        private readonly ICurrentUser _currentUser;

        public PersonFeedService(IPersonFeedRepository personFeedRepository, ICurrentUser currentUser)
        {
            _personFeedRepository = personFeedRepository;
            _currentUser = currentUser;
        }

        public void PostMessage(PostMessageModel postMessage)
        {
            var newPost = new PersonFeedEntity(_currentUser.IdPersonCurrent, postMessage.Message);
            _personFeedRepository.Insert(newPost);
        }

        public PageResult Paged(PageQuery pageQuery) =>
            _personFeedRepository.GetPaginatedAll(pageQuery);
    }
}
