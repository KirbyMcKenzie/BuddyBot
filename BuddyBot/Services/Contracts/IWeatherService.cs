using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Services.Contracts
{
    public interface IWeatherService 
    {
        IList<string> GetCitiesFromEntityResults(IList<EntityRecommendation> entities);

        IList<City> GetDetailedCityInformation(IList<string> cities);

        Task<string> GetWeatherByCityInformation(City city);
    }
}