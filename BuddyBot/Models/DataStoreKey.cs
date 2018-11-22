using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyBot.Models
{
    public enum DataStoreKey
    {
        [DataStoreEntry("Preferred name", DataStore.User)]
        PreferredFirstName,

        [DataStoreEntry("Preferred persona", DataStore.User)]
        PreferredBotPersona,

        [DataStoreEntry("Preferred weather location", DataStore.User)]
        PreferredWeatherLocation,

        [DataStoreEntry("Has Completed Get Started", DataStore.User)]
        HasCompletedGetStarted
    }
}