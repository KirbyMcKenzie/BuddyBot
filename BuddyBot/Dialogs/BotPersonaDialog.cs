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

        public BotPersonaDialog(IBotDataService botDataService, IList<EntityRecommendation> entities, 
            PersonalityChatPersona preferredBotPersona)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            _entities = entities;
            _preferredBotPersona = preferredBotPersona;
        }

        public Task StartAsync(IDialogContext context)
        {
            /**
             * ----------------------------------------------------
             *  Order of Dialog Flow:
             * ----------------------------------------------------
             * 
             * - Check if there is hero card selection, if yes, 
             *   confirm and finish.
             * 
             * - Check if dialog has entities, extract, confirm and 
             *   finish.
             * 
             * - Check if user has pre-saved persona, prompt to 
             *   update, if yes,prompt options, confirm and finish. 
             *   
             * - Else, prompt user for option, confirm and finish.
             **/

            // Check if there is hero card selection
            if (_preferredBotPersona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmChosenPersona, 
                    $"So you'd to set my personality as {_preferredBotPersona}?", 
                    $"Sorry I don't understand - try again! Should I set my personality to {_preferredBotPersona}?");

                return Task.CompletedTask;
            }
            // Else we can assume LUIS called the dialog
            else
            {
                if (_entities.Count > 0 || _entities != null)
                {
                    Enum.TryParse(MessageHelpers.ExtractEntityFromMessage("User.PreferredBotPersona", _entities),
                        out PersonalityChatPersona parsedResult);

                    _preferredBotPersona = parsedResult;
                }
            }

            // Check If LUIS found entity preference, otherwise continue
            if (_preferredBotPersona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmChosenPersona, 
                    $"So you'd like me to change my personality to {_preferredBotPersona}?",
                    $"Sorry I don't understand - try again! Should I change my personality to {_preferredBotPersona}?");

                return Task.CompletedTask;
            }

            PersonalityChatPersona preSavedPersona = _botDataService.GetPreferredBotPersona(context);
            // Check if user has pre-saved persona, otherwise continue
            if (preSavedPersona != PersonalityChatPersona.None)
            {
                PromptDialog.Confirm(context, ResumeAfterUpdateConfirmation, $"My persona is set to {preSavedPersona}. Would you like to change it?", $"Sorry I don't understand - try again! Would you like to change my persona?");
                return Task.CompletedTask;
            }

            // Could not determine preferred personality prompt user to choose
            PromptDialog.Choice(context, ResumeAfterPromptDialogChoice,
                Enum.GetValues(typeof(PersonalityChatPersona))
                    .Cast<PersonalityChatPersona>()
                    .Where(p => p != PersonalityChatPersona.None),
                    "What would you like my personality to be?");

            return Task.CompletedTask;
        }

        private async Task ResumeAfterConfirmChosenPersona(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.SetPreferredBotPersona(context, _preferredBotPersona);
                    context.Done(_preferredBotPersona.ToString());
                    break;
                default:
                    PromptDialog.Choice(context, ResumeAfterPromptDialogChoice,
                        Enum.GetValues(typeof(PersonalityChatPersona))
                            .Cast<PersonalityChatPersona>()
                            .Where(p => p != PersonalityChatPersona.None),
                        "What would you like my personality to be?");
                    break;
            }
        }

        private async Task ResumeAfterUpdateConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    PromptDialog.Choice(context, ResumeAfterPromptDialogChoice,
                        Enum.GetValues(typeof(PersonalityChatPersona))
                            .Cast<PersonalityChatPersona>()
                            .Where(p => p != PersonalityChatPersona.None),
                        "What would you like my personality to be?");
                    break;
                default:
                    context.Done(_botDataService.GetPreferredBotPersona(context).ToString());
                    break;
            }
        }

        private async Task ResumeAfterPromptDialogChoice(IDialogContext context, IAwaitable<PersonalityChatPersona> result)
        {
            PersonalityChatPersona chosenPersona = await result;

            _botDataService.SetPreferredBotPersona(context, chosenPersona);
            context.Done(chosenPersona.ToString());
        }
    }
}