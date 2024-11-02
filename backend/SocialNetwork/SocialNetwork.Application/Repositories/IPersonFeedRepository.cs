using SocialNetwork.Application.Structures;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Repositories
{
    public interface IPersonFeedRepository
    {
        void Insert(PersonFeedEntity personFeed);
        PageResult GetPaginatedAll(PageQuery page);
    }
}
