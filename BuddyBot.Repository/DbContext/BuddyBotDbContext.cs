using System;
using System.Collections;
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
            DatabaseSeeder dbSeeder = new DatabaseSeeder();

            // Build
            modelBuilder.Entity<City>()
                .ToTable("City").HasKey(_ => _.Id);

            modelBuilder.Entity<WeatherConditionResponse>()
                .ToTable("WeatherConditionResponse").HasKey(_ => _.Id);

            modelBuilder.Entity<Coordinate>()
                .HasKey(_ => new { _.Latitude, _.Longitude });

            // Seed
            WeatherConditionResponse[] weatherConditionResponses = dbSeeder.GetWeatherConditionResponses();
            modelBuilder.Entity<WeatherConditionResponse>().HasData(weatherConditionResponses);


        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherConditionResponse> WeatherConditionResponses{ get; set; }
    }
}
