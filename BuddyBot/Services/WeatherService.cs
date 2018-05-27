using BuddyBot.Contracts;
using BuddyBot.Models.Dtos;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuddyBot.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IList<EntityRecommendation> _entities;

        public WeatherService(IList<EntityRecommendation> entities)
        {
            _entities = entities;
        }

        // TODO - Replace key
        private const string baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
        private string apiKey = ConfigurationManager.AppSettings["openWeatherMap:apiKey"];

        // TODO - Tidy this method up
        public async Task<string> GetWeatherByLocationId(string locationId)
        {

            string entityResult = null;

            if (_entities.Count > 0 && _entities.Count <= 1)
            {
                foreach (var entity in _entities.Where(e => e.Type == "Weather.Location"))
                {
                    entityResult = entity.Entity;
                }
            }
            else
            {
                return "I can only check the weather for 1 location at a time.";
            }


        string url = baseUrl + entityResult + ",nz&appid=" + apiKey;

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

                    return $"Weather in {entityResult}: {first.description}";
                }
                return "I'm having problems accessing weather reports. Please try again later";
            }
            catch (Exception ex)
            {
                return "I'm having problems accessing weather reports. Please try again later";
            }
        }
    }
}