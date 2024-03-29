﻿using BuddyBot.Extensions;
using BuddyBot.Helpers;
using BuddyBot.Models;
using BuddyBot.Models.Dtos;
using BuddyBot.Models.Enums;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Services.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BuddyBot.Models.Mappers;

namespace BuddyBot.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherConditionResponseReader _weatherConditionResponseReader;

        private readonly string _weatherBaseUrl = ConfigurationManager.AppSettings["openWeatherMap:weatherUrl"];
        private readonly string _serachBaseUrl = ConfigurationManager.AppSettings["openWeatherMap:searchUrl"];
        private readonly string _weatherApiKey = ConfigurationManager.AppSettings["openWeatherMap:weatherApiKey"];
        private readonly string _searchApiKey = ConfigurationManager.AppSettings["openWeatherMap:searchApiKey"];

        public WeatherService(IWeatherConditionResponseReader weatherConditionResponseReader)
        {
            _weatherConditionResponseReader = weatherConditionResponseReader;
        }

        /// <summary>
        /// Gets the current weather forecast for a given City.
        /// </summary>
        /// <param name="city">Mandatory. City to get the current weather for.</param>
        public async Task<string> GetWeather(City city)
        {
            string requestUri = $"{_weatherBaseUrl}{city.Name},{city.Country}&appid={_weatherApiKey}";

            HttpClient client = new HttpClient {BaseAddress = new Uri(requestUri)};
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                string responseJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedJsonReponseString = JObject.Parse(responseJsonString);

                JToken weatherDescriptionJsonResult = parsedJsonReponseString["weather"].FirstOrDefault();
                JToken weatherTemperturesJsonResult = parsedJsonReponseString["main"].Last().Parent;

                if (weatherDescriptionJsonResult != null && weatherTemperturesJsonResult != null)
                {
                    WeatherDescriptionDto weatherDescriptionResult =
                        weatherDescriptionJsonResult.ToObject<WeatherDescriptionDto>();

                    WeatherTemperatureDto weatherTemperatureResult =
                        weatherTemperturesJsonResult.ToObject<WeatherTemperatureDto>();

                    WeatherHelper weatherHelper = new WeatherHelper();
                    double convertedTemperture =
                        weatherHelper.ConvertTemperture(weatherTemperatureResult.temp, Temperature.Celsius);

                    var mappedConitionReponse = await _weatherConditionResponseReader
                        .GetResponseByCondition(weatherDescriptionResult.description);

                    if (mappedConitionReponse != null)
                    {
                        return $"{convertedTemperture}{Temperature.Celsius.DisplayName()} " +
                               $"with {mappedConitionReponse.MappedConditionResponse}";
                    }
                }
            }

            return null;
        }

        /// <summary>
        ///  Searches for cities that match the given cityName, countryCode and countyName, 
        ///  returning a list of matching cities.
        /// </summary>
        /// <param name="cityName">Mandatory. Name of the city to search for.</param>
        /// <param name="countryCode">Optional. Two letter country code for the city to search for.</param>
        /// <param name="countryName">Optional. Name of the country to search for. </param>
        public async Task<IList<City>> SearchForCities(string cityName, string countryCode = null,
            string countryName = null)
        {
            string requestUri = string.Empty;

            if (countryCode == null && countryName != null)
            {
                GlobalizationHelper globalizationHelper = new GlobalizationHelper();
                countryCode = globalizationHelper.GetCountryCode(countryName);
            }

            if(countryCode != null)
            {
                 requestUri = $"{_serachBaseUrl}{cityName},{countryCode}&type=like&appid={_searchApiKey}";
            }
            else
            {
                 requestUri = $"{_serachBaseUrl}{cityName}&type=like&appid={_searchApiKey}";
            }

            HttpClient client = new HttpClient {BaseAddress = new Uri(requestUri)};
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                string responseJsonString = await response.Content.ReadAsStringAsync();
                WeatherSearchResultDto deserializedProduct = JsonConvert.DeserializeObject<WeatherSearchResultDto>(responseJsonString);

                IDomainMapper<WeatherSearchResultDto,IList<City>> cityMapper = new CityMap();
                IList<City> cityList = cityMapper.MapTo(deserializedProduct);

                return cityList;
            }

            return null;
        }
    }
}