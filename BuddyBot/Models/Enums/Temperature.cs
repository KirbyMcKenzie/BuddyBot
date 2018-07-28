using BuddyBot.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyBot.Models.Enums
{
    public enum Temperature
    {
        [EnumDisplayName(DisplayName= "°C")]
        Celsius,

        [EnumDisplayName(DisplayName = "°F")]
        Fahrenheit
    }
}