using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace BuddyBot.Services
{
    public class BotDataService : IBotDataService
    {
        public void SetPreferredName(IBotData botData, string name)
        {
           botData.SetValue(DataStoreKey.PreferredFirstName, name); 
        }

        public string GetPrerredName(IBotData botData)
        {
            return botData.GetValueOrDefault<string>(DataStoreKey.PreferredFirstName);
        }
    }
}