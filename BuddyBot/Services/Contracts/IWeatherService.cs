using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Services.Contracts
{
    public interface IWeatherService 
    {
        string GetCityFromEntityResults(IList<EntityRecommendation> entities);

        IList<City> GetDetailedCityInformation(IList<string> cities);

        Task<string> GetWeatherByCityInformation(City city);

        Task<string> GetWeather(string messageText);
    }
}