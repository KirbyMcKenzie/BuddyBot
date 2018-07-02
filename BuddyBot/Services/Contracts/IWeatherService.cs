using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Services.Contracts
{
    public interface IWeatherService 
    {
        string GetCityFromEntityResults(IList<EntityRecommendation> entities);

        IList<City> SearchForCitiesByName(string cityName, string countryCode = null);

        Task<string> GetWeather(City city);

        City ExtractCityFromMessagePrompt(string message);

    }
}