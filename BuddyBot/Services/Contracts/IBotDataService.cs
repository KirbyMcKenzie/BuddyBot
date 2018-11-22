using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace BuddyBot.Services.Contracts
{
    public interface IBotDataService
    {
        // Name 
        string GetPreferredName(IBotData botData);
        void SetPreferredName(IBotData botData, string name);

        // Persona
        PersonalityChatPersona GetPreferredBotPersona(IBotData botData);
        void SetPreferredBotPersona(IBotData botData, PersonalityChatPersona persona);

        // Weather
        City GetPreferredWeatherLocation(IBotData botData);
        void setPreferredWeatherLocation(IBotData botData, City city);

        // User Data
        void DeleteUserData(IBotData botData);

        // New User
        bool IsNewUser(IBotData botData);
        void SetIsNewUser(IBotData botData, bool isNewUser);


    }
}