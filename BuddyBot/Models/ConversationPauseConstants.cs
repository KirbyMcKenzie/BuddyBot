using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BuddyBot.Models
{
    /// <summary>
    ///  Constants for use in conjuction with <see cref="Thread.Sleep"/> to maintain
    ///  consistency and to assist with code refactoring.
    /// </summary>
    public class ConversationPauseConstants
    {
        public const int ShortPause = 1000;
        public const int ShortMediumPause = 1500;
        public const int MediumPause = 2000;
        public const int MediumLongPause = 2500;
        public const int LongPause = 3000;
        public const int LongerPause = 3500;
        public const int ExtraLongPause  = 4000;
        public const int VeryLongPause = 4500;
    }
}