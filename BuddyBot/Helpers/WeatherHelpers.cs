using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models.Enums;

namespace BuddyBot.Helpers
{
    public class WeatherHelpers
    {
        public static double ConvertTemperture(double temp, Temperature temperatureToConvert)
        {
            switch (temperatureToConvert)
            {
                case Temperature.Fahrenheit:
                    return Math.Round((temp - 273.15 + 32), 1);
                default:
                    return Math.Round((temp - 273.15), 1);
            }
        }
    }
}