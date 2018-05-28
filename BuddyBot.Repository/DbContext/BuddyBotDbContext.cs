using System;
using System.Collections.Generic;
using System.Text;
using BuddyBot.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Repository.DbContext
{
    class BuddyBotDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BuddyBotDbContext(DbContextOptions<BuddyBotDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("Athlete").HasKey(_ => _.Id);

        }

        public DbSet<City> Athletes { get; set; }
    }
}
