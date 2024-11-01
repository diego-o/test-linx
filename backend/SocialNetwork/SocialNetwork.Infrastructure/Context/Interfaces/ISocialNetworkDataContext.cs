using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.Context.Interfaces
{
    public interface ISocialNetworkDataContext : IDbContext
    {
        DbSet<PersonEntity> Persons { get; set; }
        DbSet<PersonFeedEntity> Feeds { get; set; }
    }
}