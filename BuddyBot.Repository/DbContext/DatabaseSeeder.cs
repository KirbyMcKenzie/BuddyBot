using BuddyBot.Repository.Models;
using System;

namespace BuddyBot.Repository.DbContext
{
    public class DatabaseSeeder
    {
        public WeatherConditionResponse[] BuildWeatherConditionResponses()
        {
            WeatherConditionResponse[] weatherConditionResponseList =
            {
                // Group 2xx: Thunderstorm
                BuildWeatherConditionReport(200,"thunderstorm with light rain","Thunderstorm","thunderstorm with light rain"),
                BuildWeatherConditionReport(201,"thunderstorm with rain","Thunderstorm","thunderstorm with rain"),
                BuildWeatherConditionReport(202,"thunderstorm with heavy rain","Thunderstorm","thunderstorm with heavy rain"),
                BuildWeatherConditionReport(210,"light thunderstorm","Thunderstorm","light thunderstorm"),
                BuildWeatherConditionReport(211,"thunderstorm","Thunderstorm","thunderstorm"),
                BuildWeatherConditionReport(212,"heavy thunderstorm","Thunderstorm","heavy thunderstorm"),
                BuildWeatherConditionReport(221,"ragged thunderstorm","Thunderstorm","ragged thunderstorm"),
                BuildWeatherConditionReport(230,"thunderstorm with light drizzle","Thunderstorm","thunderstorm with light drizzle"),
                BuildWeatherConditionReport(231,"thunderstorm with drizzle","Thunderstorm","thunderstorm with drizzle"),
                BuildWeatherConditionReport(232,"thunderstorm with heavy drizzle","Thunderstorm","thunderstorm with heavy drizzle"),
                //Group 3xx: Drizzle
                BuildWeatherConditionReport(300,"light intensity drizzle","Drizzle","light intensity drizzle"),
                BuildWeatherConditionReport(301,"drizzle","Drizzle","drizzle"),
                BuildWeatherConditionReport(302,"heavy intensity drizzle","Drizzle","heavy intensity drizzle"),
                BuildWeatherConditionReport(310,"light intensity drizzle rain","Drizzle","light intensity drizzle rain"),
                BuildWeatherConditionReport(311,"drizzle rain","Drizzle","drizzle rain"),
                BuildWeatherConditionReport(312,"heavy intensity drizzle rain","Drizzle","heavy intensity drizzle rain"),
                BuildWeatherConditionReport(313,"shower rain and drizzle","Drizzle","shower rain and drizzle"),
                // TODO - finish this off
            };

            return weatherConditionResponseList;
        }

        private WeatherConditionResponse BuildWeatherConditionReport(int id, string condition, string group, string response)
        {
            return new WeatherConditionResponse()
            {
                Id = id,
                Condition = condition,
                Group = group,
                 MappedConditionResponse = response
            };
        }
    }
}