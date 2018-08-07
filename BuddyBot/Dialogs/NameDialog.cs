using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace BuddyBot.Dialogs
{

    [Serializable]
    public class NameDialog : IDialog<string>
    {
        private string _suggestedName;
        private readonly IBotDataService _botDataService;

        public NameDialog(IBotDataService botDataService)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
        }

        public Task StartAsync(IDialogContext context)
        {
            string name = _botDataService.GetPreferredName(context);
            if (!string.IsNullOrWhiteSpace(name))
            {
                context.Done(name);
                return Task.CompletedTask;
            }

            // 6. Try extract name from a channel (eg. Facebook will return the user name)
            string fromName = context.Activity.From.Name;

            _suggestedName = fromName.Split(' ').First();

            if (_suggestedName.ToLower().Contains("user"))
            {
                // 7. Webchat has no name, default is "user". Request real name from the user.
                PromptDialog.Text(context, ResumeAfterNameFilled, "What should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                return Task.CompletedTask;
            }

            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Should I call you {_suggestedName}?", $"Sorry I don't understand - try again! Should I call you {_suggestedName}?");
            return Task.CompletedTask;
        }

        private async Task ResumeAfterNameFilled(IDialogContext context, IAwaitable<string> result)
        {
            // 8. Wait for the name 
            string filledName = await result;

            // 9. Save the name in bot data store
            _botDataService.SetPreferredName(context, filledName);

            // 10. End the dialog, and return the filledName to caller dialog (DemoDialog).
            context.Done(filledName);
        }

        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.SetPreferredName(context, _suggestedName);
                    context.Done(_suggestedName);
                    break;
                default:
                    PromptDialog.Text(context, ResumeAfterNameFilled, "Okay, what should I call you?", "Sorry I didn't get that - try again! What should I call you?");
                    break;
            }
        }
    }
}