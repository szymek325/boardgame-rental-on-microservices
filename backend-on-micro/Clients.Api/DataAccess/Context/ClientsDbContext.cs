using System;
using Clients.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Api.DataAccess.Context
{
    public class ClientsDbContext : DbContext
    {
        public ClientsDbContext(DbContextOptions options) : base(options)
        {
            base.Database.Migrate();
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().Property(x => x.CreationTimeUtc).HasDefaultValue(DateTime.UtcNow);
        }
    }
}