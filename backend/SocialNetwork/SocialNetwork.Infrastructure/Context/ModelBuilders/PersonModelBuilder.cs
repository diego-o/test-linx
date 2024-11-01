using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.Context.ModelBuilders
{
    internal static class PersonModelBuilder
    {
        public static void Builder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(120);
                e.Property(e => e.Birth).IsRequired();
                e.Property(e => e.Password).IsRequired();
                e.Property(e => e.Email).IsRequired().HasMaxLength(100);
                e.HasMany(t => t.Feeds).WithOne(t => t.Person).HasForeignKey(t => t.IdPerson);
            });
        }
    }
}
