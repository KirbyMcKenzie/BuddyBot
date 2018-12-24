using System;
using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BuddyBot.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BuddyBot.Helpers
{
    public static class MessageHelpers
    {
        public static IList<int> ExtractIntegersFromMessage(string message)
        {
            string[] values = Regex.Split(message, @"\D+");
            IList<int> integersList = new List<int>();

            foreach (var value in values)
            {
                int.TryParse(value, out var number);
                integersList.Add(number);
            }

            return integersList;
        }

        /// <summary>
        /// Extracts Luis Entities from user input and converts them to string
        /// </summary>
        /// <param name="entityToExtract">Mandatory. The name of the Entity to extract.</param>
        /// <param name="entities">Mandatory. List of Luis Entities from user input</param>
        /// <param name="TextCaseType">Optional. String output casing. E.g. "TitleCase", "Uppercase"</param>
        /// <returns></returns>
        public static string ExtractEntityFromMessage(string entityToExtract, IList<EntityRecommendation> entities, TextCaseType TextCaseType = TextCaseType.TitleCase)
        {

                foreach (var entity in entities.Where(e => e.Type == entityToExtract))
                {
                    string entityResult = entity.Entity;
                    string entityString;

                    TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;

                switch (TextCaseType)
                {

                    case TextCaseType.UpperCase:
                        entityString = cultureInfo.ToUpper(entityResult);
                        break;
                    case TextCaseType.LowerCase:
                         entityString = cultureInfo.ToTitleCase(entityResult);
                        break;
                    default:
                        entityString = cultureInfo.ToTitleCase(entityResult);
                        break;
                }
                    return entityString;
                }

            return null;
        }


        // TODO Amend to process ID or not
        public static City ExtractCityFromMessagePrompt(string messagePrompt)
        {

            // TODO - use string .split here
            var cityName = messagePrompt.Substring(0, messagePrompt.IndexOf(','));
            var cityCountry = messagePrompt.Substring(messagePrompt.IndexOf(',') + 2, 2);
            var cityId = messagePrompt.Substring(messagePrompt.IndexOf('#') +1, 7);

            City city = new City()
            {
                Name = cityName,
                Country = cityCountry,
                Id = cityId
            };

            return city;
        }

        public static IList<City> SearchForCities(string cityName, string countryCode = null, string countryName = null)
        {
            IList<City> cityList = new List<City>();

            if (countryName != null)
            {
                countryCode = GlobalizationHelpers.GetCountryCode(countryName);
            }

            //TODO - Add to DB or move to blob storage
            string json =
                File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("/city.list.json")
                                 ?? throw new InvalidOperationException());

            IList<JObject> products = JsonConvert.DeserializeObject<List<JObject>>(json);

            for (int i = 0; i < products.Count; i++)
            {
                string itemId = (string)products[i]["id"];
                string itemTitle = (string)products[i]["name"];
                string itemCountry = (string)products[i]["country"];

                if (countryCode != null)
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
            return cityList;
        }

        public static City GetCityById(string cityId)
        {
            string json =
                File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("/city.list.json")
                                 ?? throw new InvalidOperationException());

            IList<JObject> products = JsonConvert.DeserializeObject<List<JObject>>(json);

            for (int i = 0; i < products.Count; i++)
            {
                string itemId = (string) products[i]["id"];
                string itemTitle = (string) products[i]["name"];
                string itemCountry = (string) products[i]["country"];

                    if (itemId.Contains(cityId))
                    {
                        return new City()
                        {
                            Id = itemId,
                            Name = itemTitle,
                            Country = itemCountry,
                        };
                    }
            }
            return null;
        }

        public static string ExtractIdFromMessage(string messagePrompt)
        {
            return messagePrompt.Substring(messagePrompt.LastIndexOf(',') + 1).Replace(" ", string.Empty);
        }

    }
}
