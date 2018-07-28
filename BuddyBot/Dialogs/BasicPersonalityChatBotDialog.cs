using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Builder.PersonalityChat;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class BasicPersonalityChatBotDialog : PersonalityChatDialog<object> 
    {
        public BasicPersonalityChatBotDialog()
        {
            PersonalityChatDialogOptions personalityChatDialogOptions = new PersonalityChatDialogOptions()
            {
                RespondOnlyIfChat = false,
                ScenarioThresholdScore = 0.2f
            };

            this.SetPersonalityChatDialogOptions(personalityChatDialogOptions);

        }


    }
}