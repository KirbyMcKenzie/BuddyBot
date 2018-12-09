using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.DbContext;
using BuddyBot.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Repository.DataAccess
{
    public class CityReader: BaseRepository, ICityReader
    {
        public CityReader(BuddyBotDbContext context) : base(context)
        {
        }

        public async Task<IList<City>> GetCitiesByName(string cityName)
        {
            IList<City> cities = await _context.Cities.Where(c => c.Name == cityName)
                .ToAsyncEnumerable().ToList();

            return cities;
        }

        public async Task<City> GetCityById(int cityId)
        {
            City city = await _context.Cities.SingleOrDefaultAsync(c => c.Id == cityId);

            return city;
        }
    }
}
