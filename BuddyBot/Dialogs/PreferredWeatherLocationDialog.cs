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
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BuddyBot.Helpers.Contracts;

namespace BuddyBot.Dialogs
{
    public class PreferredWeatherLocationDialog : IDialog<string>
    {
        private readonly IBotDataService _botDataService;
        private readonly IWeatherService _weatherService;
        private readonly IList<EntityRecommendation> _entities;
        private readonly IMessageHelper _messageHelpers;
        private string _extractedCityFromMessage;

        public PreferredWeatherLocationDialog(IBotDataService botDataService, IWeatherService weatherService,
            IList<EntityRecommendation> entities, IMessageHelper messageHelpers)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _weatherService, nameof(weatherService), weatherService);
            SetField.NotNull(out _messageHelpers, nameof(messageHelpers), messageHelpers);
            _entities = entities;
        }


        /// <summary>
        /// Execution for the <see cref="PreferredWeatherLocationDialog"/> starts here. 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        public Task StartAsync(IDialogContext context)
        {
            City savedPreferredCity= _botDataService.GetPreferredWeatherLocation(context);

            if (_entities != null)
            {
                _extractedCityFromMessage = _messageHelpers.ExtractEntityFromMessage("City.Name", _entities);
            }

             if (!string.IsNullOrWhiteSpace(_extractedCityFromMessage))
            {
                PromptDialog.Confirm(context, ResumeAfterPreferredCityConfirmation, $"So you'd like to change your preferred weather location to {_extractedCityFromMessage}?", $"Sorry I don't understand - try again! So you'd like to change your preferred weather location to {_extractedCityFromMessage}");
                return Task.CompletedTask;
            }

            if (savedPreferredCity != null)
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Your saved weather location is {savedPreferredCity.Name}, {savedPreferredCity.Country}, would you like to change it?", $"Sorry I don't understand - try again! Would you like to change your preferred weather location?");
                return Task.CompletedTask;
            }

            PromptDialog.Text(context, ResumeAfterPromptForPreferredLocation, "What's the name of your preferred weather location?", "Sorry I didn't get that - try again! What's the name of your preferred weather location?");
            return Task.CompletedTask;

        }


        /// <summary>
        /// Called when LUIS picks up a preferred weather location entity from the users utterance and 
        /// confirms if they'd like to update their location to the given entity.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The result of the users confirmation. </param>
        private async Task ResumeAfterPreferredCityConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    await ResumeAfterPromptForPreferredLocation(context, new AwaitableFromItem<string>(_extractedCityFromMessage));
                    break;
                default:
                    context.Done(_botDataService.GetPreferredWeatherLocation(context).Name);
                    break;
            }
        }


        /// <summary>
        /// Called after the user has entered in the name of their preferred weather location. 
        /// Searches for cities with that name.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The name of the city the user wnats to update as their preferred weather location. </param>
        private async Task ResumeAfterPromptForPreferredLocation(IDialogContext context, IAwaitable<string> result)
        {
            string cityName = await result;

            IList<City> citySearchResults = await _weatherService.SearchForCities(cityName, null, null);

            if (citySearchResults != null && citySearchResults.Count <= 0)
            {
                context.Done($"I'm sorry, I couldn't find any results for '{cityName}'. " +
                             $"Make sure you've spelt everything correctly and try again 😊");
            }
            else if (citySearchResults != null && citySearchResults.Count >= 2)
            {

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


        /// <summary>
        /// Called after the user has entered in the name of their preferred weather location. 
        /// Searches for cities with that name.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The name of the city the user wants to update as their preferred weather location. </param>
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            IMessageActivity cityChoice = await result;

            WeatherHelper weatherHelper = new WeatherHelper();
            City extractedCity = weatherHelper.ExtractCityFromMessagePrompt(cityChoice.Text);

            _botDataService.setPreferredWeatherLocation(context, extractedCity);

            context.Done(extractedCity.Name);
        }


        /// <summary>
        /// Called after the user has selected their preferred weather location from the <see cref="CardAction"/> list. 
        /// Confirms if they would like to set that city as their preferred weather location.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory.  The result of the users confirmation.</param>
        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    PromptDialog.Text(context, ResumeAfterPromptForPreferredLocation, "What's the name of the city you'd like the weather for?", "Sorry I didn't get that - try again! What's the name of your preferred weather location?");
                    break;
                default:
                    context.Done(_botDataService.GetPreferredWeatherLocation(context).Name);
                    break;
            }
        }


        /// <summary>
        /// Creates a carousel of <see cref="CardAction"/>'s for the user to select a city to get the weather of. 
        /// </summary>
        /// <param name="cityResultList">Mandatory. The list of cities for the user to select from.</param>
        private List<CardAction> CreateCardActionList(IList<City> cityResultList)
        {
            List<CardAction> cardOptionsList = new List<CardAction>();

            foreach (var city in cityResultList)
            {
                cardOptionsList.Add(new CardAction(ActionTypes.ImBack,
                    title: $"{city.Name}, {city.Country}",
                    value: $"{city.Name}, {city.Country}, (#{city.Id})"));
            }
            return cardOptionsList;
        }
    }
}