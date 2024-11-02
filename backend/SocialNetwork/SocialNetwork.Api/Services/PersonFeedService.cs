using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

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
            try
            {
                var newPost = new PersonFeedEntity(_currentUser.IdPersonCurrent, postMessage.Message);
                _personFeedRepository.Insert(newPost);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
