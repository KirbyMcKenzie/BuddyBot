using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.PersonalityChat.Core;

namespace BuddyBot.Services
{
    public class BotDataService : IBotDataService
    {
        public void SetPreferredName(IBotData botData, string name)
        {
           botData.SetValue(DataStoreKey.PreferredFirstName, name); 
        }

        public string GetPreferredName(IBotData botData)
        {
            return botData.GetValueOrDefault<string>(DataStoreKey.PreferredFirstName);
        }

        public void SetPreferredBotPersona(IBotData botData, PersonalityChatPersona persona)
        {
            botData.SetValue(DataStoreKey.PreferredBotPersona, persona);
        }

        public PersonalityChatPersona GetPreferredBotPersona(IBotData botData)
        {
            return botData.GetValueOrDefault<PersonalityChatPersona>(DataStoreKey.PreferredBotPersona);
        }
    }
}