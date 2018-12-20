using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models.Dtos;

namespace BuddyBot.Models.Mappers
{
    public class CityMap : IDomainMapper<WeatherSearchResultDto, IList<City>>
    {
        public IList<City> MapTo(WeatherSearchResultDto mapFrom)
        {
            IList<City> cityList = new List<City>();

            foreach (var searchResult in mapFrom.SearchResultList)
            {
                cityList.Add(new City
                {
                    Id = searchResult.Id.ToString(),
                    Name = searchResult.Name,
                    Country = searchResult.Sys.Country
                });
            }
            return cityList;   
        }
    }
}