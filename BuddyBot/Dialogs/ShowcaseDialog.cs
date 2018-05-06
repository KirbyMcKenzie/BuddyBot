using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class ShowcaseDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //Todo - make this more sinister
            await context.PostAsync("In order for me to show you what I can really do, you must click 'yes' on the following button. ");

            PromptDialog.Confirm(context, MessageReceivedAsync, "Would you like me to cause chaos?");
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            if (await argument)
                await CauseChaos(context);
            context.Done("Fine..");

        }

        private async Task CauseChaos(IDialogContext context)
        {

            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                await context.PostAsync("1 second wait");
            };

            context.Done("That was fun. Let's do this again");
        }
    }
}