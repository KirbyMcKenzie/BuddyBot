using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace BuddyBot.Services.Contracts
{
    public interface IBotDataService
    {
        void SetPreferredName(IBotData botData, string name);
        string GetPrerredName(IBotData botData);
    }
}