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

namespace BuddyBot.Dialogs
{

    [Serializable]
    public class NameDialog : IDialog<string>
    {
        private string _suggestedName;
        private readonly IBotDataService _botDataService;
        private readonly IList<EntityRecommendation> _entities;

        public NameDialog(IBotDataService botDataService, IList<EntityRecommendation> entities)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _entities, nameof(entities), entities);
        }

        public Task StartAsync(IDialogContext context)
        {
            string preferredNameFromMessage = MessageHelpers.ExtractEntityFromMessage("User.PreferredName", _entities);
            string name = _botDataService.GetPreferredName(context);

            if (!string.IsNullOrWhiteSpace(preferredNameFromMessage))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"So you'd like me to call you {preferredNameFromMessage} from now on?", $"Sorry I don't understand - try again! Should I call you {_suggestedName}?");
                return Task.CompletedTask;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Do you want me to keep calling you {name}?", $"Sorry I don't understand - try again! Should I call you {_suggestedName}?");
                return Task.CompletedTask;
            }

            string fromName = context.Activity.From.Name;

            _suggestedName = fromName.Split(' ').First();

            if (_suggestedName.ToLower().Contains("user"))
            {
                PromptDialog.Text(context, ResumeAfterNameFilled, "What should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                return Task.CompletedTask;
            }

            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Should I call you {_suggestedName}?", $"Sorry I don't understand - try again! Should I call you {_suggestedName}?");
            return Task.CompletedTask;
        }

        private async Task ResumeAfterNameFilled(IDialogContext context, IAwaitable<string> result)
        {
            string filledName = await result;

            _botDataService.SetPreferredName(context, filledName);

            context.Done(filledName);
        }

        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    context.Done(_botDataService.GetPreferredName(context));
                    break;
                default:
                    PromptDialog.Text(context, ResumeAfterNameFilled, "Okay, what should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                    break;
            }
        }

        private async Task ResumeAfterNameChangedPrompt(IDialogContext context, IAwaitable<string> result)
        {
            string filledName = await result;

            _botDataService.SetPreferredName(context, filledName);

            context.Done(filledName);
        }
    }
}