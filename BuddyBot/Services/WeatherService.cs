using BuddyBot.Models.Dtos;

using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;

namespace BuddyBot.Services
{
    public class WeatherService : IWeatherService
    {

        private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
        private readonly string _apiKey = ConfigurationManager.AppSettings["openWeatherMap:_apiKey"];


        // TODO - Could turn this into a utility method
        public string GetCityFromEntityResults(IList<EntityRecommendation> entities)
        {

            if (entities.Count > 0 && entities.Count <= 1)
            {
                foreach (var entity in entities.Where(e => e.Type == "Weather.Location"))
                {
                    var entityResult = entity.Entity;

                    TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;
                    var entityUpperResult = cultureInfo.ToTitleCase(entityResult);

                    return entityUpperResult;

                }
            }

            return "Please specify one city to get weather from";

        }

        public IList<City> SearchForCitiesByName(string cityName, string countryCode = null)
        {

            IList<City> cityList = new List<City>();

            try
            {
                string json =
                    File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("/city.list.json")
                    ?? throw new InvalidOperationException());

                IList<JObject> products = JsonConvert.DeserializeObject<List<JObject>>(json);

                for (int i = 0; i < products.Count; i++)
                {
                    string itemId = (string)products[i]["id"];
                    string itemTitle = (string)products[i]["name"];
                    string itemCountry = (string)products[i]["country"];

                    if (itemTitle.Contains(cityName))
                    {
                        City cityInformation = new City()
                        {
                            Id = itemId,
                            Name = itemTitle,
                            Country = itemCountry,
                        };

                        cityList.Add(cityInformation);
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return cityList;
        }

    public async Task<string> GetWeather(City city)
        {
            string url = $"{BaseUrl}{city.Name},{city.Country}&appid={_apiKey}";

            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(url) };
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    String weatherString = await response.Content.ReadAsStringAsync();

                    JObject parsedString = JObject.Parse(weatherString);

                    IList<JToken> results = parsedString["weather"].Children().ToList();

                    IList<WeatherDto> weatherDtos = new List<WeatherDto>();

                    foreach (JToken result in results)
                    {
                        // JToken.ToObject is a helper method that uses JsonSerializer internally
                        WeatherDto weatherDto = result.ToObject<WeatherDto>();
                        weatherDtos.Add(weatherDto);
                    }

                    var first = weatherDtos.FirstOrDefault();

                    return $"Weather in {city.Name}: {first.description}";
                }

                return "I'm having problems accessing weather reports. Please try again later";
            }
            catch (Exception ex)
            {
                return "I'm having problems accessing weather reports. Please try again later";
            }
        }

        public City ExtractCityFromMessagePrompt(string messagePrompt)
        {
            var spacePosition = messagePrompt.IndexOf(' ');

            var cityName = messagePrompt.Substring(0, spacePosition - 1);
            var cityCountry = messagePrompt.Substring(messagePrompt.IndexOf(' ') + 1);

            City city = new City()
            {
                Name = cityName,
                Country = cityCountry
            };
            

            return city;

        }
    }
}