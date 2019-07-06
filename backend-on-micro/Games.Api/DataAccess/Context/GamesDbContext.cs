using System;
using Games.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.DataAccess.Context
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(x => x.Id);
            modelBuilder.Entity<Game>().Property(x => x.CreationTimeUtc).HasDefaultValue(DateTime.UtcNow);
        }
    }
}