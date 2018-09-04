using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace BuddyBot.Repository.Models
{
    public class ChatHistoryEntity: TableEntity
    {
        public ChatHistoryEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public string From { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }

    }
}
