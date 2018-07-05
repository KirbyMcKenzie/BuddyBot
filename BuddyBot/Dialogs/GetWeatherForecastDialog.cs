using BuddyBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Connector;

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
            // TODO - Rename entity name in luis
            string cityName = _weatherService.ExtractEntityFromMessage("Weather.Location", _entities);

            IList<City> cityResultList = _weatherService.SearchForCitiesByName(cityName);

            List<CardAction> cardOptionsList = new List<CardAction>();


            foreach (var city in cityResultList)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Name}, {city.Country}"));
            };

            if (cardOptionsList.Count <= 0)
            {
                context.Done($"I'm sorry, I couldn't find any results for '{cityName}'. Make sure everything is spelt correctly and try again 😊");

                return;
            }

            // TODO - Change type of card
            // TODO - Think about limiting amount of cards displayed, see more button? 
            HeroCard card = new HeroCard
            {
                Title = $"I found {cityResultList.Count} results for '{cityResultList.FirstOrDefault()?.Name}'",
                Subtitle = "please select your closest location",
                Buttons = cardOptionsList
            };

            var message = context.MakeMessage();
            message.Attachments.Add(card.ToAttachment());
            await context.PostAsync(message);

            context.Wait(this.MessageReceivedAsync);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            City city =  _weatherService.ExtractCityFromMessagePrompt(message.Text);

            var weatherForecast = await _weatherService.GetWeather(city);

            context.Done($"The weather in {message.Text} right now is {weatherForecast}");
        }
    }
}
