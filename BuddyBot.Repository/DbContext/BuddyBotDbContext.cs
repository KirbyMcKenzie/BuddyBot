using System;
using System.Collections.Generic;
using System.Text;
using BuddyBot.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Repository.DbContext
{
    public class BuddyBotDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BuddyBotDbContext(DbContextOptions<BuddyBotDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City").HasKey(_ => _.Id);

            modelBuilder.Entity<WeatherConditionResponse>().ToTable("WeatherConditionResponse").HasKey(_ => _.Id);

            modelBuilder.Entity<WeatherConditionResponse>().HasData(new WeatherConditionResponse
            {
                Id = 200,
                Condition = "Rain",
                Group = "Thunda",
                MappedConditionResponse = "Rain "
            });


            modelBuilder.Entity<Coordinate>()
            .HasKey(_ => new { _.Latitude, _.Longitude });

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherConditionResponse> WeatherConditionResponses{ get; set; }
    }
}
