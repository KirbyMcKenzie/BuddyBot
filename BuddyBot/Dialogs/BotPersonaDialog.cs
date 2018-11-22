using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Models.Enums;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Dialogs
{
    public class BotPersonaDialog: IDialog<string>
    {
        private readonly IBotDataService _botDataService;
        private readonly IList<EntityRecommendation> _entities;
        private PersonalityChatPersona _preferredBotPersona;
        private PersonalityChatPersona _heroCardSelectionPersona;

        public BotPersonaDialog(IBotDataService botDataService, IList<EntityRecommendation> entities, 
            PersonalityChatPersona heroCardSelectionPersona)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            _entities = entities;
            _heroCardSelectionPersona = heroCardSelectionPersona;
        }

        public Task StartAsync(IDialogContext context)
        {
            PersonalityChatPersona persona;

            // If called from another dialog with chosen personality
            if (_heroCardSelectionPersona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterHeroCardChoiceConfirmation, $"So you'd like me to change my personality to {_heroCardSelectionPersona}?", $"Sorry I don't understand - try again! Should I change my personality to {_heroCardSelectionPersona}?");
                return Task.CompletedTask;
            }
            // Else we can assume LUIS called the dialog
            else
            {
                persona = _botDataService.GetPreferredBotPersona(context);

                if (_entities != null)
                {
                    Enum.TryParse(MessageHelpers.ExtractEntityFromMessage("User.PreferredBotPersona", _entities), out PersonalityChatPersona parsedResult);
                    _preferredBotPersona = parsedResult;
                }
            }


            if (_preferredBotPersona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterPreferredPersonaConfirmation, $"So you'd like me to change my personality to {_preferredBotPersona}?", $"Sorry I don't understand - try again! Should I change my personality to {_preferredBotPersona}?");
                return Task.CompletedTask;
            }

            if (persona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"My persona is set to {persona}. Would you like to change it?", $"Sorry I don't understand - try again! Would you like to change my persona?");
                return Task.CompletedTask;
            }

            // Could not determine preferred personality
            // prompt user to pick
            PromptDialog.Choice(context, ResumeAfterPersonaFilled,Enum.GetValues(typeof(PersonalityChatPersona)).Cast<PersonalityChatPersona>(),
                        "What would you like my personality to be?");
            return Task.CompletedTask;
        }

        private async Task ResumeAfterHeroCardChoiceConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.SetPreferredBotPersona(context, _heroCardSelectionPersona);
                    context.Done(_heroCardSelectionPersona.ToString());
                    break;
                default:
                    PromptDialog.Choice(context, ResumeAfterPersonaFilled,
                       Enum.GetValues(typeof(PersonalityChatPersona)).Cast<PersonalityChatPersona>(),
                       "What would you like my personality to be?");
                    break;
            }
        }

        private async Task ResumeAfterPreferredPersonaConfirmation(IDialogContext context, IAwaitable<bool> result)
        {

            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.SetPreferredBotPersona(context, _preferredBotPersona);
                    context.Done(_preferredBotPersona.ToString());
                    break;
                default:
                    PromptDialog.Choice(context, ResumeAfterPersonaFilled,
                       Enum.GetValues(typeof(PersonalityChatPersona)).Cast<PersonalityChatPersona>(),
                       "What would you like my personality to be?");
                    break;
            }
           
        }

        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    PromptDialog.Choice(context, ResumeAfterPersonaFilled,
                        Enum.GetValues(typeof(PersonalityChatPersona)).Cast<PersonalityChatPersona>(),
                        "What would you like my personality to be?");
                    break;
                default:
                    context.Done(_botDataService.GetPreferredBotPersona(context).ToString());
                    break;
            }
        }

        private async Task ResumeAfterPersonaFilled(IDialogContext context, IAwaitable<PersonalityChatPersona> result)
        {
            PersonalityChatPersona filledPersona = await result;

            _botDataService.SetPreferredBotPersona(context, filledPersona);
            context.Done(filledPersona.ToString());
        }
       
    }
}