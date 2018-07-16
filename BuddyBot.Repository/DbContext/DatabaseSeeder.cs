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
                },
                new WeatherConditionResponse()
                {
                    Id = 202,
                    Condition = "thunderstorm with heavy rain",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "thunderstorm with heavy rain"
                },
                new WeatherConditionResponse()
                {
                    Id = 210,
                    Condition = "light thunderstorm",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "light thunderstorm"
                },
                new WeatherConditionResponse()
                {
                    Id = 211,
                    Condition = "thunderstorm",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "thunderstorm"
                },
                new WeatherConditionResponse()
                {
                    Id = 212,
                    Condition = "heavy thunderstorm",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "heavy thunderstorm"
                },
                new WeatherConditionResponse()
                {
                    Id = 221,
                    Condition = "ragged thunderstorm",
                    Group = "Thunderstorm",
                    MappedConditionResponse = "ragged thunderstorm"
                },
                new WeatherConditionResponse()
                {
                    Id = 230,
                    Condition = "",
                    Group = "",
                    MappedConditionResponse = ""
                },
                new WeatherConditionResponse()
                {
                    Id = 231,
                    Condition = "",
                    Group = "",
                    MappedConditionResponse = ""
                },
                new WeatherConditionResponse()
                {
                    Id = 323,
                    Condition = "",
                    Group = "",
                    MappedConditionResponse = ""
                },
                new WeatherConditionResponse()
                {
                    Id = 0,
                    Condition = "",
                    Group = "",
                    MappedConditionResponse = ""
                },
            };

            return weatherConditionResponseList;
        }
    }
}
