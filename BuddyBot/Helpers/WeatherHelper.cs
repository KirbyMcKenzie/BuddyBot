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
        /// <summary>
        /// Converts given temperture from given temp to given temperture scale E.g. Kelvin to Celius.
        /// </summary>
        /// <param name="temp">The temperture to convert. </param>
        /// <param name="temperatureToConvert">The temperture scale to convert to. </param>
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

        /// <summary>
        /// Extracts the City Information from a Adpative Card message prompt.
        /// </summary>
        /// <param name="messagePrompt">The message prompt the user selected.</param>
        public City ExtractCityFromMessagePrompt(string messagePrompt)
        {
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

        /// <summary>
        /// Extracts the ID from a Adpative Card message prompt
        /// </summary>
        /// <param name="messagePrompt">The message prompt the user selected.</param>
        public string ExtractIdFromMessage(string messagePrompt)
        {
            return messagePrompt.Substring(messagePrompt.LastIndexOf(',') + 1).Replace(" ", string.Empty);
        }
    }
}