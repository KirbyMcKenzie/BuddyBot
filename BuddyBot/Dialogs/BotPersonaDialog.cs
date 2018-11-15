using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.PersonalityChat.Core;

namespace BuddyBot.Dialogs
{
    public class BotPersonaDialog: IDialog<string>
    {
        private readonly IBotDataService _botDataService;
        private readonly IList<EntityRecommendation> _entities;
        private string _preferredBotPersona;

        public BotPersonaDialog(IBotDataService botDataService, IList<EntityRecommendation> entities)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            _entities = entities;
        }

        public Task StartAsync(IDialogContext context)
        {

            PersonalityChatPersona persona = _botDataService.GetPreferredBotPersona(context);


            if (_entities != null)
            {
                _preferredBotPersona = MessageHelpers.ExtractEntityFromMessage("User.PreferredBotPersona", _entities);
            }

            if (!string.IsNullOrWhiteSpace(_preferredBotPersona))
            {
                PromptDialog.Confirm(context, ResumeAfterPreferredPersonaConfirmation, $"So you'd like me to change my personality to {_preferredBotPersona}?", $"Sorry I don't understand - try again! Should I change my personality to {_preferredBotPersona}?");
                return Task.CompletedTask;
            }

            if (!string.IsNullOrWhiteSpace(persona.ToString()))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"My persona is set to {persona}. Would you like to change it?", $"Sorry I don't understand - try again! Would you like to change my persona?");
                return Task.CompletedTask;
            }

            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"What persona would you like me to take on?", $"Sorry I don't understand - try again! What persona would you like me to take on?");
            return Task.CompletedTask;
        }

        // TODO - check true/false
        private async Task ResumeAfterPreferredPersonaConfirmation(IDialogContext context, IAwaitable<bool> result)
        {

            // TODO - handle exception/ nulls
            Enum.TryParse(_preferredBotPersona, out PersonalityChatPersona preferredPersona);

            _botDataService.SetPreferredBotPersona(context, preferredPersona);
            context.Done(_preferredBotPersona);

            await Task.Yield();
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