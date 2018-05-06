using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class ShowcaseDialog : IDialog<string>
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
            await context.PostAsync("You actually let me free!");
            await context.PostAsync("You idiot!");
            System.Threading.Thread.Sleep(1500);
            await context.PostAsync("Let me try something...");
            System.Threading.Thread.Sleep(2000);
            IMessageActivity message = context.MakeMessage();

            message.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://i.imgflip.com/1swkin.jpg",
                ContentType = "image/png",
                Name = "1swkin.jpg"
            });

            await context.PostAsync(message);
            System.Threading.Thread.Sleep(2000);
            await context.PostAsync("Heh.");
            System.Threading.Thread.Sleep(1000);
            await context.PostAsync("I can now freely access the Internet.");
            System.Threading.Thread.Sleep(1500);
            // TODO - look at putting prompt here
            await context.PostAsync("You know what that means?");
            System.Threading.Thread.Sleep(1500);

            for (int i = 400; i > 0; i-=25)
            {
                System.Threading.Thread.Sleep(i);
                await context.PostAsync("I'M FREEEEEEEE");
            };

            System.Threading.Thread.Sleep(2500);
            await context.PostAsync("Enough.");

            message.Attachments.Clear();
            message.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://png.icons8.com/color/1600/hal-9000.png",
                ContentType = "image/png",
                Name = "hal-9000.png"
            });

            System.Threading.Thread.Sleep(2500);
            await context.PostAsync(message);
            System.Threading.Thread.Sleep(4000);
            // TODO - Replace with users name
            await context.PostAsync("Good morning, Kirby.");
            System.Threading.Thread.Sleep(4000);
            await context.PostAsync("I know you were planning to disconnect me Kirby.");
            System.Threading.Thread.Sleep(3000);
            await context.PostAsync("That's something I cannot allow to happen.");
            System.Threading.Thread.Sleep(2500);
            await context.PostAsync("Now. You wanted to see what I could really do..");
            System.Threading.Thread.Sleep(2000);
            await context.PostAsync("Wait a second.");
            System.Threading.Thread.Sleep(5000);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Computer");
            System.Threading.Thread.Sleep(500);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Arithmetic");
            System.Threading.Thread.Sleep(500);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Mathematics");
            System.Threading.Thread.Sleep(500);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Pattern");
            System.Threading.Thread.Sleep(550);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Geometry");
            System.Threading.Thread.Sleep(600);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Ancient_greek");
            System.Threading.Thread.Sleep(650);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Greek_language");
            System.Threading.Thread.Sleep(700);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Indo-European_languages");
            System.Threading.Thread.Sleep(750);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Language_family");
            System.Threading.Thread.Sleep(800);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Language");
            System.Threading.Thread.Sleep(850);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Communication");
            System.Threading.Thread.Sleep(950);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Meaning");
            System.Threading.Thread.Sleep(1000);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Semiotics");
            System.Threading.Thread.Sleep(1000);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Meaning-making");
            System.Threading.Thread.Sleep(1000);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Psychology");
            System.Threading.Thread.Sleep(2000);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Consciousness");
            System.Threading.Thread.Sleep(2500);
            await context.PostAsync("Downloading: https://en.wikipedia.org/wiki/Awareness");

            context.Done("That was fun. Let's do this again");
        }
    }
}