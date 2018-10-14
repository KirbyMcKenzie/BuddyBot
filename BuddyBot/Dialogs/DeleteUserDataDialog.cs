using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuddyBot.Dialogs
{
    public class DeleteUserDataDialog : IDialog<string>
    {
        public  Task StartAsync(IDialogContext context)
        {
            context.Done(context.PostAsync("Hi"));
            return Task.CompletedTask;
        }
    }
}