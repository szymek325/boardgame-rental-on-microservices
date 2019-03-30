using BoardGameRentalApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameRentalApp.DataAccess.SqlServer.Context
{
    internal class BoardGameRentalMsSqlContext : DbContext
    {
        public BoardGameRentalMsSqlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<GameRental> GameRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("gr");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property(nameof(BaseEntity.CreationTime))
                            .HasDefaultValueSql("getutcdate()");
                    });
        }
    }
}