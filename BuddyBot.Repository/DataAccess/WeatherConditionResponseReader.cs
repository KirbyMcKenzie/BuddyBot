using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.DbContext;
using BuddyBot.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Repository.DataAccess
{
    public class WeatherConditionResponseReader :  BaseRepository, IWeatherConditionResponseReader
    {
        public WeatherConditionResponseReader(BuddyBotDbContext context) : base (context)
        {
        }

        public async Task<WeatherConditionResponse> GetResponseByCondition(string condition)
        {
            WeatherConditionResponse responseResult = await _context.WeatherConditionResponses
                .Where(r => r.Condition == condition).FirstOrDefaultAsync();

            return responseResult;
        }
    }
}
