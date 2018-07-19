using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Repository.Models;

namespace BuddyBot.Repository.DataAccess.Contracts
{
    public interface IWeatherConditionResponseReader
    {
        Task<WeatherConditionResponse> GetResponseByCondition(string condition);
    }
}
