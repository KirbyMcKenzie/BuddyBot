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

        public BotPersonaDialog(IBotDataService botDataService, IList<EntityRecommendation> entities)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _entities, nameof(entities), entities);
        }

        public Task StartAsync(IDialogContext context)
        {
            PersonalityChatPersona persona = _botDataService.GetPreferredBotPersona(context);
            var preferredBotPersona = MessageHelpers.ExtractEntityFromMessage("User.PreferredBotPersona", _entities);


            if (!string.IsNullOrWhiteSpace(persona.ToString()))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"My persona is set to {persona}. Would you like to change it?", $"Sorry I don't understand - try again! Would you like to change my persona?");
                return Task.CompletedTask;
            }

            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"What persona would you like me to take on?", $"Sorry I don't understand - try again! What persona would you like me to take on?");
            return Task.CompletedTask;
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