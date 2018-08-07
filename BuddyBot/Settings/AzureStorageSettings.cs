using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BuddyBot.Settings
{
    public class AzureStorageSettings : IAzureStorageSettings
    {
        public string ConnectionString { get; }
        public string UserPreferencesDataTableName { get; }

        public AzureStorageSettings()
        {
            ConnectionString = ConfigurationManager.AppSettings["azureStorage:connectionString"];
            UserPreferencesDataTableName = ConfigurationManager.AppSettings["azureStorage:userPreferencesDataTableName"];
        }
    }

    
}