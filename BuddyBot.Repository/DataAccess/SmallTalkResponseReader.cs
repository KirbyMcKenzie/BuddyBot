using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.DbContext;
using BuddyBot.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Repository.DataAccess
{
    public class SmallTalkResponseReader : BaseRepository, ISmallTalkResponseReader
    {
        public SmallTalkResponseReader(BuddyBotDbContext context) : base(context)
        {
        }

        public async Task<IList<SmallTalkResponse>> GetSmallTalkResponsesByIntentName(string IntentName)
        {
            IList<SmallTalkResponse> responseResult = await _context.SmallTalkResponses
                .Where(r => r.IntentName == IntentName).ToListAsync();
               
            return responseResult;
        }
    }
}
