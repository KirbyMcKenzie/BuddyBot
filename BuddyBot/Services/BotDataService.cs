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
        /// <summary>
        /// Gets the users preferred name from BotData.
        /// </summary>
        /// <param name="botData">Mandatory. Users private bot data.</param>
        public string GetPreferredName(IBotData botData)
        {
            return botData.GetValueOrDefault<string>(DataStoreKey.PreferredFirstName);
        }

        /// <summary>
        /// Sets the users preferred name to BotData.
        /// </summary>
        /// <param name="botData">Mandatory. Users private bot data.</param>
        /// <param name="name">Mandatory. Name to set as the user's preferred name.</param>
        public void SetPreferredName(IBotData botData, string name)
        {
           botData.SetValue(DataStoreKey.PreferredFirstName, name);
        }

        /// <summary>
        /// Gets the users preferred bot personality from BotData.
        /// </summary>
        /// <param name="botData">Mandatory. Users private bot data.</param>
        public PersonalityChatPersona GetPreferredBotPersona(IBotData botData)
        {
            return botData.GetValueOrDefault<PersonalityChatPersona>(DataStoreKey.PreferredBotPersona);
        }

        /// <summary>
        /// Sets the users preferred bot personality to BotData.
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data.</param>
        /// <param name="persona">Mandatory. The bot personality to set as the users
        /// preferred bot personality</param>
        public void SetPreferredBotPersona(IBotData botData, PersonalityChatPersona persona)
        {
            botData.SetValue(DataStoreKey.PreferredBotPersona, persona);
        }

        /// <summary>
        /// Gets the users preferred weather location from BotData.
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data.</param>
        public City GetPreferredWeatherLocation(IBotData botData)
        {
            return botData.GetValueOrDefault<City>(DataStoreKey.PreferredWeatherLocation);
        }

        /// <summary>
        /// Sets the users preferred weather location to BotData.
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data.</param>
        /// <param name="city">Mandatory. The city to save as the users preferred 
        /// weather location.</param>
        public void setPreferredWeatherLocation(IBotData botData, City city)
        {
            botData.SetValue(DataStoreKey.PreferredWeatherLocation, city);
        }

        /// <summary>
        ///  Deletes all of the users private BotData.
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data to delete.</param>
        public void DeleteUserData(IBotData botData)
        {
            botData.RemoveValue(DataStoreKey.PreferredFirstName);
            botData.RemoveValue(DataStoreKey.PreferredBotPersona);
            botData.RemoveValue(DataStoreKey.PreferredWeatherLocation);
            botData.RemoveValue(DataStoreKey.HasCompletedGetStarted);
        }

        /// <summary>
        ///  Checks if the user has completed the get started tutorial.
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data</param>
        public bool hasCompletedGetStarted(IBotData botData)
        {
            return botData.GetValueOrDefault<bool>(DataStoreKey.HasCompletedGetStarted);
        }

        /// <summary>
        /// Sets the new user status once the user has completed the 
        /// get started tutorial
        /// </summary>
        /// <param name="botData">Mandatory. User's private bot data.</param>
        /// <param name="isNewUser">mandatory. Whether user has completed get 
        /// started tutorial or not.</param>
        public void SethasCompletedGetStarted(IBotData botData, bool isNewUser)
        {
            botData.SetValue(DataStoreKey.HasCompletedGetStarted, isNewUser);
        }
    }
}