using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.Structures;
using SocialNetwork.Application.ViewModel;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Services
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

        public void PostMessage(PostMessageViewModel postMessage)
        {
            var newPost = new PersonFeedEntity(_currentUser.IdPersonCurrent, postMessage.Message);
            _personFeedRepository.Insert(newPost);
        }

        public PageResult Paged(PageQuery pageQuery) =>
            _personFeedRepository.GetPaginatedAll(pageQuery);
    }
}
