using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BuddyBot.Repository.DbContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<BuddyBotDbContext>
    {
        public BuddyBotDbContext CreateDbContext(string[] args)
        {
            var basePath = Environment.CurrentDirectory;

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var connectionString = config.GetConnectionString("Default");

            var optionsBuilder = new DbContextOptionsBuilder<BuddyBotDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BuddyBotDbContext(optionsBuilder.Options);
        }
    }
}
