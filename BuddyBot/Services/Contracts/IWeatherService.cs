using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Services.Contracts
{
    public interface IWeatherService 
    {
        string GetCityFromEntityResults(IList<EntityRecommendation> entities);

        City GetDetailedCityInformation(string cityName, string countryCode = null);

        Task<string> GetWeatherByCityInformation(City city);

        Task<string> GetWeather(string messageText);
    }
}