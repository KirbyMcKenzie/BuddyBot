using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Repository.Models;

namespace BuddyBot.Repository.DataAccess.Contracts
{
    public interface IChatHistoryWriter
    {
        Task SaveMessage(ChatHistoryEntity chatHistoryEntity);
    }
}
