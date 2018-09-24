using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    public class PreferredWeatherLocationDialog : IDialog<string>
    {
        private string _preferredLocationFromMessage;
        private readonly IBotDataService _botDataService;
        private readonly IList<EntityRecommendation> _entities;

        public PreferredWeatherLocationDialog(IBotDataService botDataService, IList<EntityRecommendation> entities)
        {
            _botDataService = botDataService;
            _entities = entities;
        }

        public Task StartAsync(IDialogContext context)
        {
            //_preferredLocationFromMessage = MessageHelpers.ExtractEntityFromMessage("City.Name", _entities);
            City savedPreferredCity= _botDataService.GetPreferredWeatherLocation(context);

            //if (!string.IsNullOrWhiteSpace(_preferredLocationFromMessage))
            //{
            //    PromptDialog.Confirm(context, ResumeAfterPreferredCityConfirmation, $"So you'd like to change your preferred weather location to {_preferredLocationFromMessage}?", $"Sorry I don't understand - try again! So you'd like to change your preferred weather location to {_preferredLocationFromMessage}");
            //    return Task.CompletedTask;
            //}

            //if (!string.IsNullOrWhiteSpace(savedPreferredCity.Name))
            //{
            //    PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Your saved weather location is {savedPreferredCity.Name}, would you like to change it?", $"Sorry I don't understand - try again! Where is your preferred weather location?");
            //    return Task.CompletedTask;
            //}

            PromptDialog.Text(context, ResumeAfterPromptForPreferredLocation, "What's the name of the city you'd like the weather for?", "Sorry I didn't get that - try again! What should I call you?");
            return Task.CompletedTask;

        }

        private async Task ResumeAfterPreferredCityConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            City city = new City()
            {
                Id = "453453",
                Name = "Dunedin",
                Country = "New Zealand"
            };

            _botDataService.setPreferredWeatherLocation(context, city);
            context.Done(city);

            await Task.Yield();
        }

        private async Task ResumeAfterPromptForPreferredLocation(IDialogContext context, IAwaitable<string> result)
        {
            string cityName = await result;

            IList<City> citySearchResults = MessageHelpers.SearchForCities(cityName);

            if (citySearchResults != null && citySearchResults.Count <= 0)
            {
                context.Done($"I'm sorry, I couldn't find any results for '{cityName}'. " +
                             $"Make sure you've spelt everything correctly and try again 😊");
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
                context.Wait(this.MessageReceivedAsync);
            }

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            IMessageActivity cityId = await result;

            City preferredCity = MessageHelpers.GetCityById(cityId.Text);

            _botDataService.setPreferredWeatherLocation(context, preferredCity);

            context.Done(preferredCity.Name);
        }

        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    context.Done(_botDataService.GetPreferredWeatherLocation(context));
                    break;
                default:
                    PromptDialog.Text(context, ResumeAfterPromptForPreferredLocation, "Okay, what should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                    break;
            }
        }

        // TODO - Move to helpers
        private List<CardAction> CreateCardActionList(IList<City> cityResultList)
        {
            List<CardAction> cardOptionsList = new List<CardAction>();

            foreach (var city in cityResultList)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Id}"));

            }

            return cardOptionsList;
        }
    }
}