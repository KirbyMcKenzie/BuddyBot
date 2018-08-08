using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyBot.Models
{
    public enum DataStoreKey
    {
        [DataStoreEntry("Preferred name", DataStore.User)]
        PreferredFirstName
    }
}