using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuddyBot.Dialogs
{
    public class DeleteUserDataDialog : IDialog<string>
    {

        private readonly IBotDataService _botDataService;

        public DeleteUserDataDialog(IBotDataService botDataService)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
        }


        public Task StartAsync(IDialogContext context)
        {
            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Would you like to delete your user data?", $"Would you like to delete your user data");
            return Task.CompletedTask;
        }

        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    _botDataService.DeleteUserData(context);
                    context.Done("Your data has been deleted");
                    break;
                default:
                    context.Done("Thank goodness!");
                    break;
            }
        }
    }
}