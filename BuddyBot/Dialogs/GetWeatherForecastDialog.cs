using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        // TODO - WeatherDialog - Check if pre-saved weather location matches entity city
        // TODO - WeatherDialog - If weather matches entity city, get weather by pre-saved weather id
        // TODO - WeatherDialog - Ask to save preference

        public GetWeatherForecastDialog(
            IWeatherService weatherService,
            IList<EntityRecommendation> entities)
        {
            _weatherService = weatherService;
            _entities = entities;
        }

        public async Task StartAsync(IDialogContext context)
        {
            // TODO - What to do if luis cannot find entities (Get preferred?)
            string cityName = MessageHelpers.ExtractEntityFromMessage("City.Name", _entities);
            string countryCode = MessageHelpers.ExtractEntityFromMessage("City.CountryCode", _entities, TextCaseType.UpperCase);
            string countryName = MessageHelpers.ExtractEntityFromMessage("City.CountryName", _entities);

            IList<City> citySearchResults = _weatherService.SearchForCities(cityName, countryCode, countryName);

            if (citySearchResults != null && citySearchResults.Count <= 0)
            {

                context.Done($"I'm sorry, I couldn't find any results for '{cityName}'. " +
                             $"Make sure you've spelt everything correctly and try again 😊");

            } else if (citySearchResults.Count == 1)
            {

                var weatherForecast = await _weatherService.GetWeather(citySearchResults.FirstOrDefault());
                context.Done($"The weather in {cityName} right now is {weatherForecast}");

            } else if (citySearchResults.Count >= 2)
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

                context.Wait(this.MessageReceivedAsync);

            }
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            City city =  _weatherService.ExtractCityFromMessagePrompt(message.Text);

            var weatherForecast = await _weatherService.GetWeather(city);

            context.Done($"Currently the weather in {message.Text} is {weatherForecast}");
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
