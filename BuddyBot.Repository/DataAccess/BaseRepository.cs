using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Repository.DbContext;

namespace BuddyBot.Repository.DataAccess
{
    public abstract class BaseRepository
    {
        protected BuddyBotDbContext _context;

        public BaseRepository(BuddyBotDbContext context)
        {
            _context = context;
        }

        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // TODO - logging
                return false;
            }
        } 
    }

}
