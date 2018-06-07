using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Contracts;

namespace BuddyBot.Services
{
    public class GreetingService : IGreetingService
    {
        public async Task GetRandomGreeting()
        {
            await Task.Yield();
        }

    }
}