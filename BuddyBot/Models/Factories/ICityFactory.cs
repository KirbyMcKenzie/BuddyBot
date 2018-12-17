using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddyBot.Models.Dtos;

namespace BuddyBot.Models.Factories
{
    public interface ICityFactory
    {
        City ConvertFromDto(string type);
    }
}
