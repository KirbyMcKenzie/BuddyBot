using BuddyBot.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuddyBot.Services
{
    public class WeatherService : IWeatherService
    {

        public async Task<string> GetWeatherByLocationId(string locationId)
        {

            return "Pretty cold at the mo jo";
        }
    }
}