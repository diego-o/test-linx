using SocialNetwork.Application.Structures;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Repositories
{
    public interface IPersonFeedRepository
    {
        Task InsertAsync(PersonFeedEntity personFeed);
        Task<PageResult> GetPaginatedAllAsync(PageQuery page);
    }
}
