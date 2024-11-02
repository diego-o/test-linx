using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Infrastructure.Repositories.Interfaces
{
    public interface IPersonFeedRepository
    {
        void Insert(PersonFeedEntity personFeed);
        void Delete(PersonFeedEntity personFeed);
        PersonFeedEntity? GetById(int personFeedId);
        PageResult GetPaginatedAll(PageQuery page);
    }
}
