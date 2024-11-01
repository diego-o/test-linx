using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.Context.ModelBuilders
{
    internal static class PersonFeedModelBuilder
    {
        public static void Builder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonFeedEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Message).IsRequired();
                e.HasOne(t => t.Person).WithMany(t => t.Feeds);
            });
        }
    }
}
