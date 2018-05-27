using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Contracts
{
    public interface IWeatherService 
    {
        Task<string> GetWeatherByLocationId(string locationId);
       
    }
}