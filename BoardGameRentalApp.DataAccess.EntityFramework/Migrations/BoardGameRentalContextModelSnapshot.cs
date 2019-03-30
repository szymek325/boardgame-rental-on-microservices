﻿// <auto-generated />

using System;
using BoardGameRentalApp.DataAccess.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoardGameRentalApp.DataAccess.SqlServer.Migrations
{
    [DbContext(typeof(BoardGameRentalMsSqlContext))]
    partial class BoardGameRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("gr")
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bail");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name");

                    b.Property<float>("PricePerDay");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.GameRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardGameId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<float>("PaymentAmount");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("ClientId");

                    b.ToTable("GameRentals");
                });

            modelBuilder.Entity("BoardGameRentalApp.Core.Entities.GameRental", b =>
                {
                    b.HasOne("BoardGameRentalApp.Core.Entities.BoardGame", "BoardGame")
                        .WithMany("GameRentals")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoardGameRentalApp.Core.Entities.Client", "Client")
                        .WithMany("GameRentals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
