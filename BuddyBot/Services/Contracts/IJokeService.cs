using System;
using System.Threading.Tasks;

namespace BuddyBot.Services.Contracts
{
    public interface IJokeService
    {
        Task<String> GetRandomJoke();
    }
}