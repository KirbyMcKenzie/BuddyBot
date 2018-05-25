using System.Threading.Tasks;

namespace BuddyBot.Contracts
{
    public interface IWeatherService 
    {
        Task<string> GetWeatherByLocationId(string locationId);


    }
}