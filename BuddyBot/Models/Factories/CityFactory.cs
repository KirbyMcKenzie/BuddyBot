using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models.Dtos;

namespace BuddyBot.Models.Factories
{
    public class CityFactory: ICityFactory
    {
        public City ConvertFromDto(string type)
        {
            switch (type)
            {
                case nameof(WeatherSearchResultDto):
                    return new City();
                default:
                    throw new ArgumentException("Invalid type", nameof(type));
            }
        }
    }
}