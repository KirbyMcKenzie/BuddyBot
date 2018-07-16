using System;
using System.Collections.Generic;
using System.Text;
using BuddyBot.Repository.Models;

namespace BuddyBot.Repository.DbContext
{
    public class DatabaseSeeder
    {
        public WeatherConditionResponse[] GetWeatherConditionResponses()
        {
            WeatherConditionResponse[] weatherConditionResponseList = 
            {
                new WeatherConditionResponse()
                {
                    Id = 200,
                    Condition = "thunderstorm with light rain",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "thunderstorm with light rain"
                },
                new WeatherConditionResponse()
                {
                    Id = 201,
                    Condition = "thunderstorm with rain",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "thunderstorm with rain"
                }
            };

            return weatherConditionResponseList;
        }
    }
}
