using System.Collections.Generic;
using System.Threading.Tasks;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Contracts
{
    public interface IWeatherService 
    {
        Task<string> GetWeatherByLocationId(IList<EntityRecommendation> entities);

        IList<string> GetCitiesFromEntityResults(IList<EntityRecommendation> entities);

        IList<City> GetDetailedCityInformation(IList<string> cities);
    }
}