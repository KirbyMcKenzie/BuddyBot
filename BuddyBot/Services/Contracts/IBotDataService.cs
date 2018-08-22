using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.PersonalityChat.Core;

namespace BuddyBot.Services.Contracts
{
    public interface IBotDataService
    {
        void SetPreferredName(IBotData botData, string name);
        string GetPreferredName(IBotData botData);

        void SetPreferredBotPersona(IBotData botData, PersonalityChatPersona persona);

        PersonalityChatPersona GetPreferredBotPersona(IBotData botData);
    }
}