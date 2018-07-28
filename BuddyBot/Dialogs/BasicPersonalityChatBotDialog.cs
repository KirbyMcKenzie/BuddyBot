using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Builder.PersonalityChat;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class BasicPersonalityChatBotDialog : PersonalityChatDialog<object>
    {
        public BasicPersonalityChatBotDialog()
        {
            PersonalityChatDialogOptions personalityChatDialogOptions = new PersonalityChatDialogOptions();

            this.SetPersonalityChatDialogOptions(personalityChatDialogOptions);
        }
    }
}