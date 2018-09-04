using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.Models;
using BuddyBot.Settings;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Serilog;

namespace BuddyBot.Logging
{
    public class ActivityLogger: IActivityLogger
    {
        private readonly IAzureStorageSettings _azureStorageSettings;
        private readonly IChatHistoryWriter _chatHistoryWriter;


        public ActivityLogger(IAzureStorageSettings azureStorageSettings, IChatHistoryWriter chatHistoryWriter )
        {
            _azureStorageSettings = azureStorageSettings;
            _chatHistoryWriter = chatHistoryWriter;
        }

        public async Task LogAsync(IActivity activity)
        {
            if (activity.AsMessageActivity() != null)
            {
                ChatHistoryEntity chatHistoryEntity = 
                    new ChatHistoryEntity($"{activity.ChannelId}:{activity.Type}", Guid.NewGuid().ToString())
                    {
                        From = activity.From.Id,
                        Recipient = activity.Recipient.Id,
                        Message = activity.AsMessageActivity().Text
                    };

                await _chatHistoryWriter.SaveMessage(chatHistoryEntity);
            }

        }
    }
}