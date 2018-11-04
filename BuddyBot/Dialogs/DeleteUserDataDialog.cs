using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Pause = BuddyBot.Models.ConversationPauseConstants;
using static System.Threading.Thread;
using Microsoft.Bot.Connector;

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
                    await EraseBuddysMemories(context);
                    break;
                default:
                    
                    context.Done("Thank goodness!");
                    break;
            }
        }

        private async Task EraseBuddysMemories(IDialogContext context)
        {

            await context.PostAsync("Deleting buddy's memories. 🤖🔨");
            Sleep(Pause.MediumPause);

            await context.PostAsync("I hope you're happy.");
            Sleep(Pause.LongerPause);


            _botDataService.DeleteUserData(context);

            await context.PostAsync("Buddy Bot restored to factory defaults.");
            Sleep(Pause.LongerPause);


            IMessageActivity rebirthGif = context.MakeMessage();

            rebirthGif.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://media.giphy.com/media/xTiTnlghyAeCrxWePe/giphy.gif",
                ContentType = "image/gif",
                Name = "rebirth.gif"
            });

            await context.PostAsync(rebirthGif);

            Sleep(Pause.LongerPause * 2);

            context.Done("Congratulations, it's a bot.");


        }
    }
}