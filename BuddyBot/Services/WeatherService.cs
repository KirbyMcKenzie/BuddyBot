using BuddyBot.Extensions;
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

        public async Task<string> GetWeather(City city)
        {
            string requestUri = $"{_weatherBaseUrl}{city.Name},{city.Country}&appid={_weatherApiKey}";

            HttpClient client = new HttpClient {BaseAddress = new Uri(requestUri)};
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                String responseJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedJsonReponseString = JObject.Parse(responseJsonString);

                JToken weatherDescriptionJsonResult = parsedJsonReponseString["weather"].FirstOrDefault();
                JToken weatherTemperturesJsonResult = parsedJsonReponseString["main"].Last().Parent;

                if (weatherDescriptionJsonResult != null && weatherTemperturesJsonResult != null)
                {
                    WeatherDescriptionDto weatherDescriptionResult =
                        weatherDescriptionJsonResult.ToObject<WeatherDescriptionDto>();
                    WeatherTemperatureDto weatherTemperatureResult =
                        weatherTemperturesJsonResult.ToObject<WeatherTemperatureDto>();

                    // TODO - Convert temperture using entity e.g. "Weather in Auckland in fahrenheit"

                    double convertedTemperture =
                        WeatherHelpers.ConvertTemperture(weatherTemperatureResult.temp, Temperature.Celsius);

                    var mappedConitionReponse = await _weatherConditionResponseReader
                        .GetResponseByCondition(weatherDescriptionResult.description);

                    // TODO - map temp to icon
                    return $"{convertedTemperture}{Temperature.Celsius.DisplayName()} " +
                           $"with {mappedConitionReponse.MappedConditionResponse}";
                }
            }

            // TODO - do something else with this
            return "I'm having problems accessing weather reports. Please try again later";
        }

        public async Task<IList<City>> SearchForCities(string cityName, string countryCode = null,
            string countryName = null)
        {
            IList<City> cityList = new List<City>();
            
            string requestUri = $"{_serachBaseUrl}{cityName}&type=like&appid={_searchApiKey}";

            https://openweathermap.org/data/2.5/find?callback=jQuery19104186607169940981_1544557525540&q=Dunedin&type=like&sort=population&cnt=30&appid=b6907d289e10d714a6e88b30761fae22&_=1544557525542

            HttpClient client = new HttpClient {BaseAddress = new Uri(requestUri)};
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                String responseJsonString = await response.Content.ReadAsStringAsync();
                JObject parsedJsonReponseString = JObject.Parse(responseJsonString);
            }

            return cityList;
        }
    }
}