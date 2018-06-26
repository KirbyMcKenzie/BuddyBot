using BuddyBot.Contracts;
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
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class GetWeatherForecastDialog : IDialog<string>
    {
        private readonly IList<EntityRecommendation> _entities;
        private City _city;

        public GetWeatherForecastDialog(IList<EntityRecommendation> entities)
        {
            _entities = entities;
        }

        public async Task StartAsync(IDialogContext context)
        {

            IWeatherService weatherService = new WeatherService();

            var cities = weatherService.GetCitiesFromEntityResults(_entities);

            IList<City> cityInformation = weatherService.GetDetailedCityInformation(cities);

            await context.PostAsync($"I've found {cityInformation.Count} results for {cities.FirstOrDefault()}");

            List<CardAction> cardOptionsList = new List<CardAction>();


            foreach (var city in cityInformation)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Name}, {city.Country}"));
            };

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
            await context.PostAsync("Your answer: " + message);

            context.Done(message.Text);
        }

        // TODO - Move these to helperclass
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
