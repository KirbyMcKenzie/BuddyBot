using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Connector;
using BuddyBot.Models.Enums;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class GetWeatherForecastDialog : IDialog<string>
    {
        private readonly IWeatherService _weatherService;
        private readonly IList<EntityRecommendation> _entities;
        private readonly IBotDataService _botDataService;

        // TODO - WeatherDialog - Check if pre-saved weather location matches entity city
        // TODO - WeatherDialog - If weather matches entity city, get weather by pre-saved weather id
        // TODO - WeatherDialog - Ask to save preference

        public GetWeatherForecastDialog(
            IWeatherService weatherService,IBotDataService botDataService,
            IList<EntityRecommendation> entities)
        {
            _weatherService = weatherService;
            _entities = entities;
            _botDataService = botDataService;
        }

        public async Task StartAsync(IDialogContext context)
        {
            string cityName = MessageHelpers.ExtractEntityFromMessage("City.Name", _entities);
            string countryCode = MessageHelpers.ExtractEntityFromMessage("City.CountryCode", _entities, TextCaseType.UpperCase);
            string countryName = MessageHelpers.ExtractEntityFromMessage("City.CountryName", _entities);

            City preferredCity = _botDataService.GetPreferredWeatherLocation(context);

            if (string.IsNullOrEmpty(cityName))
            {

                if (preferredCity == null || preferredCity.Name == null)
                {
                    PromptDialog.Text(context, ResumeAfterSpecifyCityNamePrompt, "What's the name of the city you want the forecast for?", "I can't understand you. Tell me the name of the city you want the forecast for");
                    
                }
                else
                {
                    var weatherForecast = await _weatherService.GetWeather(preferredCity);

                    if(weatherForecast != string.Empty)
                    {
                        context.Done($"Currently the weather in {preferredCity.Name} is {weatherForecast}");

                    }
                    else
                    {
                        context.Done("🤧⛅ - I'm having trouble accessing weather reports. We'll have to try again later!");
                    }

                }
            }
            else
            {
                IList<City> citySearchResults = await _weatherService.SearchForCities(cityName, countryCode, countryName);
                await ResumeAfterCitySearch(context, cityName, citySearchResults);
            }
        }

        private async Task ResumeAfterCitySearch(IDialogContext context, string cityName, IList<City> citySearchResults)
        {

            if (citySearchResults != null && citySearchResults.Count <= 0)
            {

                context.Done($"I'm sorry, I couldn't find any results for '{cityName}'. " +
                             $"Make sure you've spelt everything correctly and try again 😊");
            }
            else if (citySearchResults != null && citySearchResults.Count == 1)
            {

                var weatherForecast = await _weatherService.GetWeather(citySearchResults.FirstOrDefault());

                if(weatherForecast != string.Empty)
                {
                    context.Done($"The weather in {cityName} right now is {weatherForecast}");
                }
                else
                {
                    context.Done("🤧⛅ - I'm having trouble accessing weather reports. We'll have to try again later!");
                }

            }
            else if (citySearchResults != null && citySearchResults.Count >= 2)
            {
                // TODO - Change type of card
                // TODO - Think about limiting amount of cards displayed, see more button? 
                List<CardAction> cityCardActionList = CreateCardActionList(citySearchResults);

                HeroCard card = new HeroCard
                {
                    Title = $"I found {citySearchResults.Count} results for '{cityName}'",
                    Subtitle = "please select your closest location",
                    Buttons = cityCardActionList
                };

                var message = context.MakeMessage();
                message.Attachments.Add(card.ToAttachment());

                await context.PostAsync(message);

                context.Wait(this.ResumeAfterHeroCardCitySelect);
            }
        }

        private async Task ResumeAfterSpecifyCityNamePrompt(IDialogContext context, IAwaitable<string> result)
        {
            var cityName = await result;
            cityName = Regex.Replace(cityName, @"[\W_]", string.Empty);

            IList<City> citySearchResults = await _weatherService.SearchForCities(cityName, null, null);

            await  ResumeAfterCitySearch(context, cityName, citySearchResults);
        }

        private async Task ResumeAfterHeroCardCitySelect(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            City city =  MessageHelpers.ExtractCityFromMessagePrompt(message.Text);

            var weatherForecast = await _weatherService.GetWeather(city);

            if(weatherForecast != string.Empty)
            {
                context.Done($"Currently the weather in {message.Text} is {weatherForecast}");
            }
            else
            {
                context.Done("🤧⛅ - I'm having trouble accessing weather reports. We'll have to try again later!");
            }

            
        }

        private List<CardAction> CreateCardActionList(IList<City> cityResultList)
        {
            List<CardAction> cardOptionsList = new List<CardAction>();

            foreach (var city in cityResultList)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Name}, {city.Country}"));
            }

            return cardOptionsList;
        }
    }
}
