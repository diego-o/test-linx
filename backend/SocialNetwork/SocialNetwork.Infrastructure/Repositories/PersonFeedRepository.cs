using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Repositories.Interfaces;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Infrastructure.Repositories
{
    internal class PersonFeedRepository : IPersonFeedRepository
    {
        private readonly ISocialNetworkDataContext _dataContext;

        public PersonFeedRepository(ISocialNetworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(PersonFeedEntity personFeed)
        {
            _dataContext.Feeds.Remove(personFeed);
            _dataContext.SaveChanges();
        }

        public PersonFeedEntity? GetById(int personFeedId) =>
            _dataContext.Feeds.AsNoTracking().FirstOrDefault(t => t.Id == personFeedId);

        public PageResult GetPaginatedAll(int idPerson, PageQuery page)
        {
            throw new NotImplementedException();
        }

        public PageResult GetPaginatedByIdPerson(int idPerson, PageQuery page)
        {
            throw new NotImplementedException();
        }

        public void Insert(PersonFeedEntity personFeed)
        {
            _dataContext.Feeds.Add(personFeed);
            _dataContext.SaveChanges();
        }
    }
}
