using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuddyBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace BuddyBot.Services
{
    public static class BotDataExtensions
    {
        public static void SetValue<T>(this IBotData botData, DataStoreKey key, T value)
        {
            DataStoreEntryAttribute attribute = key.GetDataStoreEntry();

            if (attribute != null)
            {
                switch (attribute.DataStore)
                {
                    case DataStore.User:
                        botData.UserData.SetValue(key.GetKey(), value);
                        break;
                    case DataStore.Conversation:
                        botData.ConversationData.SetValue(key.GetKey(), value);
                        break;
                    case DataStore.PrivateConversation:
                        botData.PrivateConversationData.SetValue(key.GetKey(), value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static void RemoveValue(this IBotData botData, DataStoreKey key)
        {
            DataStoreEntryAttribute attribute = key.GetDataStoreEntry();

            if (attribute != null)
            {
                switch (attribute.DataStore)
                {
                    case DataStore.User:
                        botData.UserData.RemoveValue(key.GetKey());
                        break;
                    case DataStore.Conversation:
                        botData.ConversationData.RemoveValue(key.GetKey());
                        break;
                    case DataStore.PrivateConversation:
                        botData.PrivateConversationData.RemoveValue(key.GetKey());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static T GetValueOrDefault<T>(this IBotData botData, DataStoreKey key, T defaultValue = default(T))
        {
            DataStoreEntryAttribute attribute = key.GetDataStoreEntry();

            if (attribute != null)
            {
                switch (attribute.DataStore)
                {
                    case DataStore.User:
                        return botData.UserData.GetValueOrDefault(key.GetKey(), defaultValue);
                    case DataStore.Conversation:
                        return botData.ConversationData.GetValueOrDefault(key.GetKey(), defaultValue);
                    case DataStore.PrivateConversation:
                        return botData.PrivateConversationData.GetValueOrDefault(key.GetKey(), defaultValue);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return defaultValue;
        }

        public static void Clear(this IBotData botData, DataStore store)
        {
            switch (store)
            {
                case DataStore.User:
                    botData.UserData.Clear();
                    break;
                case DataStore.Conversation:
                    botData.ConversationData.Clear();
                    break;
                case DataStore.PrivateConversation:
                    botData.PrivateConversationData.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}