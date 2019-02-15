using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Models.Enums;

namespace BuddyBot.Helpers
{
    public class WeatherHelper
    {
        public double ConvertTemperture(double temp, Temperature temperatureToConvert)
        {
            switch (temperatureToConvert)
            {
                case Temperature.Fahrenheit:
                    return Math.Round((temp - 273.15 + 32), 1);
                default:
                    return Math.Round((temp - 273.15), 1);
            }
        }

        public City ExtractCityFromMessagePrompt(string messagePrompt)
        {

            // TODO - use string .split here
            var cityName = messagePrompt.Substring(0, messagePrompt.IndexOf(','));
            var cityCountry = messagePrompt.Substring(messagePrompt.IndexOf(',') + 2, 2);
            var cityId = messagePrompt.Substring(messagePrompt.IndexOf('#') + 1, 7);

            City city = new City()
            {
                Name = cityName,
                Country = cityCountry,
                Id = cityId
            };
            return city;
        }

        public string ExtractIdFromMessage(string messagePrompt)
        {
            return messagePrompt.Substring(messagePrompt.LastIndexOf(',') + 1).Replace(" ", string.Empty);
        }
    }
}