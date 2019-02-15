using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BuddyBot.Helpers
{
    public class GlobalizationHelper
    {
        /// <summary>
        /// Returns the country code from given country name.
        /// </summary>
        /// <param name="countryName">Mandatory. The country name to convert to country code.</param>
        /// <returns></returns>
        public string GetCountryCode(string countryName)
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