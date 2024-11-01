using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

namespace SocialNetwork.Api.Services
{
    public class PersonFeedService : IPersonFeedService
    {
        private readonly IPersonFeedRepository _personFeedRepository;

        public PersonFeedService(IPersonFeedRepository personFeedRepository)
        {
            _personFeedRepository = personFeedRepository;
        }

        public void PostMessage(PostMessageModel postMessage)
        {
            try
            {
                var newPost = new PersonFeedEntity(postMessage.IdPerson, postMessage.Message);
                _personFeedRepository.Insert(newPost);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
