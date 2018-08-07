using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BuddyBot.Models
{
    public static class EnumExtensions
    {
        public static string GetFriendlyName(this DataStoreKey value)
        {
            return GetFriendlyNameFromAttribute(value);
        }

        public static string GetKey(this DataStoreKey value)
        {
            return value.ToString("G");
        }

        public static DataStoreEntryAttribute GetDataStoreEntry(this DataStoreKey value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DataStoreEntryAttribute[] entryAttributes =
                (DataStoreEntryAttribute[])fi.GetCustomAttributes(typeof(DataStoreEntryAttribute), false);

            if (entryAttributes.Length > 0)
                return entryAttributes[0];
            return null;
        }
        private static string GetFriendlyNameFromAttribute<T>(T value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DataStoreEntryAttribute[] entryAttributes =
                (DataStoreEntryAttribute[])fi.GetCustomAttributes(typeof(DataStoreEntryAttribute), false);

            if (entryAttributes.Length > 0)
                return entryAttributes[0].FriendlyName;
            return string.Empty;
        }
    }
}