﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Context.ModelBuilders;

namespace SocialNetwork.Infrastructure.Context
{
    public class SocialNetworkDataContext : DbContext, ISocialNetworkDataContext
    {
        public SocialNetworkDataContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<PersonFeedEntity> Feed { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonModelBuilder.Builder(modelBuilder);
            PersonFeedModelBuilder.Builder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}