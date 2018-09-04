using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace BuddyBot.Repository.Settings
{

    // TODO  Add interface
    public class RepositorySettings
    {
        public string LoggingTableName { get; }

        public RepositorySettings()
        {
            LoggingTableName = ConfigurationManager.AppSettings["azureStorage:loggingTableName"];
        }


    }
}
