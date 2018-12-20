using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models.Dtos;

namespace BuddyBot.Models.Mappers
{
    public interface IDomainMapper<in TFrom, out TTo>
    {
        TTo MapTo(TFrom mapFrom);
    }
}