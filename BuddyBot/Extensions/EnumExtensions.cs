using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BuddyBot.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the display name of the given Enum value.
        /// </summary>
        /// <param name="value">Enum value to get display name of.</param>
        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            EnumDisplayNameAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
            as EnumDisplayNameAttribute;

            return attribute == null ? value.ToString() : attribute.DisplayName;
        }
    }

    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }
    }
}