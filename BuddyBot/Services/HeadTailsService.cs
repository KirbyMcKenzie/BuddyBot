using System;
using System.Threading.Tasks;
using BuddyBot.Contracts;

namespace BuddyBot.Services
{
    public class HeadTailsService : IHeadTailsService
    {
        public Task<string> GetRandomHeadsTails()
        {
            Random random = new Random();

            int result = random.Next(0, 2);

            switch (result)
            {
                case 1:
                    return Task.FromResult("Heads");
                default:
                    return Task.FromResult("Tails");
            }

        }
    }
}