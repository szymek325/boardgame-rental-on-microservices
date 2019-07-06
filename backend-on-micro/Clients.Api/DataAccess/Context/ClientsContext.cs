using System;
using Clients.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Api.DataAccess.Context
{
    public class ClientsContext : DbContext
    {
        public ClientsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("c");
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<Client>().Property(x => x.CreationTimeUtc).HasDefaultValue(DateTime.UtcNow);
        }
    }
}