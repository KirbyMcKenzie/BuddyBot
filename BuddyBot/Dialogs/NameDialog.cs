using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Helpers;
using BuddyBot.Helpers.Contracts;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class NameDialog : IDialog<string>
    {
        private string _preferredName;
        private readonly IBotDataService _botDataService;
        private readonly IMessageHelpers _messageHelpers;
        private readonly IList<EntityRecommendation> _entities;

        public NameDialog(IBotDataService botDataService, IMessageHelpers messageHelpers, IList<EntityRecommendation> entities)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _messageHelpers, nameof(messageHelpers), messageHelpers);
            _entities = entities;
        }

        public Task StartAsync(IDialogContext context)
        {

            if (_entities != null)
            {
                _preferredName = _messageHelpers.ExtractEntityFromMessage("User.PreferredName", _entities);
            }
           
            string name = _botDataService.GetPreferredName(context);

            if (!string.IsNullOrWhiteSpace(_preferredName))
            {
                PromptDialog.Confirm(context, ResumeAfterPreferredNameConfirmation, $"So you'd like me to call you {_preferredName}?", $"Sorry I don't understand - try again! Should I call you {_preferredName}?");
                return Task.CompletedTask;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Do you want me to keep calling you {name}?", $"Sorry I don't understand - try again! Should I call you {name}?");
                return Task.CompletedTask;
            }

            PromptDialog.Text(context, ResumeAfterNameFilled, "What is your name?", "Sorry I didn't get that - try again! What should I call you?");
            return Task.CompletedTask;
        }

        private async Task ResumeAfterPreferredNameConfirmation(IDialogContext context, IAwaitable<bool> result)
        {

            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.SetPreferredName(context, _preferredName);
                    context.Done(_preferredName);
                    break;
                default:
                    PromptDialog.Text(context, ResumeAfterNameFilled, "Okay, what should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                    break;
            }
        }

        private async Task ResumeAfterNameFilled(IDialogContext context, IAwaitable<string> result)
        {
            _preferredName = await result;
            PromptDialog.Confirm(context, ResumeAfterPreferredNameConfirmation, $"So you'd like me to call you {_preferredName}?", $"Sorry I don't understand - try again! Should I call you {_preferredName}?");
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
    }
}