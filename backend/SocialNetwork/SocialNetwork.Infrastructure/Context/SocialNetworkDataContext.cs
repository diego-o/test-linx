using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Context.ModelBuilders;

namespace SocialNetwork.Infrastructure.Context
{
    public class SocialNetworkDataContext : DbContext, ISocialNetworkDataContext
    {
        public SocialNetworkDataContext(DbContextOptions<SocialNetworkDataContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<PersonFeedEntity> Feeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonModelBuilder.Builder(modelBuilder);
            PersonFeedModelBuilder.Builder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}