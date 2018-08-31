using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyBot.Settings
{
    public interface IAzureStorageSettings
    {
        string ConnectionString { get; }
        string UserPreferencesDataTableName { get; }
        string LoggingTableName { get; }
    }
}
