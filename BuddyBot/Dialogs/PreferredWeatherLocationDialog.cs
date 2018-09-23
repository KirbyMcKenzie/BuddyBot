using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Luis.Models;

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
            _preferredLocationFromMessage = MessageHelpers.ExtractEntityFromMessage("City.Name", _entities);
            City savedPreferredCity= _botDataService.GetPreferredWeatherLocation(context);

            if (!string.IsNullOrWhiteSpace(_preferredLocationFromMessage))
            {
                PromptDialog.Confirm(context, ResumeAfterPreferredCityConfirmation, $"So you'd like to change your preferred weather location to {_preferredLocationFromMessage}?", $"Sorry I don't understand - try again! So you'd like to change your preferred weather location to {_preferredLocationFromMessage}");
                return Task.CompletedTask;
            }

            if (!string.IsNullOrWhiteSpace(savedPreferredCity.Name))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Your saved weather location is {savedPreferredCity.Name}, would you like to change it?", $"Sorry I don't understand - try again! Where is your preferred weather location?");
                return Task.CompletedTask;
            }

            PromptDialog.Text(context, ResumeAfterPreferredLocationPrompt, "What's the name of the city you'd like the weather for?", "Sorry I didn't get that - try again! What should I call you?");
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

        private async Task ResumeAfterPreferredLocationPrompt(IDialogContext context, IAwaitable<string> result)
        {
            string cityName = await result;

            City city = new City()
            {
                Id = "453453",
                Name = "Dunedin",
                Country = "New Zealand"
            };

            _botDataService.setPreferredWeatherLocation(context, city);

            context.Done(cityName);
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
                    PromptDialog.Text(context, ResumeAfterPreferredLocationPrompt, "Okay, what should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                    break;
            }
        }
    }
}