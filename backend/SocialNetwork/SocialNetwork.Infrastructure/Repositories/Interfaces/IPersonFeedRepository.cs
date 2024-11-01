using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Infrastructure.Repositories.Interfaces
{
    public interface IPersonFeedRepository
    {
        void Insert(PersonFeedEntity personFeed);
        void Delete(PersonFeedEntity personFeed);
        PersonFeedEntity? GetById(int personFeedId);
        PageResult GetPaginatedByIdPerson(int idPerson, PageQuery page);
        PageResult GetPaginatedAll(int idPerson, PageQuery page);
    }
}
