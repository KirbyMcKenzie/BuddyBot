using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Interfaces
{
    public interface IDialogBuilder
    {
        RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, LuisResult result);

        ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message);

    }
}