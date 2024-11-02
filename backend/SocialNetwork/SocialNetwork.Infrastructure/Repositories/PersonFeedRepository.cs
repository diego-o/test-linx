using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Structures;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;

namespace SocialNetwork.Infrastructure.Repositories
{
    public class PersonFeedRepository : IPersonFeedRepository
    {
        private readonly ISocialNetworkDataContext _dataContext;

        public PersonFeedRepository(ISocialNetworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PageResult> GetPaginatedAllAsync(PageQuery page)
        {
            var feeds = await _dataContext.Feeds
                .Include(t => t.Person)
                .AsNoTracking()
                .Where(t => t.DateMessage >= DateTime.Now.Date)
                .OrderByDescending(t => t.DateMessage)
                .Skip((page.Page - 1) * page.Size)
                .Take(page.Size)
                .ToListAsync();

            var totalFeeds =  await _dataContext.Feeds.AsNoTracking().Where(t => t.DateMessage >= DateTime.Now.Date).CountAsync();
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
                    t.Message,
                    t.Person.Name
                }).ToList()
            };
        }

        public async Task InsertAsync(PersonFeedEntity personFeed)
        {
            await _dataContext.Feeds.AddAsync(personFeed);
            await _dataContext.SaveChangesAsync();
        }
    }
}
