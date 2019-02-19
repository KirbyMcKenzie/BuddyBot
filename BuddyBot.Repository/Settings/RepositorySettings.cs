using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace BuddyBot.Repository.Settings
{

    public class RepositorySettings
    {
        public string ChatHistoryTableName { get; }
        public string ConnectionString { get; }

        public RepositorySettings()
        {
            ChatHistoryTableName = ConfigurationManager.AppSettings["azureStorage:conversationHistory"];
            ConnectionString = ConfigurationManager.AppSettings["azureStorage:connectionString"];
        }
    }
}
