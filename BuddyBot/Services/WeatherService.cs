using BuddyBot.Models.Dtos;

using Microsoft.Bot.Builder.Luis.Models;
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
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using BuddyBot.Helpers;

namespace BuddyBot.Services
{
    public class WeatherService : IWeatherService
    {

        private readonly string _baseUrl = ConfigurationManager.AppSettings["openWeatherMap:url"];
        private readonly string _apiKey = ConfigurationManager.AppSettings["openWeatherMap:apiKey"];

        public IList<City> SearchForCities(string cityName, string countryCode = null, string countryName = null)
        {
            IList<City> cityList = new List<City>();

            if (countryName != null)
            {
                countryCode = GlobalizationHelpers.GetCountryCode(countryName);
            }

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

                    if(countryCode != null)
                    {
                        if (itemTitle.Contains(cityName) && itemCountry.Contains(countryCode))
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
                    else if (itemTitle.Contains(cityName))
                    {
                        City city = new City()
                        {
                            Id = itemId,
                            Name = itemTitle,
                            Country = itemCountry,
                        };

                        cityList.Add(city);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return cityList;
        }

        // TODO - Clean up this method
    public async Task<string> GetWeather(City city)
        {
            string requestUri = $"{_baseUrl}{city.Name},{city.Country}&appid={_apiKey}";

            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(requestUri) };
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    String weatherString = await response.Content.ReadAsStringAsync();

                    JObject parsedString = JObject.Parse(weatherString);

                    JToken weatherJsonResult = parsedString["weather"].FirstOrDefault();
                    JToken mainJsonResult = parsedString["main"].Last().Parent;

                    // TODO - Find out the different weaterh responses and map to nice descriptions
                    // TODO - Get the temp
                    //if (weatherJsonResult != null)
                    //{
                    //    WeatherDto weatherResult = weatherJsonResult.ToObject<WeatherDto>();

                    //    return weatherResult.description;
                    //}

                    if (mainJsonResult != null)
                    {
                        MainWeatherDto mainWeatherResult = mainJsonResult.ToObject<MainWeatherDto>();

                        return mainWeatherResult.temp.ToString();
                    }
                }

                return "I'm having problems accessing weather reports. Please try again later";
            }
            catch (Exception ex)
            {

                return "I'm having problems accessing weather reports. Please try again later";
            }
        }

        // TODO - Consider moving to helper/utility class
        public City ExtractCityFromMessagePrompt(string messagePrompt)
        {
            var cityName = messagePrompt.Substring(0, messagePrompt.IndexOf(','));
            var cityCountry = messagePrompt.Substring(messagePrompt.IndexOf(',') + 2);

            City city = new City()
            {
                Name = cityName,
                Country = cityCountry
            };

            return city;
        }
    }
}