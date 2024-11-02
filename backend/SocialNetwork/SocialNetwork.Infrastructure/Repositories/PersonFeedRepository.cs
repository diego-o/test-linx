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

        public PageResult GetPaginatedAll(PageQuery page)
        {
            var feeds = _dataContext.Feeds
                .AsNoTracking()
                .Where(t => t.DateMessage >= DateTime.Now.Date)
                .OrderBy(t => t.DateMessage)
                .Skip((page.Page - 1) * page.Size)
                .Take(page.Size)
                .ToList();

            var totalFeeds = _dataContext.Feeds.AsNoTracking().Where(t => t.DateMessage >= DateTime.Now.Date).Count();
            var totalPages = (int)Math.Ceiling((double)totalFeeds / page.Size);

            return new PageResult()
            {
                CurrentPage = page.Page,
                Lines = page.Size,
                Pages = totalPages,
                Total = totalFeeds,
                DataSource = feeds.Select(t => new
                {
                    t.Id,
                    t.DateMessage,
                    t.Message
                }).ToList()
            };
        }

        public void Insert(PersonFeedEntity personFeed)
        {
            _dataContext.Feeds.Add(personFeed);
            _dataContext.SaveChanges();
        }
    }
}
