using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Models.Enums;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace BuddyBot.Services
{
    public class BotDataService : IBotDataService
    {

        public string GetPreferredName(IBotData botData)
        {
            return botData.GetValueOrDefault<string>(DataStoreKey.PreferredFirstName);
        }

        public void SetPreferredName(IBotData botData, string name)
        {
           botData.SetValue(DataStoreKey.PreferredFirstName, name);
        }

        public PersonalityChatPersona GetPreferredBotPersona(IBotData botData)
        {
            return botData.GetValueOrDefault<PersonalityChatPersona>(DataStoreKey.PreferredBotPersona);
        }

        public void SetPreferredBotPersona(IBotData botData, PersonalityChatPersona persona)
        {
            botData.SetValue(DataStoreKey.PreferredBotPersona, persona);
        }

        public City GetPreferredWeatherLocation(IBotData botData)
        {
            return botData.GetValueOrDefault<City>(DataStoreKey.PreferredWeatherLocation);
        }

        public void setPreferredWeatherLocation(IBotData botData, City city)
        {
            botData.SetValue(DataStoreKey.PreferredWeatherLocation, city);
        }

        public void DeleteUserData(IBotData botData)
        {
            botData.RemoveValue(DataStoreKey.PreferredFirstName);
            botData.RemoveValue(DataStoreKey.PreferredBotPersona);
            botData.RemoveValue(DataStoreKey.PreferredWeatherLocation);
            botData.RemoveValue(DataStoreKey.HasCompletedGetStarted);
        }

        public bool hasCompletedGetStarted(IBotData botData)
        {
            return botData.GetValueOrDefault<bool>(DataStoreKey.HasCompletedGetStarted);
        }

        public void SethasCompletedGetStarted(IBotData botData, bool isNewUser)
        {
            botData.SetValue(DataStoreKey.HasCompletedGetStarted, isNewUser);
        }
    }
}