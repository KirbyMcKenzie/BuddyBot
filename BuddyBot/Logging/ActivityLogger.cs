using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Serilog;

namespace BuddyBot.Logging
{
    public class ActivityLogger: IActivityLogger
    {

        public async Task LogAsync(IActivity activity)
        {
            var storage = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("azureStorage:connectionString"));

            var log = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(storage)
                .MinimumLevel.Debug()
                .CreateLogger();

            // TODO - come back to this
            /*var log = new LoggerConfiguration() 
                          .WriteTo.AzureTableStorageWithProperties(storage, storageTableName: "customName", writeInBatches: true, batchPostingLimit: 100, period: new System.TimeSpan(0, 0, 3)) 
                          .CreateLogger(); 
            */

            Debug.WriteLine($"From:{activity.From.Id} - To:{activity.Recipient.Id} - Message:{activity.AsMessageActivity()?.Text}");
            log.Information($"From:{activity.From.Id} - To:{activity.Recipient.Id} - Message:{activity.AsMessageActivity()?.Text}");

            await Task.Yield();
        }
    }
}