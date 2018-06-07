using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuddyBot.Contracts
{
    public interface IGreetingService
    {
        Task<string> GetRandomGreeting();

    }
}