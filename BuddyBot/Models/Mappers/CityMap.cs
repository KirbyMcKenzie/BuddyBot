using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models.Dtos;

namespace BuddyBot.Models.Mappers
{
    public class CityMap : IDomainMapper<WeatherSearchResultDto, City>
    {
        public City MapTo(WeatherSearchResultDto mapFrom)
        {
            return new City();
        }
    }
}