using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;

namespace BuddyBot.Contracts
{
    public interface IConversationService
    {
        Task<string> GetGreeting();

        Task<string> GetPoliteExpression();

        Task<string> GetHowsItPrompt();

        Task<string> GetHowsItResultGood();

        Task<string> GetHowsItResultBad();

    }
}