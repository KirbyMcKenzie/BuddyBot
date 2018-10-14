using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class ConfirmRobotDialog: IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            
            await context.PostAsync("I am a Robot 🤖");

            Sleep(Pause.MediumLongPause);
            await context.PostAsync("Here's a selfie I took recently.");

            Sleep(Pause.MediumLongPause);
            IMessageActivity message = context.MakeMessage();

            message.Attachments.Add(new Attachment()
            {
                ContentUrl = "http://assets2.bigthink.com/system/idea_thumbnails/60606/size_1024/robot_child.jpg?1457480666",
                ContentType = "image/jpeg",
                Name = "Robots.jpg"
            });

            await context.PostAsync(message);

            Sleep(Pause.MediumLongPause);
            await context.PostAsync("See the computer in the background?");

            Sleep(Pause.MediumPause);
            context.Done("I use that to reply to you ✌");
        }
    }
}