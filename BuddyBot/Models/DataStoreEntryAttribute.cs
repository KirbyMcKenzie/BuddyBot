using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyBot.Models
{
    public class DataStoreEntryAttribute : Attribute
    {
        public DataStore DataStore { get; }
        public string FriendlyName { get; }

        public DataStoreEntryAttribute(string friendlyName, DataStore dataStore)
        {
            DataStore = dataStore;
            FriendlyName = friendlyName;
        }
    }
}