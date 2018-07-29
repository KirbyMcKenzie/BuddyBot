using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BuddyBot.Helpers
{
    public static class GlobalizationHelpers
    {
        public static string GetCountryCode(string countryName)
        {
            IEnumerable<RegionInfo> regionFullNames = CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(x => new RegionInfo(x.LCID));

            string countryCode = regionFullNames.FirstOrDefault(
                region => region.EnglishName.Contains(countryName)
            )?.ToString();

            return countryCode;
        }
    }
}