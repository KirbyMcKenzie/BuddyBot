using BuddyBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuddyBot.Repository.DataAccess.Contracts
{
    public interface ISmallTalkResponseReader
    {
        Task<IList<SmallTalkResponse>> GetSmallTalkResponsesByIntentName(string intentName, string personaType);
    }
}
