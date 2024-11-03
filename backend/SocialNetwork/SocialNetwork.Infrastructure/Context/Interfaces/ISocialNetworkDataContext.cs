using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.Context.Interfaces
{
    public interface ISocialNetworkDataContext : IDbContext
    {
        DbSet<PersonEntity> Persons { get; set; }
        DbSet<PersonFeedEntity> Feeds { get; set; }

        DatabaseFacade Database { get; }
    }
}