using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Services.Contracts
{
    public interface IWeatherService 
    {
        IList<City> SearchForCities(string cityName, string countryCode = null, string countryName = null);

        Task<string> GetWeather(City city);

        City ExtractCityFromMessagePrompt(string message);

    }
}