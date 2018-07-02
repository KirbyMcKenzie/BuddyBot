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
        private City _city;

        // TODO - WeatherDialog - Extract entities from user intent
        // TODO - WeatherDialog - Check if pre-saved weather location matches entity city
        // TODO - WeatherDialog - If weather matches entity city, get weather by pre-saved weather id
        // TODO - WeatherDialog - If new location, scan json file for cities from entity input and prompt user for input
        // TODO - WeatherDialog - User chooses their nearest city preference
        // TODO - WeatherDialog - Extract City name and Country Code from message and query OpenWeatherMap api

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

            var cities = _weatherService.GetCityFromEntityResults(_entities);

            IList<City> cityInformation = _weatherService.SearchForCitiesByName(cities);

            List<CardAction> cardOptionsList = new List<CardAction>();


            foreach (var city in cityInformation)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Name}, {city.Country}"));
            };

            // TODO - Change type of card
            HeroCard card = new HeroCard
            {
                Title = $"I found {cityInformation.Count} results for '{cityInformation.FirstOrDefault()?.Name}'",
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

        // TODO - Move these to helper class
        private static IList<Attachment> GetCardsAttachments()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "Azure Functions",
                    "Process events with a serverless code architecture",
                    new CardAction(ActionTypes.PostBack, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
            };
        }

        private static Attachment GetHeroCard(string title , string text, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Text = text,
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }
    }
}
